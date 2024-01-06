using Common.Helpers;
using System;

namespace YamlHandler
{
    public class YamlUtility
    {
        public YamlHelper Yaml { get;  }

        public YamlUtility()
        {
            Yaml = new YamlHelper();
        }

        public string ImportYaml(string filePath)
        {
            return TextHelper.ImportText(filePath);
        }

        public void ExportYaml(string filePath, string data)
        {
            TextHelper.ExportText(data, filePath, ".yaml");
        }

        public static YamlUtility Create() => new YamlUtility();
    }
}
