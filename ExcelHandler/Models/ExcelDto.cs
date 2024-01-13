using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ExcelHandler.Models
{
    public class ExcelDto<T>
        where T : IExcel
    {
        public ExcelDto(
            List<T> values,
            string title = "")
        {
            Values = values ?? new List<T>();
            Title = title;
            NotDealPropNames = new List<string>();
        }

        public ExcelDto(
            List<T> values,
            [NotNull]List<string> notDealPropNames,
            string title = "")
        {
            Values = values ?? new List<T>();
            Title = title;
            NotDealPropNames = notDealPropNames;
        }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Values { get; private set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 不处理的属性名
        /// </summary>
        public List<string> NotDealPropNames { get; private set; }
    }
}
