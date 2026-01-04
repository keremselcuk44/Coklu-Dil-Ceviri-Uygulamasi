using System.Text;

namespace AntiVirus.Core;

/// <summary>
/// Tehdit imza veritabanı (Eğitim amaçlı)
/// </summary>
public static class SignatureDatabase
{
    private static readonly List<ThreatSignature> _signatures = new();

    static SignatureDatabase()
    {
        InitializeSignatures();
    }

    private static void InitializeSignatures()
    {
        // KeyLogger tehdit imzaları
        var keyloggerSignature = new ThreatSignature
        {
            Name = "KeyLogger",
            Description = "Klavye girdilerini kaydeden zararlı yazılım",
            Type = ThreatType.Keylogger,
            Severity = SeverityLevel.Critical,
            ProcessNames = new List<string>
            {
                "KeyLogger",
                "KeyLogger.exe",
                "kl.exe",
                "keylog"
            },
            FileNames = new List<string>
            {
                "KeyLogger.exe",
                "kl.exe",
                "keylog.txt",
                "keys.log",
                "captured.txt"
            },
            SuspiciousStrings = new List<string>
            {
                "SetWindowsHookEx",
                "WH_KEYBOARD_LL",
                "WH_KEYBOARD",
                "GetAsyncKeyState",
                "keylog",
                "KeyLogger",
                "capture keystrokes",
                "log keys"
            },
            RegistryKeys = new List<string>
            {
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\KeyLogger",
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\RunServices\KeyLogger"
            }
        };

        _signatures.Add(keyloggerSignature);

        // Genel keylogger davranış imzaları
        var genericKeylogger = new ThreatSignature
        {
            Name = "Generic Keylogger",
            Description = "Genel keylogger davranış desenleri",
            Type = ThreatType.Keylogger,
            Severity = SeverityLevel.High,
            SuspiciousStrings = new List<string>
            {
                "DLLImport",
                "user32.dll",
                "GetKeyState",
                "GetKeyboardState",
                "MapVirtualKey"
            }
        };

        _signatures.Add(genericKeylogger);
    }

    public static List<ThreatSignature> GetSignatures()
    {
        return _signatures.ToList();
    }

    public static List<ThreatSignature> GetSignaturesByType(ThreatType type)
    {
        return _signatures.Where(s => s.Type == type).ToList();
    }

    public static bool ContainsSuspiciousString(string content)
    {
        if (string.IsNullOrEmpty(content))
            return false;

        var lowerContent = content.ToLower();
        return _signatures.Any(sig => 
            sig.SuspiciousStrings.Any(str => 
                lowerContent.Contains(str.ToLower())));
    }
}

