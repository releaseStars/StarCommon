using System;
using System.Collections.Generic;
using System.Text;

namespace YamlHandler
{
    public static class UtilityExtensions
    {

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="utility"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(this YamlUtility utility, T obj) 
            => utility.Core.Serialize(obj);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="utility"></param>
        /// <param name="yaml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this YamlUtility utility, string yaml) 
            => utility.Core.Deserialize<T>(yaml);
    }
}
