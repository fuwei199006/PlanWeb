﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto
{
    public class BaseKey
    {
        public const string Plain_ = "Plain_";
        public const string _Plain_ = "_Plain_";
        public const string Plain = "_Plain";
        public const string CMS = "CMS";
        public const string _CMS_ = "_CMS_";
        public const string CMS_ = "CMS_";
    }
   public class CacheKey
    {
         public const string PlainMenu = BaseKey.Plain_+"Menu_{0}";
        public const string ArticleList =BaseKey.CMS_+"ArticleList";
        public const string LoginInfo = "LoginInfo";
        public const string SystemTitle = "SystemTitle";
        public const string Menu = BaseKey.Plain_ + "Menu_{0}_{1}_{2}";
        public const string SelectListItem = BaseKey.Plain_ + "SelectListItem_{0}_{1}";
    }

    public class WebKeys
    {
        public const string MenuTypeDrop = "MenuTypeDrop";
        public const string StatusTypeDrop = "StatusTypeDrop";
        public const string PowerGroupDrop = "PowerGroupDrop";
        public const string RoleGroupDrop = "RoleGroupDrop";
        public const string RoleGroupDic = "RoleGroupDic";

        public const string UserStausTypeDrop = "UserStausTypeDrop";
        public const string SexTypeDrop = "SexTypeDrop";
        public const string MenuTypeDic = "MenuTypeDic";

        public const string _Key_Fix_Item = "_Key_Fix_Item";
        public const string _Key_Fix_Dic = "_Key_Fix_Dic";

        //属于cms
        public const string ArticleType = BaseKey.CMS_+"ArticleType";
        public const string ArticleStatu = BaseKey.CMS_+ "ArticleStatu";
    }
}
