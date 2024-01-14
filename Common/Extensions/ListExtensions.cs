using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// 通过分块大小拆分集合
        /// </summary>
        /// <param name="chunkSize">块大小</param>
        /// <returns></returns>
        public static List<List<T>> SplitList<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((value, index) => new { value, index })
                .GroupBy(x => x.index / chunkSize)
                .Select(group => group.Select(x => x.value).ToList())
                .ToList();
        }
    }
}
