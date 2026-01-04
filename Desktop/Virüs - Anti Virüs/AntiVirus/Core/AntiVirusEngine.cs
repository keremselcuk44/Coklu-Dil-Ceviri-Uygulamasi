namespace AntiVirus.Core;

/// <summary>
/// Ana antivirüs motoru
/// </summary>
public class AntiVirusEngine
{
    private readonly FileScanner _fileScanner;
    private readonly ProcessScanner _processScanner;
    private readonly QuarantineManager _quarantineManager;
    private bool _isScanning;
    private bool _realTimeProtectionEnabled;

    public event EventHandler<ThreatDetectionResult>? ThreatDetected;
    public event EventHandler<string>? ScanProgress;
    public event EventHandler<ScanCompletedEventArgs>? ScanCompleted;

    public bool IsScanning => _isScanning;
    public bool RealTimeProtectionEnabled => _realTimeProtectionEnabled;

    public AntiVirusEngine()
    {
        _fileScanner = new FileScanner();
        _processScanner = new ProcessScanner();
        _quarantineManager = new QuarantineManager();
    }

    public async Task<List<ThreatDetectionResult>> ScanDirectoryAsync(string directoryPath, bool recursive = true)
    {
        _isScanning = true;
        var allResults = new List<ThreatDetectionResult>();

        try
        {
            OnScanProgress($"Tarama başlatılıyor: {directoryPath}");

            var results = await Task.Run(() => 
                _fileScanner.ScanDirectory(directoryPath, recursive));

            allResults.AddRange(results);

            foreach (var result in results)
            {
                if (result.IsThreat)
                {
                    OnThreatDetected(result);
                }
            }

            OnScanProgress("Dosya taraması tamamlandı");
        }
        catch (Exception ex)
        {
            OnScanProgress($"Tarama hatası: {ex.Message}");
        }
        finally
        {
            _isScanning = false;
            OnScanCompleted(new ScanCompletedEventArgs
            {
                ThreatsFound = allResults.Count(r => r.IsThreat),
                TotalScanned = allResults.Count
            });
        }

        return allResults;
    }

    public async Task<List<ThreatDetectionResult>> ScanProcessesAsync()
    {
        _isScanning = true;
        var results = new List<ThreatDetectionResult>();

        try
        {
            OnScanProgress("Süreç taraması başlatılıyor...");

            results = await Task.Run(() => _processScanner.ScanRunningProcesses());

            foreach (var result in results)
            {
                if (result.IsThreat)
                {
                    OnThreatDetected(result);
                }
            }

            OnScanProgress("Süreç taraması tamamlandı");
        }
        catch (Exception ex)
        {
            OnScanProgress($"Süreç taraması hatası: {ex.Message}");
        }
        finally
        {
            _isScanning = false;
            OnScanCompleted(new ScanCompletedEventArgs
            {
                ThreatsFound = results.Count(r => r.IsThreat),
                TotalScanned = results.Count
            });
        }

        return results;
    }

    public async Task<List<ThreatDetectionResult>> FullScanAsync()
    {
        _isScanning = true;
        var allResults = new List<ThreatDetectionResult>();

        try
        {
            OnScanProgress("Tam tarama başlatılıyor...");

            // Süreç taraması
            var processResults = await ScanProcessesAsync();
            allResults.AddRange(processResults);

            // Sistem dizinleri taraması
            var systemDirs = new[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

            foreach (var dir in systemDirs)
            {
                if (Directory.Exists(dir))
                {
                    OnScanProgress($"Taranıyor: {dir}");
                    var dirResults = await ScanDirectoryAsync(dir, true);
                    allResults.AddRange(dirResults);
                }
            }

            OnScanProgress("Tam tarama tamamlandı");
        }
        catch (Exception ex)
        {
            OnScanProgress($"Tam tarama hatası: {ex.Message}");
        }
        finally
        {
            _isScanning = false;
            OnScanCompleted(new ScanCompletedEventArgs
            {
                ThreatsFound = allResults.Count(r => r.IsThreat),
                TotalScanned = allResults.Count
            });
        }

        return allResults;
    }

    public bool QuarantineThreat(ThreatDetectionResult threat)
    {
        if (!threat.IsThreat)
            return false;

        if (!string.IsNullOrEmpty(threat.FilePath) && File.Exists(threat.FilePath))
        {
            return _quarantineManager.QuarantineFile(threat.FilePath, threat);
        }

        if (threat.ProcessId > 0)
        {
            return _quarantineManager.TerminateProcess(threat.ProcessId);
        }

        return false;
    }

    public void EnableRealTimeProtection()
    {
        _realTimeProtectionEnabled = true;
        // Gerçek zamanlı koruma başlatılabilir (örnek: FileSystemWatcher)
    }

    public void DisableRealTimeProtection()
    {
        _realTimeProtectionEnabled = false;
    }

    protected virtual void OnThreatDetected(ThreatDetectionResult threat)
    {
        ThreatDetected?.Invoke(this, threat);
    }

    protected virtual void OnScanProgress(string message)
    {
        ScanProgress?.Invoke(this, message);
    }

    protected virtual void OnScanCompleted(ScanCompletedEventArgs e)
    {
        ScanCompleted?.Invoke(this, e);
    }
}

public class ScanCompletedEventArgs : EventArgs
{
    public int ThreatsFound { get; set; }
    public int TotalScanned { get; set; }
}

