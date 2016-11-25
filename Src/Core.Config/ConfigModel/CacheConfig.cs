using System.Xml.Serialization;

namespace Core.Config.ConfigModel
{
    public class CacheConfig : ConfigBase
    {
        public CacheConfig()
        {

        }
        public CacheConfigItem[] CacheConfigItems { get; set; }
        public CacheProviderItem[] CacheProviderItems { get; set; }
    }

    public class CacheProviderItem : ConfigBase
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "desc")]
        public string Desc { get; set; }

    }

    public class CacheConfigItem : ConfigBase
    {
        [XmlAttribute(AttributeName = "keyRegex")]
        public string KeyRegex { get; set; }

        [XmlAttribute(AttributeName = "moduleRegex")]
        public string ModuleRegex { get; set; }

        [XmlAttribute(AttributeName = "providerName")]
        public string ProviderName { get; set; }

        [XmlAttribute(AttributeName = "minitus")]
        public int Minitus { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        public int Priority { get; set; }

        [XmlAttribute(AttributeName = "isAbsoluteExpiration")]
        public bool IsAbsoluteExpiration { get; set; }

        [XmlAttribute(AttributeName = "desc")]
        public string Desc { get; set; }
    }
}