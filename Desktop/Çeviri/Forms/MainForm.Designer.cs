#nullable disable
namespace TranslationAutomation.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblSourceText;
    private TextBox txtSourceText;
    private Label lblSourceLanguage;
    private ComboBox cmbSourceLanguage;
    private Button btnDetectLanguage;
    private Label lblTargetLanguages;
    private CheckedListBox clbTargetLanguages;
    private Button btnSelectAll;
    private Button btnDeselectAll;
    private Button btnTranslate;
    private Label lblResults;
    private RichTextBox txtResults;
    private Button btnClear;
    private Button btnSettings;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
    private ProgressBar progressBar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblTitle = new Label();
        this.lblSourceText = new Label();
        this.txtSourceText = new TextBox();
        this.lblSourceLanguage = new Label();
        this.cmbSourceLanguage = new ComboBox();
        this.btnDetectLanguage = new Button();
        this.lblTargetLanguages = new Label();
        this.clbTargetLanguages = new CheckedListBox();
        this.btnSelectAll = new Button();
        this.btnDeselectAll = new Button();
        this.btnTranslate = new Button();
        this.lblResults = new Label();
        this.txtResults = new RichTextBox();
        this.btnClear = new Button();
        this.btnSettings = new Button();
        this.statusStrip = new StatusStrip();
        this.lblStatus = new ToolStripStatusLabel();
        this.progressBar = new ProgressBar();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(320, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "🌍 Çoklu Dil Çevirisi Otomasyonu";
        // 
        // lblSourceText
        // 
        this.lblSourceText.AutoSize = true;
        this.lblSourceText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblSourceText.Location = new System.Drawing.Point(20, 70);
        this.lblSourceText.Name = "lblSourceText";
        this.lblSourceText.Size = new System.Drawing.Size(92, 19);
        this.lblSourceText.TabIndex = 1;
        this.lblSourceText.Text = "Kaynak Metin:";
        // 
        // txtSourceText
        // 
        this.txtSourceText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtSourceText.Location = new System.Drawing.Point(20, 95);
        this.txtSourceText.Multiline = true;
        this.txtSourceText.Name = "txtSourceText";
        this.txtSourceText.ScrollBars = ScrollBars.Vertical;
        this.txtSourceText.Size = new System.Drawing.Size(580, 120);
        this.txtSourceText.TabIndex = 2;
        // 
        // lblSourceLanguage
        // 
        this.lblSourceLanguage.AutoSize = true;
        this.lblSourceLanguage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblSourceLanguage.Location = new System.Drawing.Point(20, 230);
        this.lblSourceLanguage.Name = "lblSourceLanguage";
        this.lblSourceLanguage.Size = new System.Drawing.Size(95, 19);
        this.lblSourceLanguage.TabIndex = 3;
        this.lblSourceLanguage.Text = "Kaynak Dil:";
        // 
        // cmbSourceLanguage
        // 
        this.cmbSourceLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbSourceLanguage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.cmbSourceLanguage.FormattingEnabled = true;
        this.cmbSourceLanguage.Location = new System.Drawing.Point(20, 255);
        this.cmbSourceLanguage.Name = "cmbSourceLanguage";
        this.cmbSourceLanguage.Size = new System.Drawing.Size(200, 25);
        this.cmbSourceLanguage.TabIndex = 4;
        // 
        // btnDetectLanguage
        // 
        this.btnDetectLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnDetectLanguage.Location = new System.Drawing.Point(235, 253);
        this.btnDetectLanguage.Name = "btnDetectLanguage";
        this.btnDetectLanguage.Size = new System.Drawing.Size(150, 28);
        this.btnDetectLanguage.TabIndex = 5;
        this.btnDetectLanguage.Text = "🔍 Otomatik Algıla";
        this.btnDetectLanguage.UseVisualStyleBackColor = true;
        this.btnDetectLanguage.Click += this.BtnDetectLanguage_Click;
        // 
        // lblTargetLanguages
        // 
        this.lblTargetLanguages.AutoSize = true;
        this.lblTargetLanguages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTargetLanguages.Location = new System.Drawing.Point(20, 295);
        this.lblTargetLanguages.Name = "lblTargetLanguages";
        this.lblTargetLanguages.Size = new System.Drawing.Size(92, 19);
        this.lblTargetLanguages.TabIndex = 6;
        this.lblTargetLanguages.Text = "Hedef Diller:";
        // 
        // clbTargetLanguages
        // 
        this.clbTargetLanguages.CheckOnClick = true;
        this.clbTargetLanguages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.clbTargetLanguages.FormattingEnabled = true;
        this.clbTargetLanguages.Location = new System.Drawing.Point(20, 320);
        this.clbTargetLanguages.Name = "clbTargetLanguages";
        this.clbTargetLanguages.Size = new System.Drawing.Size(365, 184);
        this.clbTargetLanguages.TabIndex = 7;
        // 
        // btnSelectAll
        // 
        this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnSelectAll.Location = new System.Drawing.Point(395, 320);
        this.btnSelectAll.Name = "btnSelectAll";
        this.btnSelectAll.Size = new System.Drawing.Size(100, 30);
        this.btnSelectAll.TabIndex = 8;
        this.btnSelectAll.Text = "Tümünü Seç";
        this.btnSelectAll.UseVisualStyleBackColor = true;
        this.btnSelectAll.Click += this.BtnSelectAll_Click;
        // 
        // btnDeselectAll
        // 
        this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnDeselectAll.Location = new System.Drawing.Point(395, 360);
        this.btnDeselectAll.Name = "btnDeselectAll";
        this.btnDeselectAll.Size = new System.Drawing.Size(100, 30);
        this.btnDeselectAll.TabIndex = 9;
        this.btnDeselectAll.Text = "Tümünü Kaldır";
        this.btnDeselectAll.UseVisualStyleBackColor = true;
        this.btnDeselectAll.Click += this.BtnDeselectAll_Click;
        // 
        // btnTranslate
        // 
        this.btnTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        this.btnTranslate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnTranslate.ForeColor = System.Drawing.Color.White;
        this.btnTranslate.Location = new System.Drawing.Point(395, 410);
        this.btnTranslate.Name = "btnTranslate";
        this.btnTranslate.Size = new System.Drawing.Size(205, 45);
        this.btnTranslate.TabIndex = 10;
        this.btnTranslate.Text = "🚀 Çevir";
        this.btnTranslate.UseVisualStyleBackColor = false;
        this.btnTranslate.Click += this.BtnTranslate_Click;
        // 
        // lblResults
        // 
        this.lblResults.AutoSize = true;
        this.lblResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblResults.Location = new System.Drawing.Point(620, 70);
        this.lblResults.Name = "lblResults";
        this.lblResults.Size = new System.Drawing.Size(122, 19);
        this.lblResults.TabIndex = 11;
        this.lblResults.Text = "Çeviri Sonuçları:";
        // 
        // txtResults
        // 
        this.txtResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtResults.Location = new System.Drawing.Point(620, 95);
        this.txtResults.Name = "txtResults";
        this.txtResults.ReadOnly = true;
        this.txtResults.ScrollBars = RichTextBoxScrollBars.Vertical;
        this.txtResults.Size = new System.Drawing.Size(560, 409);
        this.txtResults.TabIndex = 12;
        // 
        // btnClear
        // 
        this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnClear.Location = new System.Drawing.Point(620, 510);
        this.btnClear.Name = "btnClear";
        this.btnClear.Size = new System.Drawing.Size(120, 35);
        this.btnClear.TabIndex = 13;
        this.btnClear.Text = "Temizle";
        this.btnClear.UseVisualStyleBackColor = true;
        this.btnClear.Click += this.BtnClear_Click;
        // 
        // btnSettings
        // 
        this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnSettings.Location = new System.Drawing.Point(750, 510);
        this.btnSettings.Name = "btnSettings";
        this.btnSettings.Size = new System.Drawing.Size(120, 35);
        this.btnSettings.TabIndex = 14;
        this.btnSettings.Text = "⚙️ Ayarlar";
        this.btnSettings.UseVisualStyleBackColor = true;
        this.btnSettings.Click += this.BtnSettings_Click;
        // 
        // statusStrip
        // 
        this.statusStrip.Items.AddRange(new ToolStripItem[] {
        this.lblStatus});
        this.statusStrip.Location = new System.Drawing.Point(0, 558);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1200, 22);
        this.statusStrip.TabIndex = 15;
        this.statusStrip.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(62, 17);
        this.lblStatus.Text = "Hazır";
        // 
        // progressBar
        // 
        this.progressBar.Location = new System.Drawing.Point(395, 470);
        this.progressBar.Name = "progressBar";
        this.progressBar.Size = new System.Drawing.Size(205, 23);
        this.progressBar.Style = ProgressBarStyle.Marquee;
        this.progressBar.TabIndex = 16;
        this.progressBar.Visible = false;
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1200, 580);
        this.Controls.Add(this.progressBar);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.btnSettings);
        this.Controls.Add(this.btnClear);
        this.Controls.Add(this.txtResults);
        this.Controls.Add(this.lblResults);
        this.Controls.Add(this.btnTranslate);
        this.Controls.Add(this.btnDeselectAll);
        this.Controls.Add(this.btnSelectAll);
        this.Controls.Add(this.clbTargetLanguages);
        this.Controls.Add(this.lblTargetLanguages);
        this.Controls.Add(this.btnDetectLanguage);
        this.Controls.Add(this.cmbSourceLanguage);
        this.Controls.Add(this.lblSourceLanguage);
        this.Controls.Add(this.txtSourceText);
        this.Controls.Add(this.lblSourceText);
        this.Controls.Add(this.lblTitle);
        this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = true;
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Çoklu Dil Çevirisi Otomasyonu";
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
