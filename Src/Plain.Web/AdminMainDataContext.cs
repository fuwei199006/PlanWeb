using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Cache;
using Plain.Dto;
using Framework.Utility.Extention;


namespace Plain.Web
{
    public class AdminMainDataContext
    {
        public static AdminMainDataContext Current
        {
            get { return CacheContext.GetItem<AdminMainDataContext>(); }
        }


        public IEnumerable<SelectListItem> GetSelectListItems<T>(string key) where T : struct
        {

            return CacheContext.Get(string.Format(CacheKey.SelectListItem, key+ WebKeys._Key_Fix_Item, typeof(T).FullName),
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

            return CacheContext.Get(string.Format(CacheKey.SelectListItem, key+ WebKeys._Key_Fix_Dic, typeof(T).FullName),
                () => EnumHelper.GetItemValueList<T>());

        }
    }
}