﻿using System.Web;
using System.Web.Optimization;

namespace CommonForum
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          "~/Scripts/jquery-{version}.js", "~/Scripts/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenme kaynağı olarak yararlanmak için Modernizr uygulamasının geliştirme sürümünü kullanın. Ardından
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new Bundle("~/Scripts/Datatable").Include(
              "~/Scripts/datatables.net/js/jquery.dataTables.js", "~/Content/datatables.net-bs4/js/dataTables.responsive.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css","~/Content/font-awesome/css/all.min.css"));

          

            BundleTable.EnableOptimizations = true;
        }
    }
}
