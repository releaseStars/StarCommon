using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelHandler
{
    public class ExcelUtility
    {
        internal ExcelHelper Core { get; private set; }

        public ExcelUtility() 
            => Core = new ExcelHelper();
    }
}
