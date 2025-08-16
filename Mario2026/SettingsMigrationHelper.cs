using System.Xml.Linq;

namespace Mario2026
{
    public static class SettingsMigrationHelper
    {
        public static void MigrateSettings()
        {
            try
            {
                var settings = Properties.Settings.Default;

                // Only run if we haven't yet migrated in this version
                if (!settings.IsUpgraded)
                {
                    // Try normal Upgrade() first
                    settings.Upgrade();

                    // If still empty or missing key values, try manual migration
                    if (NeedsManualMigration(settings))
                    {
                        // Safely retrieve and validate "UserSettingsPath"
                        if (settings.Context?["UserSettingsPath"] is string userSettingsPath)
                        {
                            string? currentDir = Path.GetDirectoryName(userSettingsPath);
                            if (currentDir != null)
                            {
                                string? parentDir = Directory.GetParent(currentDir)?.FullName;

                                if (parentDir != null)
                                {
                                    // Find all version folders except current
                                    var candidates = Directory.GetDirectories(parentDir)
                                        .Where(d => d != currentDir)
                                        .OrderByDescending(d => d) // latest first
                                        .ToList();

                                    foreach (var dir in candidates)
                                    {
                                        string userConfig = Path.Combine(dir, "user.config");
                                        if (File.Exists(userConfig))
                                        {
                                            MergeConfig(userConfig, settings);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    settings.IsUpgraded = true;
                    settings.Save();
                }
            }
            catch (Exception ex)
            {
                // Log or ignore as appropriate
                Console.WriteLine($"Settings migration failed: {ex}");
            }
        }

        private static bool NeedsManualMigration(Properties.Settings settings)
        {
            // Example heuristic: check if a known setting is still default
            return string.IsNullOrEmpty(settings["SomeImportantSetting"]?.ToString());
        }

        private static void MergeConfig(string oldConfigPath, Properties.Settings settings)
        {
            var xml = XDocument.Load(oldConfigPath);
            var values = xml.Descendants("setting")
                            .Where(el => el.Attribute("name")?.Value != null) // Ensure non-null keys
                            .ToDictionary(
                                el => el.Attribute("name")!.Value, // Use null-forgiving operator
                                el => el.Value
                            );

            foreach (var kvp in values)
            {
                if (settings.Properties[kvp.Key] != null)
                {
                    try
                    {
                        settings[kvp.Key] = Convert.ChangeType(
                            kvp.Value,
                            settings[kvp.Key]?.GetType() ?? typeof(string)
                        );
                    }
                    catch { /* skip invalid */ }
                }
            }
        }
    }
}


