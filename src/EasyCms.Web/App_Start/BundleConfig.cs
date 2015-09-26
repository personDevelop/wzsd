﻿using System.Web;
using System.Web.Optimization;

namespace EasyCms.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region css sytle
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                 "~/Content/artdialog/ui-dialog.css",
                "~/Content/skin/default/style.css"));
            bundles.Add(new StyleBundle("~/bundles/jqxcss").Include(
              "~/Scripts/jqwidgets/styles/jqx.base.css",
             "~/Scripts/jqwidgets/styles/jqx.arctic.css"));



            bundles.Add(new StyleBundle("~/bundles/upimgcss").Include(
            "~/Content/ueditor/third-party/webuploader/webuploader.css",
             "~/Content/upload/Customrwebuploader.css",
             "~/Content/upload/upload.css"));
            #endregion

            #region javascript

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js" ,
                        "~/Content/jquery/jquery.nicescroll.js",
            //"~/Content/artdialog/dialog-plus-min.js",   
            "~/Content/js/layindex.js",
               "~/Content/js/common.js",
               "~/Content/js/laymain.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery.validate.js",
                //   "~/Content/js/jquery.metadata.js" ,
             "~/Content/js/messages_cn.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryAjax").Include(
                     "~/Scripts/jquery.unobtrusive-ajax.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jgui").Include(
                      "~/Scripts/jGui/jGuiCore.js",
                      "~/Scripts/jGui/jGuiToolBar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqx").Include(
                    "~/Scripts/jqwidgets/jqx-all.js",
                     "~/Scripts/jqwidgets/globalization/globalize.js",
             "~/Scripts/jqwidgets/globalization/globalize.culture.zh-Hans.js")); 

            bundles.Add(new ScriptBundle("~/bundles/ueditor").Include(
                 "~/Content/ueditor/ueditor.config.js",
                   "~/Content/ueditor/ueditor.all.js",
                   "~/Content/ueditor/lang/zh-cn/zh-cn.js",
                   "~/Content/ueditor/UEditorCustomer.js"));

            bundles.Add(new ScriptBundle("~/bundles/uploadJs").Include(
                "~/Content/ueditor/third-party/webuploader/webuploader.js"));


            bundles.Add(new ScriptBundle("~/bundles/eshopJS").Include(
              "~/Scripts/EshopAdminControl.js",
              "~/Scripts/WindowDialog.js"));


             

            #endregion


        }

        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        //public static void RegisterBundles(BundleCollection bundles)
        //{

        //    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        //                "~/Scripts/jquery-{version}.js"));

        //    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        //                "~/Scripts/jquery.validate*"));

        //    // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
        //    // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
        //    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
        //                "~/Scripts/modernizr-*"));

        //    bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
        //              "~/Scripts/bootstrap.js",
        //              "~/Scripts/respond.js"));

        //    bundles.Add(new StyleBundle("~/Content/css").Include(
        //              "~/Content/bootstrap.css",
        //              "~/Content/site.css"));
        //}
    }
}
