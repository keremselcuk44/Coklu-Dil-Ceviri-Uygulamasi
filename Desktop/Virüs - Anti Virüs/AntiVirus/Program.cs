using AntiVirus.Core;

namespace AntiVirus;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Yönetici yetkisi kontrolü
        if (!IsAdministrator())
        {
            MessageBox.Show(
                "Bu uygulama yönetici yetkisi gerektirir. Lütfen yönetici olarak çalıştırın.",
                "Yetki Hatası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }

    private static bool IsAdministrator()
    {
        try
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }
        catch
        {
            return false;
        }
    }
}

