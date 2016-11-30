using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Config.ConfigModel;
using Framework.Utility;

namespace Core.Config.Tests
{
    [TestClass()]
    public class DbConfigServiceTests
    {
        [TestMethod()]
        public void GetConfigTest()
        {
            //var configService = new DbConfigService();
            //var res = configService.GetConfig<List<DaoConfig>>("DaoConfig");
            //Assert.AreEqual("ufj0QNXJls9wJlTC/3hDnb5rI2z49A8a0gEhIQX+wJ6IHlzj7KTaSVsv2tqHDs/rkWwCkoet4C4=", res[0].Log);
        }

        [TestMethod]
        public void SystemConfig()
        {
            var config=new SystemSettingConfig()
            {
                CacheExpiteTime = 1,
                CookieExpireTime = 1,
                FileDomain = "localhost",
                CdnDomain = "localhost",
                IsDbMonitor = true,
                Runable = true,
                SystemId = Guid.NewGuid(),
                WebSiteDescription = "Plain",
                WebSiteKeyWords = "Plain",
                WebSiteTitle ="Plain"
            };

            var xml = SerializationHelper.XmlSerialize(config);
   //<? xml version = "1.0" encoding = "utf-16" ?>
   //< SystemSettingConfig xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema" >
       
   //      < Id > 0 </ Id >
       
   //      < CreateTime > 2016 - 11 - 30T22: 06:01.3606877 + 08:00 </ CreateTime >
                 
   //                < IsDbMonitor > true </ IsDbMonitor >
                 
   //                < CookieExpireTime > 1 </ CookieExpireTime >
                 
   //                < CacheExpiteTime > 1 </ CacheExpiteTime >
                 
   //                < SystemId > f10be221 - 0ef9 - 4dee - b7bd - fbe78ad3d620 </ SystemId >
                        
   //                       < Runable > true </ Runable >
                        
   //                       < WebSiteTitle > Plain </ WebSiteTitle >
                        
   //                       < WebSiteDescription > Plain </ WebSiteDescription >
                        
   //                       < WebSiteKeyWords > Plain </ WebSiteKeyWords >
                        
   //                       < CdnDomain > localhost </ CdnDomain >
                        
   //                       < FileDomain > localhost </ FileDomain >
   //                     </ SystemSettingConfig >
                                    Assert.AreEqual(xml==String.Empty,false);
        }
    }
}