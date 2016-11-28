using Core.Config.ConfigModel;
using Core.Encrypt;
using Framework.Utility;
using Plain.BLL.ConfigService;
using Plain.UI.Controllers;
using System.Web.Mvc;

namespace Plain.UI.Areas.Config.Controllers
{
    public class ConfigController : BaseController
    {
 

        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }
        // GET: Config/Config
        public ActionResult DbList()
        {
            var basicConfig = _configService.GetDaoConfig(CacheKey.DaoConfig);
            return View(basicConfig);
        }


        public ActionResult DbEdit(string key)
        {
            var basicConfig = _configService.GetDaoConfig(key);
            var basiceDao = basicConfig.ConfigBase as DaoConfig;
            basiceDao.BaseDao = DESEncrypt.Decode(basiceDao.BaseDao);
            basiceDao.BussinessDaoConfig = DESEncrypt.Decode(basiceDao.BussinessDaoConfig);
            basiceDao.Log = DESEncrypt.Decode(basiceDao.Log);
            return View(basiceDao);
        }


        public ActionResult ConfigList()
        {
            var basicConfig = _configService.GetConfigConfig(CacheKey.CacheConfig);
            return View(basicConfig);
        }
    }
}