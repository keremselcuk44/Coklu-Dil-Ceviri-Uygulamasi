using AntiVirus.Core;
using System.Diagnostics;

namespace AntiVirus;

public partial class MainForm : Form
{
    private AntiVirusEngine _engine;
    private List<ThreatDetectionResult> _detectedThreats;
    private bool _isScanning;

    public MainForm()
    {
        InitializeComponent();
        _engine = new AntiVirusEngine();
        _detectedThreats = new List<ThreatDetectionResult>();
        
        _engine.ThreatDetected += Engine_ThreatDetected;
        _engine.ScanProgress += Engine_ScanProgress;
        _engine.ScanCompleted += Engine_ScanCompleted;

        UpdateUI();
    }

    private void InitializeComponent()
    {
        this.Text = "AntiVirus - KeyLogger Tespit Sistemi (Eğitim Amaçlı)";
        this.Size = new Size(900, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        // Ana panel
        var mainPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(10)
        };

        // Başlık
        var titleLabel = new Label
        {
            Text = "🛡️ AntiVirus - KeyLogger Tespit Sistemi",
            Font = new Font("Segoe UI", 16, FontStyle.Bold),
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Height = 50
        };

        // Buton paneli
        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            Height = 60
        };

        btnScanProcesses = new Button
        {
            Text = "Süreçleri Tara",
            Size = new Size(150, 40),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnScanProcesses.Click += BtnScanProcesses_Click;

        btnScanDirectory = new Button
        {
            Text = "Klasör Tara",
            Size = new Size(150, 40),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnScanDirectory.Click += BtnScanDirectory_Click;

        btnFullScan = new Button
        {
            Text = "Tam Tarama",
            Size = new Size(150, 40),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnFullScan.Click += BtnFullScan_Click;

        btnQuarantine = new Button
        {
            Text = "Tehdidi Karantinaya Al",
            Size = new Size(180, 40),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(220, 53, 69),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Enabled = false
        };
        btnQuarantine.Click += BtnQuarantine_Click;

        btnRealTimeProtection = new Button
        {
            Text = "Gerçek Zamanlı Koruma: Kapalı",
            Size = new Size(200, 40),
            Font = new Font("Segoe UI", 10),
            BackColor = Color.FromArgb(108, 117, 125),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        btnRealTimeProtection.Click += BtnRealTimeProtection_Click;

        buttonPanel.Controls.Add(btnScanProcesses);
        buttonPanel.Controls.Add(btnScanDirectory);
        buttonPanel.Controls.Add(btnFullScan);
        buttonPanel.Controls.Add(btnQuarantine);
        buttonPanel.Controls.Add(btnRealTimeProtection);

        // Sonuçlar paneli
        var resultsPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1
        };

        // Tehdit listesi
        var threatsGroup = new GroupBox
        {
            Text = "Tespit Edilen Tehditler",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };

        listViewThreats = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            GridLines = true
        };
        listViewThreats.Columns.Add("Tehdit Adı", 150);
        listViewThreats.Columns.Add("Tür", 100);
        listViewThreats.Columns.Add("Dosya/Süreç", 250);
        listViewThreats.Columns.Add("Tespit Yöntemi", 120);
        listViewThreats.Columns.Add("Tarih", 150);
        listViewThreats.SelectedIndexChanged += ListViewThreats_SelectedIndexChanged;

        threatsGroup.Controls.Add(listViewThreats);

        // Log paneli
        var logGroup = new GroupBox
        {
            Text = "Tarama Logları",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 10, FontStyle.Bold)
        };

        textBoxLog = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical,
            Font = new Font("Consolas", 9)
        };

        logGroup.Controls.Add(textBoxLog);

        resultsPanel.Controls.Add(threatsGroup, 0, 0);
        resultsPanel.Controls.Add(logGroup, 1, 0);
        resultsPanel.SetColumnWidth(0, 50);
        resultsPanel.SetColumnWidth(1, 50);

        // Durum çubuğu
        statusLabel = new Label
        {
            Text = "Hazır",
            Dock = DockStyle.Fill,
            Height = 30,
            BackColor = Color.FromArgb(240, 240, 240),
            Padding = new Padding(10, 5, 10, 5),
            Font = new Font("Segoe UI", 9)
        };

