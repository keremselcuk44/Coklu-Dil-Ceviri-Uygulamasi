using System.Text;
using Newtonsoft.Json;
using TranslationAutomation.Models;

namespace TranslationAutomation.Services;

public class TranslationService
{
    private readonly string _apiKey;
    private readonly string _apiUrl;
    private readonly string _region;
    private readonly string _apiVersion;

    public TranslationService(string apiKey, string apiUrl, string region, string apiVersion)
    {
        _apiKey = apiKey;
        _apiUrl = apiUrl;
        _region = region;
        _apiVersion = apiVersion;
    }

    /// <summary>
    /// Tek bir metni belirli bir dile çevirir
    /// </summary>
    public async Task<TranslationResponse> TranslateAsync(TranslationRequest request)
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", _region);

            var route = $"/translate?api-version={_apiVersion}&from={request.SourceLanguage}&to={request.TargetLanguage}";
            var requestBody = JsonConvert.SerializeObject(new[] { new { Text = request.Text } });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiUrl + route, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new TranslationResponse
                {
                    OriginalText = request.Text,
                    SourceLanguage = request.SourceLanguage,
                    TargetLanguage = request.TargetLanguage,
                    Success = false,
                    ErrorMessage = $"API Hatası: {response.StatusCode} - {responseBody}"
                };
            }

            var result = JsonConvert.DeserializeObject<List<TranslationResult>>(responseBody);
            
            if (result == null || result.Count == 0 || result[0]?.Translations == null || result[0].Translations.Count == 0)
            {
                return new TranslationResponse
                {
                    OriginalText = request.Text,
                    SourceLanguage = request.SourceLanguage,
                    TargetLanguage = request.TargetLanguage,
                    Success = false,
                    ErrorMessage = "Çeviri sonucu alınamadı"
                };
            }

            return new TranslationResponse
            {
                OriginalText = request.Text,
                TranslatedText = result[0].Translations[0]?.Text ?? string.Empty,
                SourceLanguage = request.SourceLanguage,
                TargetLanguage = request.TargetLanguage,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new TranslationResponse
            {
                OriginalText = request.Text,
                SourceLanguage = request.SourceLanguage,
                TargetLanguage = request.TargetLanguage,
                Success = false,
                ErrorMessage = $"Hata: {ex.Message}"
            };
        }
    }

    /// <summary>
    /// Bir metni birden fazla dile çevirir
    /// </summary>
    public async Task<List<TranslationResponse>> TranslateToMultipleLanguagesAsync(string text, string sourceLanguage, List<string> targetLanguages)
    {
        var tasks = targetLanguages.Select(async targetLang =>
        {
            var request = new TranslationRequest
            {
                Text = text,
                SourceLanguage = sourceLanguage,
                TargetLanguage = targetLang
            };
            return await TranslateAsync(request);
        });

        return (await Task.WhenAll(tasks)).ToList();
    }

    /// <summary>
    /// Birden fazla metni birden fazla dile çevirir (toplu işlem)
    /// </summary>
    public async Task<BatchTranslationResponse> TranslateBatchAsync(BatchTranslationRequest request)
    {
        var allTranslations = new List<TranslationResponse>();

        foreach (var text in request.Texts)
        {
            var translations = await TranslateToMultipleLanguagesAsync(
                text,
                request.SourceLanguage,
                request.TargetLanguages
            );
            allTranslations.AddRange(translations);
        }

        return new BatchTranslationResponse
        {
            Translations = allTranslations,
            Success = allTranslations.All(t => t.Success)
        };
    }

    /// <summary>
    /// Dil kodunu algılar
    /// </summary>
    public async Task<string?> DetectLanguageAsync(string text)
    {
        try
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiKey);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", _region);

            var route = $"/detect?api-version={_apiVersion}";
            var requestBody = JsonConvert.SerializeObject(new[] { new { Text = text } });

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiUrl.Replace("/translate", "/detect") + route, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var result = JsonConvert.DeserializeObject<List<DetectionResult>>(responseBody);
            return result?.FirstOrDefault()?.Language;
        }
        catch
        {
            return null;
        }
    }

    private class TranslationResult
    {
        [JsonProperty("translations")]
        public List<TranslationItem>? Translations { get; set; }
    }

    private class TranslationItem
    {
        [JsonProperty("text")]
        public string Text { get; set; } = string.Empty;

        [JsonProperty("to")]
        public string To { get; set; } = string.Empty;
    }

    private class DetectionResult
    {
        [JsonProperty("language")]
        public string Language { get; set; } = string.Empty;

        [JsonProperty("score")]
        public double Score { get; set; }
    }
}



