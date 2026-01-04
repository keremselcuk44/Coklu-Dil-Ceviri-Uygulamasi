using TranslationAutomation.Configuration;
using TranslationAutomation.Models;
using TranslationAutomation.Services;

namespace TranslationAutomation.Forms;

public partial class MainForm : Form
{
    private TranslationService? _translationService;
    private readonly AppConfig _config;
    private readonly Dictionary<string, string> _languageMap;

    public MainForm()
    {
        InitializeComponent();
        _config = AppConfig.Load();
        _languageMap = LoadLanguageMap();

        // Dil listelerini doldur
        PopulateLanguageComboBoxes();

        // API servisini başlat
        if (ValidateApiKey())
        {
            _translationService = new TranslationService(
                _config.TranslationApi.ApiKey,
                _config.TranslationApi.ApiUrl,
                _config.TranslationApi.Region,
                _config.TranslationApi.ApiVersion
            );
            UpdateStatus("Hazır - API bağlantısı aktif");
        }
        else
        {
            UpdateStatus("⚠️ API anahtarı bulunamadı! Ayarlar menüsünden API anahtarınızı girin.");
            btnTranslate.Enabled = false;
            btnDetectLanguage.Enabled = false;
        }
    }

    private Dictionary<string, string> LoadLanguageMap()
    {
        return new Dictionary<string, string>
        {
            { "tr", "Türkçe" },
            { "en", "İngilizce" },
            { "de", "Almanca" },
            { "fr", "Fransızca" },
            { "es", "İspanyolca" },
            { "it", "İtalyanca" },
            { "ru", "Rusça" },
            { "ar", "Arapça" },
            { "ja", "Japonca" },
            { "zh", "Çince" },
            { "ko", "Korece" },
            { "pt", "Portekizce" },
            { "nl", "Felemenkçe" },
            { "pl", "Lehçe" },
            { "sv", "İsveççe" },
            { "da", "Danca" },
            { "fi", "Fince" },
            { "no", "Norveççe" },
            { "cs", "Çekçe" },
            { "hu", "Macarca" },
            { "ro", "Romence" },
            { "bg", "Bulgarca" },
            { "hr", "Hırvatça" },
            { "sk", "Slovakça" },
            { "sl", "Slovence" },
            { "el", "Yunanca" },
            { "he", "İbranice" },
            { "th", "Tayca" },
            { "vi", "Vietnamca" },
            { "id", "Endonezce" },
            { "ms", "Malayca" }
        };
    }

    private void PopulateLanguageComboBoxes()
    {
        cmbSourceLanguage.Items.Clear();
        clbTargetLanguages.Items.Clear();

        foreach (var lang in _languageMap)
        {
            cmbSourceLanguage.Items.Add($"{lang.Key} - {lang.Value}");
            clbTargetLanguages.Items.Add($"{lang.Key} - {lang.Value}");
        }

        // Varsayılan olarak Türkçe'yi seç
        cmbSourceLanguage.SelectedIndex = 0;
    }

    private bool ValidateApiKey()
    {
        return !string.IsNullOrEmpty(_config.TranslationApi.ApiKey) &&
               !_config.TranslationApi.ApiKey.Contains("BURAYA_API_ANAHTARINIZI_GIRIN") &&
               !_config.TranslationApi.ApiKey.Contains("YOUR_API_KEY_HERE");
    }