        mainPanel.Controls.Add(titleLabel, 0, 0);
        mainPanel.Controls.Add(buttonPanel, 0, 1);
        mainPanel.Controls.Add(resultsPanel, 0, 2);
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70));
        mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        this.Controls.Add(mainPanel);
        this.Controls.Add(statusLabel);
    }

    private Button btnScanProcesses = null!;
    private Button btnScanDirectory = null!;
    private Button btnFullScan = null!;
    private Button btnQuarantine = null!;
    private Button btnRealTimeProtection = null!;
    private ListView listViewThreats = null!;
    private TextBox textBoxLog = null!;
    private Label statusLabel = null!;

    private async void BtnScanProcesses_Click(object? sender, EventArgs e)
    {
        if (_isScanning) return;

        _isScanning = true;
        UpdateUI();
        AddLog("Süreç taraması başlatılıyor...");
        _detectedThreats.Clear();
        listViewThreats.Items.Clear();

        var results = await _engine.ScanProcessesAsync();
        _detectedThreats.AddRange(results);

        _isScanning = false;
        UpdateUI();
    }

    private async void BtnScanDirectory_Click(object? sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = "Taranacak klasörü seçin"
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (_isScanning) return;

            _isScanning = true;
            UpdateUI();
            AddLog($"Klasör taraması başlatılıyor: {dialog.SelectedPath}");
            _detectedThreats.Clear();
            listViewThreats.Items.Clear();

            var results = await _engine.ScanDirectoryAsync(dialog.SelectedPath, true);

            _isScanning = false;
            UpdateUI();
        }
    }

    private async void BtnFullScan_Click(object? sender, EventArgs e)
    {
        if (_isScanning) return;

        var result = MessageBox.Show(
            "Tam tarama uzun sürebilir. Devam etmek istiyor musunuz?",
            "Tam Tarama",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        _isScanning = true;
        UpdateUI();
        AddLog("Tam tarama başlatılıyor...");
        _detectedThreats.Clear();
        listViewThreats.Items.Clear();

        var results = await _engine.FullScanAsync();

        _isScanning = false;
        UpdateUI();
    }

    private void BtnQuarantine_Click(object? sender, EventArgs e)
    {
        if (listViewThreats.SelectedItems.Count == 0)
        {
            MessageBox.Show("Lütfen karantinaya alınacak bir tehdit seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedIndex = listViewThreats.SelectedIndices[0];
        if (selectedIndex >= 0 && selectedIndex < _detectedThreats.Count)
        {
            var threat = _detectedThreats[selectedIndex];
            var result = MessageBox.Show(
                $"'{threat.ThreatName}' tehdidini karantinaya almak istediğinizden emin misiniz?",
                "Karantina",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (_engine.QuarantineThreat(threat))
                {
                    AddLog($"Tehdit karantinaya alındı: {threat.ThreatName}");
                    MessageBox.Show("Tehdit başarıyla karantinaya alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Listeden kaldır
                    listViewThreats.Items.RemoveAt(selectedIndex);
                    _detectedThreats.RemoveAt(selectedIndex);
                }
                else
                {
                    MessageBox.Show("Tehdit karantinaya alınamadı. Yönetici yetkisi gerekebilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void BtnRealTimeProtection_Click(object? sender, EventArgs e)
    {
        if (_engine.RealTimeProtectionEnabled)
        {
            _engine.DisableRealTimeProtection();
            btnRealTimeProtection.Text = "Gerçek Zamanlı Koruma: Kapalı";
            btnRealTimeProtection.BackColor = Color.FromArgb(108, 117, 125);
            AddLog("Gerçek zamanlı koruma kapatıldı.");
        }
        else
        {
            _engine.EnableRealTimeProtection();
            btnRealTimeProtection.Text = "Gerçek Zamanlı Koruma: Açık";
            btnRealTimeProtection.BackColor = Color.FromArgb(40, 167, 69);
            AddLog("Gerçek zamanlı koruma açıldı.");
        }
    }

    private void Engine_ThreatDetected(object? sender, ThreatDetectionResult threat)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Engine_ThreatDetected(sender, threat)));
            return;
        }

        _detectedThreats.Add(threat);

        var item = new ListViewItem(threat.ThreatName);
        item.SubItems.Add(threat.DetectedSignature?.Type.ToString() ?? "Bilinmiyor");
        item.SubItems.Add(string.IsNullOrEmpty(threat.FilePath) ? threat.ProcessName : threat.FilePath);
        item.SubItems.Add(threat.Method.ToString());
        item.SubItems.Add(threat.DetectedAt.ToString("yyyy-MM-dd HH:mm:ss"));
        item.Tag = threat;

        if (threat.DetectedSignature?.Severity == SeverityLevel.Critical)
        {
            item.BackColor = Color.FromArgb(255, 200, 200);
        }
        else if (threat.DetectedSignature?.Severity == SeverityLevel.High)
        {
            item.BackColor = Color.FromArgb(255, 230, 200);
        }

        listViewThreats.Items.Add(item);
        AddLog($"⚠️ TEHDİT TESPİT EDİLDİ: {threat.ThreatName} - {threat.Details}");
    }

    private void Engine_ScanProgress(object? sender, string message)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Engine_ScanProgress(sender, message)));
            return;
        }

        AddLog(message);
        statusLabel.Text = message;
    }

    private void Engine_ScanCompleted(object? sender, ScanCompletedEventArgs e)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => Engine_ScanCompleted(sender, e)));
            return;
        }

        AddLog($"Tarama tamamlandı. {e.ThreatsFound} tehdit bulundu, {e.TotalScanned} öğe taranı.");
        statusLabel.Text = $"Tarama tamamlandı. {e.ThreatsFound} tehdit bulundu.";
    }

    private void ListViewThreats_SelectedIndexChanged(object? sender, EventArgs e)
    {
        btnQuarantine.Enabled = listViewThreats.SelectedItems.Count > 0;
    }

    private void AddLog(string message)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => AddLog(message)));
            return;
        }

        textBoxLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
        textBoxLog.SelectionStart = textBoxLog.Text.Length;
        textBoxLog.ScrollToCaret();
    }

    private void UpdateUI()
    {
        btnScanProcesses.Enabled = !_isScanning;
        btnScanDirectory.Enabled = !_isScanning;
        btnFullScan.Enabled = !_isScanning;
        btnQuarantine.Enabled = !_isScanning && listViewThreats.SelectedItems.Count > 0;
    }
}

