namespace AntiVirus.Core;

/// <summary>
/// Tehdit imzası tanımları (Eğitim amaçlı)
/// </summary>
public class ThreatSignature
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ThreatType Type { get; set; }
    public List<string> ProcessNames { get; set; } = new();
    public List<string> FileNames { get; set; } = new();
    public List<string> RegistryKeys { get; set; } = new();
    public List<byte[]> FileSignatures { get; set; } = new();
    public List<string> SuspiciousStrings { get; set; } = new();
    public SeverityLevel Severity { get; set; }
}

public enum ThreatType
{
    Keylogger,
    Trojan,
    Malware,
    Spyware
}

public enum SeverityLevel
{
    Low,
    Medium,
    High,
    Critical
}

