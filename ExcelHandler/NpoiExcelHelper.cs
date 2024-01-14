using ExcelHandler.Models;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Common.Extensions;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel;
using System;

namespace ExcelHandler
{
    internal class NpoiExcelHelper
    {
        internal void Export<T>(
            IWorkbook workbook,
            string filePath,
            Dictionary<string, ExcelDto<T>> inputInfo)
            where T : IExcel
        {
            foreach (var infoDic in inputInfo)
            {
                // 创建工作表
                ISheet sheet = workbook.CreateSheet(infoDic.Key);
                var item = infoDic.Value;
                if (item.Values.Count <= 0)
                {
                    continue;
                }

                // 获取处理列表
                var colInfos = item.Values.First()
                    .GetType()
                    .GetProperties()
                    .Select(it => new ColInfo(it, it.GetCustomAttribute<ExcelColumnAttribute>()))
                    .Where(it => it.Attribute != null)
                    .WhereIf(
                        item.NotDealPropNames.Count > 0,
                        it => !item.NotDealPropNames.Contains(it.Property.Name))
                    .ToArray();

                SetTitle(sheet, item.Title, colInfos);

                // 写入数据
                var rowNumber = sheet.LastRowNum + 1;
                foreach (var data in item.Values)
                {
                    if (rowNumber >= 65536 && workbook is HSSFWorkbook)
                    {
                        DateTime currentTime = DateTime.Now;
                        string timestamp = ((DateTimeOffset)currentTime).ToUnixTimeMilliseconds().ToString();
                        sheet = workbook.CreateSheet(infoDic.Key + timestamp);
                        SetTitle(sheet, item.Title, colInfos);
                        rowNumber = sheet.LastRowNum + 1;
                    }

                    IRow row = sheet.CreateRow(rowNumber++);
                    for (int colNumber = 0; colNumber < colInfos.Length; colNumber++)
                    {
                        var property = colInfos[colNumber].Property;
                        object obj = property.GetValue(data, null);
                        if (obj != null)
                        {
                            row.CreateCell(colNumber).SetCellValue(obj.ToString());
                        }
                    }
                }
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }
            workbook.Close();
        }

        #region Private

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">抬头</param>
        private void SetTitle(ISheet sheet, string title, ColInfo[] colInfos)
        {
            int rowNumber = 0;
            IRow row = sheet.CreateRow(rowNumber);
            if (!title.IsNullOrWhiteSpace())
            {
                // 合并单元格
                CellRangeAddress region = new CellRangeAddress(
                    rowNumber,
                    rowNumber,
                    0,
                    colInfos.Length - 1);
                sheet.AddMergedRegion(region);
                // 设置标题
                row.CreateCell(rowNumber).SetCellValue(title);

                // 更新 row
                rowNumber += 1;
                row = sheet.CreateRow(rowNumber);
            }

            for (int index = 0; index < colInfos.Length; index++)
            {
                var attr = colInfos[index].Attribute;
                row.CreateCell(index).SetCellValue(attr.Name);
                if (attr.Width.HasValue)
                {
                    // 如果传入了宽度，则使用传入的宽度
                    sheet.SetColumnWidth(index, attr.Width.Value * 256); // 宽度单位为 1/256 字符宽度
                }
                else
                {
                    // 否则，自动调整列宽
                    sheet.AutoSizeColumn(index);
                }
            }
        }

        #endregion


    }
}
