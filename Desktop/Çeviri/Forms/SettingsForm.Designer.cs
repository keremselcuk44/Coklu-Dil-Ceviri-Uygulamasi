#nullable disable
namespace TranslationAutomation.Forms;

partial class SettingsForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblApiKey;
    private TextBox txtApiKey;
    private Label lblApiUrl;
    private TextBox txtApiUrl;
    private Label lblRegion;
    private TextBox txtRegion;
    private Label lblApiVersion;
    private TextBox txtApiVersion;
    private Button btnSave;
    private Button btnCancel;
    private LinkLabel linkLabelHelp;
    private Label lblInfo;

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
        this.lblApiKey = new Label();
        this.txtApiKey = new TextBox();
        this.lblApiUrl = new Label();
        this.txtApiUrl = new TextBox();
        this.lblRegion = new Label();
        this.txtRegion = new TextBox();
        this.lblApiVersion = new Label();
        this.txtApiVersion = new TextBox();
        this.btnSave = new Button();
        this.btnCancel = new Button();
        this.linkLabelHelp = new LinkLabel();
        this.lblInfo = new Label();
        this.SuspendLayout();
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(20, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(203, 25);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "⚙️ API Ayarları";
        // 
        // lblApiKey
        // 
        this.lblApiKey.AutoSize = true;
        this.lblApiKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblApiKey.Location = new System.Drawing.Point(20, 70);
        this.lblApiKey.Name = "lblApiKey";
        this.lblApiKey.Size = new System.Drawing.Size(96, 19);
        this.lblApiKey.TabIndex = 1;
        this.lblApiKey.Text = "API Anahtarı:";
        // 
        // txtApiKey
        // 
        this.txtApiKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtApiKey.Location = new System.Drawing.Point(20, 95);
        this.txtApiKey.Name = "txtApiKey";
        this.txtApiKey.PasswordChar = '*';
        this.txtApiKey.Size = new System.Drawing.Size(540, 23);
        this.txtApiKey.TabIndex = 2;
        // 
        // lblApiUrl
        // 
        this.lblApiUrl.AutoSize = true;
        this.lblApiUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblApiUrl.Location = new System.Drawing.Point(20, 135);
        this.lblApiUrl.Name = "lblApiUrl";
        this.lblApiUrl.Size = new System.Drawing.Size(71, 19);
        this.lblApiUrl.TabIndex = 3;
        this.lblApiUrl.Text = "API URL:";
        // 
        // txtApiUrl
        // 
        this.txtApiUrl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtApiUrl.Location = new System.Drawing.Point(20, 160);
        this.txtApiUrl.Name = "txtApiUrl";
        this.txtApiUrl.Size = new System.Drawing.Size(540, 23);
        this.txtApiUrl.TabIndex = 3;
        // 
        // lblRegion
        // 
        this.lblRegion.AutoSize = true;
        this.lblRegion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblRegion.Location = new System.Drawing.Point(20, 200);
        this.lblRegion.Name = "lblRegion";
        this.lblRegion.Size = new System.Drawing.Size(66, 19);
        this.lblRegion.TabIndex = 5;
        this.lblRegion.Text = "Region:";
        // 
        // txtRegion
        // 
        this.txtRegion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtRegion.Location = new System.Drawing.Point(20, 225);
        this.txtRegion.Name = "txtRegion";
        this.txtRegion.Size = new System.Drawing.Size(540, 23);
        this.txtRegion.TabIndex = 4;
        // 
        // lblApiVersion
        // 
        this.lblApiVersion.AutoSize = true;
        this.lblApiVersion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblApiVersion.Location = new System.Drawing.Point(20, 265);
        this.lblApiVersion.Name = "lblApiVersion";
        this.lblApiVersion.Size = new System.Drawing.Size(95, 19);
        this.lblApiVersion.TabIndex = 7;
        this.lblApiVersion.Text = "API Versiyonu:";
        // 
        // txtApiVersion
        // 
        this.txtApiVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.txtApiVersion.Location = new System.Drawing.Point(20, 290);
        this.txtApiVersion.Name = "txtApiVersion";
        this.txtApiVersion.Size = new System.Drawing.Size(540, 23);
        this.txtApiVersion.TabIndex = 5;
        // 
        // btnSave
        // 
        this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(380, 380);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(90, 35);
        this.btnSave.TabIndex = 6;
        this.btnSave.Text = "Kaydet";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += this.BtnSave_Click;
        // 
        // btnCancel
        // 
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.btnCancel.Location = new System.Drawing.Point(480, 380);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(80, 35);
        this.btnCancel.TabIndex = 7;
        this.btnCancel.Text = "İptal";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += this.BtnCancel_Click;
        // 
        // linkLabelHelp
        // 
        this.linkLabelHelp.AutoSize = true;
        this.linkLabelHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.linkLabelHelp.Location = new System.Drawing.Point(20, 330);
        this.linkLabelHelp.Name = "linkLabelHelp";
        this.linkLabelHelp.Size = new System.Drawing.Size(348, 15);
        this.linkLabelHelp.TabIndex = 10;
        this.linkLabelHelp.TabStop = true;
        this.linkLabelHelp.Text = "API anahtarı nasıl alınır? (Azure Portal)";
        this.linkLabelHelp.LinkClicked += this.LinkLabelHelp_LinkClicked;
        // 
        // lblInfo
        // 
        this.lblInfo.AutoSize = true;
        this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        this.lblInfo.Location = new System.Drawing.Point(20, 355);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Size = new System.Drawing.Size(442, 15);
        this.lblInfo.TabIndex = 11;
        this.lblInfo.Text = "⚠️ Ayarlar appsettings.json dosyasına kaydedilir. API anahtarınızı güvenli tutun!";
        // 
        // SettingsForm
        // 
        this.AcceptButton = this.btnSave;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(580, 435);
        this.Controls.Add(this.lblInfo);
        this.Controls.Add(this.linkLabelHelp);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.txtApiVersion);
        this.Controls.Add(this.lblApiVersion);
        this.Controls.Add(this.txtRegion);
        this.Controls.Add(this.lblRegion);
        this.Controls.Add(this.txtApiUrl);
        this.Controls.Add(this.lblApiUrl);
        this.Controls.Add(this.txtApiKey);
        this.Controls.Add(this.lblApiKey);
        this.Controls.Add(this.lblTitle);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SettingsForm";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Ayarlar";
        this.ResumeLayout(false);
        this.PerformLayout();

    }
}
