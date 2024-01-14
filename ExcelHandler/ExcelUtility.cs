using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelHandler
{
    public class ExcelUtility
    {
        internal NpoiExcelHelper NpoiCore { get; private set; }

        public ExcelUtility() 
            => NpoiCore = new NpoiExcelHelper();

        /// <summary>
        /// 创建ExcelUtility
        /// </summary>
        public static ExcelUtility Create()
                   => new ExcelUtility();
    }
}
