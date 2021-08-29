using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;

namespace fql
{
    public class SettingsObj
    {
        public List<string> IncludeDirs { get; set; } = new List<string>();
        public List<string> ExcludeDirs { get; set; } = new List<string>();
    }

    public class SettingsFile
    {
        public SettingsFile()
        {
            m_settingsFilePath =
                Path.Combine
                (
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                    "fql.settings.json"
                );
            LoadSettings();
        }

        public SettingsObj Settings;

        public void LoadSettings()
        {
            if (!File.Exists(m_settingsFilePath))
            {
                Settings = new SettingsObj();
                SaveSettings();
                return;
            }

            string settingsJson = File.ReadAllText(m_settingsFilePath, Encoding.UTF8);

            using (TextReader tr = new StringReader(settingsJson))
            using (JsonTextReader jr = new JsonTextReader(tr))
                Settings = m_serializer.Deserialize<SettingsObj>(jr);
        }

        public void SaveSettings()
        {
            StringBuilder sb = new StringBuilder();
            using (TextWriter tw = new StringWriter(sb))
            using (JsonTextWriter jw = new JsonTextWriter(tw))
            {
                jw.Formatting = Formatting.Indented;
                m_serializer.Serialize(jw, Settings);
            }

            string settingsJson = sb.ToString();
            File.WriteAllText(m_settingsFilePath, settingsJson, Encoding.UTF8);
        }

        private string m_settingsFilePath;

        private JsonSerializer m_serializer = new JsonSerializer();
    }
}
