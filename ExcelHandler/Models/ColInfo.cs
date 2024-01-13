using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;

namespace ExcelHandler.Models
{
    internal class ColInfo
    {
        public ColInfo(
            PropertyInfo property,
            ExcelColumnAttribute attribute)
        {
            Property = property;
            Attribute = attribute;
        }

        public PropertyInfo Property { get; private set; }

        public ExcelColumnAttribute Attribute { get; private set; }
    }
}
