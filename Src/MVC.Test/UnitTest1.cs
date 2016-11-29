using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;
using Plain.Model.Models.Model;
using System.Web.Mvc.Html;
using Microsoft.Web.UnitTestUtil;

namespace MVC.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ViewDataDictionary<Basic_Role> dict = new ViewDataDictionary<Basic_Role>();
            dict.Model = new Basic_Role
            {
                RoleGroup = "2",
                RoleName = "1231",
                RoleStatus = 1
            };

            //HtmlHelper<Basic_Role> helper = MvcHelper.GetHtmlHelper(dict);


            //// Act
            //MvcHtmlString html1 = helper.DropDownListFor(m => m.RoleStatus, GroupedItems1);
            //MvcHtmlString html = helper.DropDownListFor(m => m.RoleGroup, GroupedItems);
        }
        private List<SelectListItem> GroupedItems
        {
            get
            {
                var dic = new List<SelectListItem>();
                dic.Add(new SelectListItem() { Value = "1", Text = "系统角色" });
                dic.Add(new SelectListItem() { Value = "2", Text = "数据角色" });
                dic.Add(new SelectListItem() { Value = "3", Text = "部门角色" });
                dic.Add(new SelectListItem() { Value = "4", Text = "其它角色" });
                return dic;
            }
        }
        private List<SelectListItem> GroupedItems1
        {
            get
            {
                var dic = new List<SelectListItem>();
                dic.Add(new SelectListItem() { Value = "0", Text = "系统角色" });
                dic.Add(new SelectListItem() { Value = "1", Text = "数据角色" });

                return dic;
            }
        }
       
    }
}
