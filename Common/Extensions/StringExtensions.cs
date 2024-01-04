using System;

namespace Common.Extensions
{
    /// <summary>
    /// 字符串扩展方法类
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str">扩展对象</param>
        /// <returns>为空 true,否则 false</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 是否为空(包括空格)
        /// </summary>
        /// <param name="str">扩展对象</param>
        /// <returns>为空 true,否则 false</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="str">扩展对象</param>
        /// <returns>反转后的字符串</returns>
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
