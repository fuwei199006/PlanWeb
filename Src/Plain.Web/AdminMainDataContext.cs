﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Cache;
using Core.Service;
using Framework.Extention;
using Plain.BLL.MenuService;
using Plain.Dto;
using Plain.Model.Models.Model;

namespace Plain.Web
{
    public class AdminMainDataContext
    {
        public static AdminMainDataContext Current
        {
            get { return CacheContext.GetItem<AdminMainDataContext>(); }
        }

        public const string _Key_Fix_Item = "_Key_Fix_Item";
        public const string _Key_Fix_Dic = "_Key_Fix_Dic";
        public IEnumerable<SelectListItem> GetSelectListItems<T>(string key) where T : struct
        {

            return CacheContext.Get(string.Format(CacheKey.SelectListItem, key+ _Key_Fix_Item, typeof(T).FullName),
                () =>
                {

                    return EnumHelper.GetItemValueList<T>()
                        .Select(r => new SelectListItem()
                        {
                            Value = r.Key.ToString(),
                            Text = r.Value.ToString()
                        });
                });

        }

        public Dictionary<int, string> GetItemValueList<T>(string key) where T : struct
        {

            return CacheContext.Get(string.Format(CacheKey.SelectListItem, key+ _Key_Fix_Dic, typeof(T).FullName),
                () => EnumHelper.GetItemValueList<T>());

        }
    }
}