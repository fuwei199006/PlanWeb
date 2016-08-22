using System.Net.Configuration;
using Framework.Utility;

namespace Core.Config
{
    public class LocalCachedConfigContext:ConfigContext
    {
        public override T Get<T>(string keyOrName)
        {
            var result = (T)Caching.Get(keyOrName);
            if (result == null)
            {
                result = base.Get<T>(keyOrName);
                Caching.Set(keyOrName,result);
            }
            return result ;
        }

        public static LocalCachedConfigContext CurrentCachedConfigContext => new LocalCachedConfigContext();



         
    }
}