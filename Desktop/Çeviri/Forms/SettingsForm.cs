using System.Text;
using Newtonsoft.Json;
using TranslationAutomation.Configuration;

namespace TranslationAutomation.Forms;

public partial class SettingsForm : Form
{
    private readonly AppConfig _config;

    public SettingsForm(AppConfig config)
    {
        InitializeComponent();
        _config = config;
        LoadSettings();
    }

    private void LoadSettings()
    {
        txtApiKey.Text = _config.TranslationApi.ApiKey;
        txtApiUrl.Text = _config.TranslationApi.ApiUrl;
        txtRegion.Text = _config.TranslationApi.Region;
        txtApiVersion.Text = _config.TranslationApi.ApiVersion;
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtApiKey.Text))
        {
            MessageBox.Show("API anahtarı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // appsettings.json dosyasını güncelle
            var settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            
            var settings = new
            {
                TranslationApi = new
                {
                    ApiKey = txtApiKey.Text.Trim(),
                    ApiUrl = txtApiUrl.Text.Trim(),
                    Region = txtRegion.Text.Trim(),
                    ApiVersion = txtApiVersion.Text.Trim()
                }
            };

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(settingsPath, json, Encoding.UTF8);

            // Config'i güncelle
            _config.TranslationApi.ApiKey = txtApiKey.Text.Trim();
            _config.TranslationApi.ApiUrl = txtApiUrl.Text.Trim();
            _config.TranslationApi.Region = txtRegion.Text.Trim();
            _config.TranslationApi.ApiVersion = txtApiVersion.Text.Trim();

            MessageBox.Show("Ayarlar başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ayarlar kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void LinkLabelHelp_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://portal.azure.com",
                UseShellExecute = true
            });
        }
        catch
        {
            MessageBox.Show(
                "Azure Portal'a gitmek için:\n" +
                "1. https://portal.azure.com adresini tarayıcınızda açın\n" +
                "2. 'Create a resource' → 'Translator' arayın\n" +
                "3. Translator kaynağını oluşturun\n" +
                "4. 'Keys and Endpoint' bölümünden API anahtarınızı kopyalayın",
                "API Anahtarı Nasıl Alınır?",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
