namespace TranslationAutomation.Models;

public class TranslationRequest
{
    public string Text { get; set; } = string.Empty;
    public string SourceLanguage { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
}

public class TranslationResponse
{
    public string OriginalText { get; set; } = string.Empty;
    public string TranslatedText { get; set; } = string.Empty;
    public string SourceLanguage { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

public class BatchTranslationRequest
{
    public List<string> Texts { get; set; } = new();
    public string SourceLanguage { get; set; } = string.Empty;
    public List<string> TargetLanguages { get; set; } = new();
}

public class BatchTranslationResponse
{
    public List<TranslationResponse> Translations { get; set; } = new();
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}



