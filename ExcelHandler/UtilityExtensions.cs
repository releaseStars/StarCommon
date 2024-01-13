﻿using ExcelHandler.Models;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelHandler
{
    public static class UtilityExtensions
    {
        /// <summary>
        /// 创建ExcelUtility
        /// </summary>
        /// <param name="utility"></param>
        /// <returns></returns>
        public static ExcelUtility Create(this ExcelUtility utility)
                   => new ExcelUtility();

        /// <summary>
        /// 导出xls文件
        /// </summary>
        public static void ExportXls<T>(this ExcelUtility utility, string filePath, Dictionary<string, ExcelDto<T>> data)
            where T : IExcel
            => utility.Core.Export(new HSSFWorkbook(), filePath, data);

        /// <summary>
        /// 导出xlsx文件
        /// </summary>
        public static void ExportXlsx<T>(this ExcelUtility utility, string filePath, Dictionary<string, ExcelDto<T>> data)
            where T : IExcel
            => utility.Core.Export(new XSSFWorkbook(), filePath, data);
    }
}
