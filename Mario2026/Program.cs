namespace Mario2026
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // e.g. force French for this session:
            // Thread.CurrentThread.CurrentUICulture
            //     = new CultureInfo("nl-BE");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // If you want to use the settings, uncomment the following line:
            // Properties.Settings.Default.IsUpgraded = true;
            Properties.Settings.Default.IsUpgraded = true; // Set to true to indicate settings have been upgraded

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMario());
        }
    }
}

