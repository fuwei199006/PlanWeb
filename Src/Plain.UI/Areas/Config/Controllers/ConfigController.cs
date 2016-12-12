using System;
using System.Linq;
using Core.Config.ConfigModel;
using Core.Encrypt;
using Framework.Utility;
using Plain.BLL.ConfigService;
using Plain.UI.Controllers;
using System.Web.Mvc;
using Core.Cache;
using Plain.Dto;
using Plain.Model.Models.Model;
using Plain.Web;
using CacheKey = Framework.Utility.CacheKey;

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
        public ActionResult DbConfigEdit(FormCollection collection)
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
            var basicConfig = _configService.GetCacheConfig(CacheKey.CacheConfig);
            return View(basicConfig);
        }

        public ActionResult CacheConfigEdit(int id)
        {
            var cacheConfig = _configService.GetCacheConfig(CacheKey.CacheConfig);
            return View(cacheConfig);
        }

        public ActionResult SystemSetting()
        {
            var systemSetting = _configService.GetSystemConfig(CacheKey.SystemConfig);
            return View(systemSetting);
        }

        public ActionResult SystemSettingEdit()
        {
            var systemSetting = _configService.GetSystemConfig(CacheKey.SystemConfig);
            ViewData["RunType"] = EnumHelper.GetItemValueList<RunType>().Select(r => new SelectListItem()
            {
                Value = r.Key==1?"True":"False",
                Text = r.Value.ToString()
            });
            return View(systemSetting.ConfigBase);
        }
        [HttpPost]
        public ActionResult SystemSettingEdit(FormCollection collection)
        {
            var systemSetting = _configService.GetSystemConfig(CacheKey.SystemConfig);
            var configBase = systemSetting.ConfigBase as SystemSettingConfig;
            var systemValue=new SystemSettingConfig();
            TryUpdateModel(systemValue);

            configBase.WebSiteTitle = systemValue.WebSiteTitle;
            configBase.WebSiteDescription = systemValue.WebSiteDescription;
            configBase.WebSiteKeyWords = systemValue.WebSiteKeyWords;
            configBase.CacheExpiteTime = systemValue.CacheExpiteTime;
            configBase.CookieExpireTime = systemValue.CookieExpireTime;
            configBase.CdnDomain = systemValue.CdnDomain;
            configBase.FileDomain = systemValue.FileDomain;
            configBase.Runable = systemValue.Runable;
            configBase.IsDbMonitor = systemValue.IsDbMonitor;
            //configBase.SystemId = systemValue.SystemId;
            configBase.SysAdmin = systemValue.SysAdmin;

            var xml= SerializationHelper.XmlSerialize(configBase);
            this._configService.UpdateSystemConfig(xml, CacheKey.SystemConfig);
            return this.RefreshParent();
        }
    }
}