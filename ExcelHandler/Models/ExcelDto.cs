using System.Collections.Generic;
using System.IO;

namespace ExcelHandler.Models
{
    public class ExcelDto<T>
        where T : IExcel
    {
        public ExcelDto(
            List<T> values,
            FileMode fileMode = FileMode.Create,
            string title = "")
        {
            Values = values ?? new List<T>();
            FileMode = fileMode;
            Title = title;
            NotDealPropNames = new List<string>();
        }

        public ExcelDto(
            List<T> values,
            FileMode fileMode = FileMode.Create,
            string title = "",
            List<string>? notDealPropNames = null)
        {
            Values = values ?? new List<T>();
            FileMode = fileMode;
            Title = title;
            NotDealPropNames = notDealPropNames ?? new List<string>();
        }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Values { get; private set; }

        /// <summary>
        /// 操作模式
        /// </summary>
        public FileMode FileMode { get; private set; }

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
