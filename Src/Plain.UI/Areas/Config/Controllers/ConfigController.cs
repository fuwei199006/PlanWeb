using System;
using Core.Config.ConfigModel;
using Core.Encrypt;
using Framework.Utility;
using Plain.BLL.ConfigService;
using Plain.UI.Controllers;
using System.Web.Mvc;
using Plain.Model.Models.Model;

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
        public ActionResult DbConfigList()
        {
            var basicConfig = _configService.GetDaoConfig(CacheKey.DaoConfig);
            return View(basicConfig);
        }

        /// <summary>
        /// 修改db的数据的配置
        /// todo:还不能立即生效
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult DbConfigEdit(string key)//todo:此处可以去除参数
        {
            var basicConfig = _configService.GetDaoConfig(key);
            var basiceDao = basicConfig.ConfigBase as DaoConfig;
            basiceDao.BaseDao = DESEncrypt.Decode(basiceDao.BaseDao);
            basiceDao.BussinessDaoConfig = DESEncrypt.Decode(basiceDao.BussinessDaoConfig);
            basiceDao.Log = DESEncrypt.Decode(basiceDao.Log);
            return View(basiceDao);
        }
        [HttpPost]
        public ActionResult DbEdit(FormCollection collection)
        {
            var daoConfig = new DaoConfig();
            TryUpdateModel(daoConfig);
            daoConfig.BaseDao = DESEncrypt.Encode(daoConfig.BaseDao);
            daoConfig.BussinessDaoConfig = DESEncrypt.Encode(daoConfig.BussinessDaoConfig);
            daoConfig.Log = DESEncrypt.Encode(daoConfig.Log);
            daoConfig.Id = 1;
            daoConfig.CreateTime=DateTime.Now;
            var xmlConfigValue = SerializationHelper.XmlSerialize(daoConfig);
            this._configService.UpdateConfig(xmlConfigValue, CacheKey.DaoConfig);
            return this.RefreshParent();
        }

        public ActionResult CacheConfigList()
        {
            var basicConfig = _configService.GetConfigConfig(CacheKey.CacheConfig);
            return View(basicConfig);
        }

        public ActionResult CacheConfigEdit()
        {
            var cacheConfig = _configService.GetConfigConfig(CacheKey.CacheConfig);
            return View(cacheConfig);
        }
    }
}