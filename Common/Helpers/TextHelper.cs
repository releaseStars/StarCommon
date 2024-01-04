using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class TextHelper
    {
        /// <summary>
        /// 导出文本内容
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="filePath">路径</param>
        public static void ExportText(string text, string filePath) => File.WriteAllText(filePath, text);

        /// <summary>
        /// 导出文本内容
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="filePath">路径</param>
        /// <param name="fileExtension">扩展名</param>
        public static void ExportText(string text, string filePath, string fileExtension)
        {
            string fullFilePath = Path.ChangeExtension(filePath, fileExtension);
            File.WriteAllText(fullFilePath, text);
        }

        /// <summary>
        /// 导入文本内容
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static string ImportText(string filePath) => File.ReadAllText(filePath);

        /// <summary>
        /// 导入目录下需要导入的文件通过正则匹配
        /// </summary>
        /// <param name="directoryPath">目录路径</param>
        /// <param name="pattern">正则字符串</param>
        public static string[] ImportFilesByRegex(string directoryPath, string pattern)
        {
            string[] files = Directory.GetFiles(directoryPath);

            return files
                .Where(file => Regex.IsMatch(file, pattern))
                .Select(file => File.ReadAllText(file))
                .ToArray();
        }
    }
}
