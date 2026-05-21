using Escape_Room_Digital;

namespace Escape_Room_Digital
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AdministradorLenguaje.CargarTraducciones("Languages/es.json");

                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}