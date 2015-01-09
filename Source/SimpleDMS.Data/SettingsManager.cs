using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SimpleDMS.Data
{
    public class SettingsManager
    {
        private const string SETTINGS_PATH = "SimpleDMS";
        private const string SETTINGS_FILE = "settings.cfg";

        public static bool StoreSettings<T>(Type owner, T settings)
        {
            var stored = GetStoredSettings();

            stored.Values[owner] = (object)settings;

            return StoreSettings(stored);
        }

        public static T ReadSettings<T>(Type owner)
        {
            var stored = GetStoredSettings();

            if (stored.Values.ContainsKey(owner))
            {
                return (T)Convert.ChangeType(stored.Values[owner], typeof(T));
            }

            return default(T);
        }

        private static string GetSettingsPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(path, SETTINGS_PATH);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, SETTINGS_FILE);

            if (!File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);
            }

            return path;
        }
        
        private static Settings GetStoredSettings()
        {
            var serialized = File.ReadAllText(GetSettingsPath());

            if (!string.IsNullOrEmpty(serialized))
            {
                return JsonConvert.DeserializeObject<Settings>(serialized);
            }

            return new Settings();
        }

        private static bool StoreSettings(Settings settings)
        {
            try
            {
                File.WriteAllText(GetSettingsPath(), JsonConvert.SerializeObject(settings));
                return true;
            }
            catch (Exception error)
            {
                LogManager.Error(LogManager.LogType.Data, error);
            }

            return false;
        }

        private class Settings
        {
            public Dictionary<Type, object> Values { get; set; }

            public Settings()
            {
                Values = new Dictionary<Type, object>();
            }
        }
    }
}
