using System.Text.Json;
using System.IO;
using System;

namespace Task2SteamTests
{
    public static class TestSettingsProvider
    {
        private static readonly string settingsFilename = "configsettings.json";

        public static string GetLocalization()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration/", settingsFilename);
            string temp = File.ReadAllText(path);

            return JsonSerializer.Deserialize<JsonElement>(temp).GetProperty("BrowserLocalization").GetString();
        }
        public static string GetAppUrl()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configuration/", settingsFilename);
            string temp = File.ReadAllText(path);

            return JsonSerializer.Deserialize<JsonElement>(temp).GetProperty("AppUrl").GetString();
        }
    }
}
