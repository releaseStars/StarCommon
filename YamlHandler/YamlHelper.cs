using System.IO;
using YamlDotNet.Serialization;

namespace YamlHandler
{
    internal class YamlHelper
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">反序列化目标</typeparam>
        /// <param name="yaml">内容</param>
        /// <returns></returns>
        public T Deserialize<T>(string yaml)
        {
            var deserializer = new DeserializerBuilder().Build();
            using (var reader = new StringReader(yaml))
            {
                return deserializer.Deserialize<T>(reader);
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">序列化目标</typeparam>
        /// <param name="obj">内容</param>
        /// <returns></returns>
        public string Serialize<T>(T obj)
        {
            var serializer = new SerializerBuilder().Build();
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
    }
}
