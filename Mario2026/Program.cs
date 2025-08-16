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
            SettingsMigrationHelper.MigrateSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMario ());
        }
    }
}

