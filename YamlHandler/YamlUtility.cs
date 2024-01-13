using Common.Helpers;
using System;

namespace YamlHandler
{
    public class YamlUtility
    {
        internal YamlHelper Core { get; private set; }

        internal YamlUtility() 
            => Core = new YamlHelper();

        public string ImportYaml(string filePath) 
            => TextHelper.ImportText(filePath);

        public void ExportYaml(string filePath, string data) 
            => TextHelper.ExportText(data, filePath, ".yaml");
    }
}
