namespace AntiVirus.Core;

/// <summary>
/// Tehdit tespit sonucu
/// </summary>
public class ThreatDetectionResult
{
    public bool IsThreat { get; set; }
    public ThreatSignature? DetectedSignature { get; set; }
    public string ThreatName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string ProcessName { get; set; } = string.Empty;
    public int ProcessId { get; set; }
    public string Details { get; set; } = string.Empty;
    public DateTime DetectedAt { get; set; } = DateTime.Now;
    public DetectionMethod Method { get; set; }
}

public enum DetectionMethod
{
    SignatureBased,
    BehaviorBased,
    Heuristic,
    ProcessMonitoring
}