    private void UpdateStatus(string message)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => lblStatus.Text = message));
        }
        else
        {
            lblStatus.Text = message;
        }
    }

    private void ShowProgress(bool show)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() =>
            {
                progressBar.Visible = show;
                btnTranslate.Enabled = !show;
            }));
        }
        else
        {
            progressBar.Visible = show;
            btnTranslate.Enabled = !show;
        }
    }

    private async void BtnDetectLanguage_Click(object? sender, EventArgs e)
    {
        if (_translationService == null)
        {
            MessageBox.Show("API anahtarı bulunamadı. Lütfen ayarlardan API anahtarınızı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var text = txtSourceText.Text.Trim();
        if (string.IsNullOrWhiteSpace(text))
        {
            MessageBox.Show("Lütfen algılanacak bir metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        UpdateStatus("Dil algılanıyor...");
        ShowProgress(true);

        try
        {
            var detectedLang = await _translationService.DetectLanguageAsync(text);
            if (detectedLang != null)
            {
                // Algılanan dili combo box'ta seç
                for (int i = 0; i < cmbSourceLanguage.Items.Count; i++)
                {
                    var item = cmbSourceLanguage.Items[i]?.ToString();
                    if (item != null && item.StartsWith(detectedLang))
                    {
                        cmbSourceLanguage.SelectedIndex = i;
                        UpdateStatus($"✓ Dil algılandı: {detectedLang} - {_languageMap.GetValueOrDefault(detectedLang, "")}");
                        break;
                    }
                }
            }
            else
            {
                UpdateStatus("✗ Dil algılanamadı!");
                MessageBox.Show("Dil algılanamadı. Lütfen manuel olarak seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            UpdateStatus("Hata oluştu!");
            MessageBox.Show($"Dil algılama hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ShowProgress(false);
        }
    }

    private void BtnSelectAll_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < clbTargetLanguages.Items.Count; i++)
        {
            clbTargetLanguages.SetItemChecked(i, true);
        }
    }

    private void BtnDeselectAll_Click(object? sender, EventArgs e)
    {
        for (int i = 0; i < clbTargetLanguages.Items.Count; i++)
        {
            clbTargetLanguages.SetItemChecked(i, false);
        }
    }

    private async void BtnTranslate_Click(object? sender, EventArgs e)
    {
        if (_translationService == null)
        {
            MessageBox.Show("API anahtarı bulunamadı. Lütfen ayarlardan API anahtarınızı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var sourceText = txtSourceText.Text.Trim();
        if (string.IsNullOrWhiteSpace(sourceText))
        {
            MessageBox.Show("Lütfen çevrilecek bir metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cmbSourceLanguage.SelectedItem == null)
        {
            MessageBox.Show("Lütfen kaynak dili seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedTargetLanguages = clbTargetLanguages.CheckedItems.Cast<string>().ToList();
        if (selectedTargetLanguages.Count == 0)
        {
            MessageBox.Show("Lütfen en az bir hedef dil seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Dil kodlarını çıkar
        var sourceLang = cmbSourceLanguage.SelectedItem.ToString()?.Split(' ')[0] ?? "tr";
        var targetLangs = selectedTargetLanguages
            .Select(item => item.Split(' ')[0])
            .ToList();

        UpdateStatus($"Çeviri yapılıyor... ({targetLangs.Count} dil)");
        ShowProgress(true);
        txtResults.Clear();

        try
        {
            var results = await _translationService.TranslateToMultipleLanguagesAsync(
                sourceText,
                sourceLang,
                targetLangs
            );

            var resultText = new System.Text.StringBuilder();
            resultText.AppendLine("=== ÇEVİRİ SONUÇLARI ===\n");
            resultText.AppendLine($"Orijinal Metin ({sourceLang.ToUpper()}):");
            resultText.AppendLine($"{sourceText}\n");
            resultText.AppendLine(new string('=', 50));
            resultText.AppendLine();

            int successCount = 0;
            foreach (var result in results)
            {
                if (result.Success)
                {
                    var langName = _languageMap.GetValueOrDefault(result.TargetLanguage.ToLower(), result.TargetLanguage);
                    resultText.AppendLine($"✓ [{result.TargetLanguage.ToUpper()}] {langName}:");
                    resultText.AppendLine($"  {result.TranslatedText}\n");
                    successCount++;
                }
                else
                {
                    resultText.AppendLine($"✗ [{result.TargetLanguage.ToUpper()}] HATA:");
                    resultText.AppendLine($"  {result.ErrorMessage}\n");
                }
            }

            resultText.AppendLine(new string('=', 50));
            resultText.AppendLine($"\nToplam: {successCount}/{results.Count} çeviri başarılı");

            txtResults.Text = resultText.ToString();
            UpdateStatus($"✓ Çeviri tamamlandı! ({successCount}/{results.Count} başarılı)");

            if (successCount < results.Count)
            {
                MessageBox.Show($"Çeviri tamamlandı ancak bazı dillerde hata oluştu.\nBaşarılı: {successCount}/{results.Count}", 
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            UpdateStatus("Hata oluştu!");
            MessageBox.Show($"Çeviri hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtResults.Text = $"HATA: {ex.Message}";
        }
        finally
        {
            ShowProgress(false);
        }
    }

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        txtSourceText.Clear();
        txtResults.Clear();
        UpdateStatus("Temizlendi");
    }

    private void BtnSettings_Click(object? sender, EventArgs e)
    {
        using var settingsForm = new SettingsForm(_config);
        if (settingsForm.ShowDialog() == DialogResult.OK)
        {
            // API anahtarını yeniden kontrol et
            if (ValidateApiKey())
            {
                _translationService = new TranslationService(
                    _config.TranslationApi.ApiKey,
                    _config.TranslationApi.ApiUrl,
                    _config.TranslationApi.Region,
                    _config.TranslationApi.ApiVersion
                );
                btnTranslate.Enabled = true;
                btnDetectLanguage.Enabled = true;
                UpdateStatus("Hazır - API bağlantısı aktif");
            }
            else
            {
                UpdateStatus("⚠️ API anahtarı bulunamadı!");
                btnTranslate.Enabled = false;
                btnDetectLanguage.Enabled = false;
            }
        }
    }
}
