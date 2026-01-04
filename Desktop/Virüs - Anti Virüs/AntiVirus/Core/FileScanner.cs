using System.Text;

namespace AntiVirus.Core;

/// <summary>
/// Dosya tarama motoru
/// </summary>
public class FileScanner
{
    private readonly List<ThreatSignature> _signatures;

    public FileScanner()
    {
        _signatures = SignatureDatabase.GetSignatures();
    }

    public List<ThreatDetectionResult> ScanFile(string filePath)
    {
        var results = new List<ThreatDetectionResult>();

        if (!File.Exists(filePath))
            return results;

        try
        {
            var fileName = Path.GetFileName(filePath).ToLower();
            
            // Dosya adı kontrolü
            foreach (var signature in _signatures)
            {
                if (signature.FileNames.Any(fn => fileName.Contains(fn.ToLower())))
                {
                    results.Add(new ThreatDetectionResult
                    {
                        IsThreat = true,
                        DetectedSignature = signature,
                        ThreatName = signature.Name,
                        FilePath = filePath,
                        Details = $"Dosya adı eşleşmesi: {fileName}",
                        Method = DetectionMethod.SignatureBased
                    });
                }
            }

            // Dosya içeriği kontrolü (küçük dosyalar için)
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Length < 10 * 1024 * 1024) // 10MB'dan küçük dosyalar
            {
                try
                {
                    var content = File.ReadAllText(filePath, Encoding.UTF8);
                    if (SignatureDatabase.ContainsSuspiciousString(content))
                    {
                        foreach (var signature in _signatures)
                        {
                            if (signature.SuspiciousStrings.Any(str => 
                                content.ToLower().Contains(str.ToLower())))
                            {
                                results.Add(new ThreatDetectionResult
                                {
                                    IsThreat = true,
                                    DetectedSignature = signature,
                                    ThreatName = signature.Name,
                                    FilePath = filePath,
                                    Details = "Dosya içeriğinde şüpheli string bulundu",
                                    Method = DetectionMethod.Heuristic
                                });
                            }
                        }
                    }
                }
                catch
                {
                    // Binary dosya veya okunamayan dosya, atla
                }
            }

            // PE (Portable Executable) dosyası kontrolü
            if (filePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
                filePath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
            {
                var peResult = ScanPEFile(filePath);
                if (peResult != null)
                    results.Add(peResult);
            }
        }
        catch (Exception ex)
        {
            // Hata durumunda log
            Console.WriteLine($"Dosya taranırken hata: {ex.Message}");
        }

        return results;
    }

    private ThreatDetectionResult? ScanPEFile(string filePath)
    {
        try
        {
            var bytes = File.ReadAllBytes(filePath);
            var content = Encoding.UTF8.GetString(bytes);

            foreach (var signature in _signatures)
            {
                foreach (var suspiciousStr in signature.SuspiciousStrings)
                {
                    if (content.Contains(suspiciousStr, StringComparison.OrdinalIgnoreCase))
                    {
                        return new ThreatDetectionResult
                        {
                            IsThreat = true,
                            DetectedSignature = signature,
                            ThreatName = signature.Name,
                            FilePath = filePath,
                            Details = $"PE dosyasında şüpheli string: {suspiciousStr}",
                            Method = DetectionMethod.SignatureBased
                        };
                    }
                }
            }
        }
        catch
        {
            // Hata durumunda null döndür
        }

        return null;
    }

    public List<ThreatDetectionResult> ScanDirectory(string directoryPath, bool recursive = true)
    {
        var results = new List<ThreatDetectionResult>();

        if (!Directory.Exists(directoryPath))
            return results;

        try
        {
            var searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var files = Directory.GetFiles(directoryPath, "*.*", searchOption);

            foreach (var file in files)
            {
                var fileResults = ScanFile(file);
                results.AddRange(fileResults);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dizin taranırken hata: {ex.Message}");
        }

        return results;
    }
}

