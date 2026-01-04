using System.Diagnostics;

namespace AntiVirus.Core;

/// <summary>
/// Karantina yönetim sistemi
/// </summary>
public class QuarantineManager
{
    private readonly string _quarantineDirectory;

    public QuarantineManager()
    {
        _quarantineDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "AntiVirus",
            "Quarantine");

        if (!Directory.Exists(_quarantineDirectory))
        {
            Directory.CreateDirectory(_quarantineDirectory);
        }
    }

    public bool QuarantineFile(string filePath, ThreatDetectionResult threat)
    {
        try
        {
            if (!File.Exists(filePath))
                return false;

            var fileName = Path.GetFileName(filePath);
            var quarantinePath = Path.Combine(
                _quarantineDirectory,
                $"{DateTime.Now:yyyyMMdd_HHmmss}_{fileName}");

            // Dosyayı karantinaya taşı
            File.Move(filePath, quarantinePath);

            // Karantina bilgilerini kaydet
            var infoPath = quarantinePath + ".info";
            var info = $@"Tehdit Adı: {threat.ThreatName}
Tespit Tarihi: {threat.DetectedAt}
Dosya Yolu: {filePath}
Detaylar: {threat.Details}
Tespit Yöntemi: {threat.Method}";

            File.WriteAllText(infoPath, info);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Karantina hatası: {ex.Message}");
            return false;
        }
    }

    public bool TerminateProcess(int processId)
    {
        try
        {
            var process = Process.GetProcessById(processId);
            process.Kill();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Süreç sonlandırma hatası: {ex.Message}");
            return false;
        }
    }

    public List<string> GetQuarantinedFiles()
    {
        var files = new List<string>();

        if (!Directory.Exists(_quarantineDirectory))
            return files;

        try
        {
            files = Directory.GetFiles(_quarantineDirectory, "*.*")
                .Where(f => !f.EndsWith(".info"))
                .ToList();
        }
        catch
        {
            // Hata durumunda boş liste
        }

        return files;
    }

    public bool RestoreFile(string quarantinedFilePath)
    {
        try
        {
            if (!File.Exists(quarantinedFilePath))
                return false;

            var infoPath = quarantinedFilePath + ".info";
            if (!File.Exists(infoPath))
                return false;

            var info = File.ReadAllText(infoPath);
            // Orijinal dosya yolunu info dosyasından çıkar
            var originalPath = ExtractOriginalPath(info);

            if (string.IsNullOrEmpty(originalPath))
                return false;

            // Dosyayı geri yükle
            File.Move(quarantinedFilePath, originalPath);
            File.Delete(infoPath);

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Geri yükleme hatası: {ex.Message}");
            return false;
        }
    }

    private string ExtractOriginalPath(string info)
    {
        var lines = info.Split('\n');
        foreach (var line in lines)
        {
            if (line.StartsWith("Dosya Yolu:"))
            {
                return line.Substring("Dosya Yolu:".Length).Trim();
            }
        }
        return string.Empty;
    }
}

