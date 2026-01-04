using Microsoft.Extensions.Configuration;

namespace TranslationAutomation.Configuration;

public class AppConfig
{
    public TranslationApiConfig TranslationApi { get; set; } = new();
    public Dictionary<string, string> SupportedLanguages { get; set; } = new();

    public static AppConfig Load()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.example.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();
        var appConfig = new AppConfig();

        configuration.GetSection("TranslationApi").Bind(appConfig.TranslationApi);
        configuration.GetSection("SupportedLanguages").Bind(appConfig.SupportedLanguages);

        return appConfig;
    }
}

public class TranslationApiConfig
{
    public string ApiKey { get; set; } = string.Empty;
    public string ApiUrl { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string ApiVersion { get; set; } = string.Empty;
}



