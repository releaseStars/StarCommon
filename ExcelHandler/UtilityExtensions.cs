using ExcelHandler.Models;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;

namespace ExcelHandler
{
    public static class UtilityExtensions
    {
        /// <summary>
        /// 导出xls文件
        /// </summary>
        public static void ExportXls<T>(
            this ExcelUtility utility,
            string filePath,
            Dictionary<string, ExcelDto<T>> data)
            where T : IExcel
            => utility.Core.Export(
                new HSSFWorkbook(),
                Path.ChangeExtension(filePath, "xls"),
                data);

        /// <summary>
        /// 导出xlsx文件
        /// </summary>
        public static void ExportXlsx<T>(
            this ExcelUtility utility,
            string filePath,
            Dictionary<string, ExcelDto<T>> data)
            where T : IExcel
            => utility.Core.Export(
                new XSSFWorkbook(),
                Path.ChangeExtension(filePath, "xlsx"),
                data);

        public static void ExportXlsxV2<T>(
            this ExcelUtility utility,
            string filePath,
            Dictionary<string, ExcelDto<T>> data)
            where T : IExcel
            => utility.Core.ExportV2(
                new XSSFWorkbook(),
                Path.ChangeExtension(filePath, "xlsx"),
                data);
    }
}
