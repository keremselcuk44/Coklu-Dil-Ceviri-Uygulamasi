using System.Diagnostics;
using System.Management;

namespace AntiVirus.Core;

/// <summary>
/// Süreç tarama ve izleme motoru
/// </summary>
public class ProcessScanner
{
    private readonly List<ThreatSignature> _signatures;

    public ProcessScanner()
    {
        _signatures = SignatureDatabase.GetSignatures();
    }

    public List<ThreatDetectionResult> ScanRunningProcesses()
    {
        var results = new List<ThreatDetectionResult>();

        try
        {
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                try
                {
                    var processResult = ScanProcess(process);
                    if (processResult != null && processResult.IsThreat)
                    {
                        results.Add(processResult);
                    }
                }
                catch
                {
                    // Erişilemeyen süreçleri atla
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Süreç taraması sırasında hata: {ex.Message}");
        }

        return results;
    }

    public ThreatDetectionResult? ScanProcess(Process process)
    {
        try
        {
            var processName = process.ProcessName.ToLower();
            var mainModulePath = string.Empty;

            try
            {
                mainModulePath = process.MainModule?.FileName ?? string.Empty;
            }
            catch
            {
                // Erişilemeyen modül
            }

            // Süreç adı kontrolü
            foreach (var signature in _signatures)
            {
                if (signature.ProcessNames.Any(pn => 
                    processName.Contains(pn.ToLower())))
                {
                    return new ThreatDetectionResult
                    {
                        IsThreat = true,
                        DetectedSignature = signature,
                        ThreatName = signature.Name,
                        ProcessName = process.ProcessName,
                        ProcessId = process.Id,
                        FilePath = mainModulePath,
                        Details = $"Şüpheli süreç adı: {process.ProcessName}",
                        Method = DetectionMethod.ProcessMonitoring
                    };
                }
            }

            // Dosya yolu kontrolü
            if (!string.IsNullOrEmpty(mainModulePath))
            {
                var fileName = Path.GetFileName(mainModulePath).ToLower();
                foreach (var signature in _signatures)
                {
                    if (signature.FileNames.Any(fn => 
                        fileName.Contains(fn.ToLower())))
                    {
                        return new ThreatDetectionResult
                        {
                            IsThreat = true,
                            DetectedSignature = signature,
                            ThreatName = signature.Name,
                            ProcessName = process.ProcessName,
                            ProcessId = process.Id,
                            FilePath = mainModulePath,
                            Details = $"Şüpheli dosya yolu: {mainModulePath}",
                            Method = DetectionMethod.ProcessMonitoring
                        };
                    }
                }
            }

            // Davranış tabanlı tespit
            var behaviorResult = AnalyzeProcessBehavior(process);
            if (behaviorResult != null)
                return behaviorResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Süreç analizi sırasında hata: {ex.Message}");
        }

        return null;
    }

    private ThreatDetectionResult? AnalyzeProcessBehavior(Process process)
    {
        try
        {
            // Yüksek CPU kullanımı ve düşük bellek kullanımı (keylogger işareti)
            if (process.WorkingSet64 < 5 * 1024 * 1024 && // 5MB'dan az bellek
                process.Threads.Count > 0)
            {
                // Şüpheli davranış olabilir
                return new ThreatDetectionResult
                {
                    IsThreat = true,
                    ThreatName = "Suspicious Process Behavior",
                    ProcessName = process.ProcessName,
                    ProcessId = process.Id,
                    Details = "Düşük bellek kullanımı ile şüpheli davranış",
                    Method = DetectionMethod.BehaviorBased
                };
            }
        }
        catch
        {
            // Hata durumunda null
        }

        return null;
    }

    public List<Process> GetProcessesBySignature(ThreatSignature signature)
    {
        var suspiciousProcesses = new List<Process>();

        try
        {
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                try
                {
                    var processName = process.ProcessName.ToLower();
                    if (signature.ProcessNames.Any(pn => 
                        processName.Contains(pn.ToLower())))
                    {
                        suspiciousProcesses.Add(process);
                    }
                }
                catch
                {
                    // Erişilemeyen süreç
                }
            }
        }
        catch
        {
            // Hata durumunda boş liste
        }

        return suspiciousProcesses;
    }
}

