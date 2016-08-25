using System.Xml.Serialization;

namespace Core.Config.ConfigModel
{
    public class DaoConfig:ConfigBase
    {
        [XmlAttribute(AttributeName = "Log")]
        public string Log { get; set; }
        [XmlAttribute(AttributeName = "BaseDao")]
        public string BaseDao { get; set; }
        [XmlAttribute(AttributeName = "BussinessDaoConfig")]
        public string BussinessDaoConfig { get; set; }
    }
}