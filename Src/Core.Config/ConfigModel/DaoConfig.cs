namespace Core.Config.ConfigModel
{
    public class DaoConfig:ConfigBase
    {
         public string Log { get; set; }

        public string BaseDao { get; set; }
        public string PlainDb { get; set; }
    }
}