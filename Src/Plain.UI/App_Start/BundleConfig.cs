﻿
using System.Web;
using System.Web.Optimization;
using Framework.Extention;
using System.Web.Mvc;
using Framework.Web;

namespace Plan.UI
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
             
            bundles.Add(new ScriptBundle("~/media/js").Include(
                        "~/Content/plugins/jQuery/jQuery-2.1.4.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            //// 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));


            
     
        }
    }
}
