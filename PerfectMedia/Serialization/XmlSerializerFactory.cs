using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PerfectMedia.Serialization
{
    public class XmlSerializerFactory : IXmlSerializerFactory
    {
        private readonly IDictionary<Type, XmlSerializer> _serializers;

        public XmlSerializerFactory()
        {
            _serializers = new Dictionary<Type, XmlSerializer>();
        }

        public XmlSerializer GetXmlSerializer<T>()
        {
            XmlSerializer serializer;
            Type type = typeof (T);
            if (!_serializers.TryGetValue(type, out serializer))
            {
                _serializers[type] = serializer = new XmlSerializer(type);
            }
            return serializer;
        }
    }
}
