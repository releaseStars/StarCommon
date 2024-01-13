using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelHandler
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnAttribute : Attribute
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 列宽 单位为 1/256 字符宽度
        /// </summary>
        public int? Width { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">列明</param>
        public ExcelColumnAttribute(string name) 
            => Name = name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">列明</param>
        /// <param name="width">列宽</param>
        public ExcelColumnAttribute(string name, int? width)
            => (Name, Width) = (name, width);
    }
}
