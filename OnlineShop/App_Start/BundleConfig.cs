using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OnlineShop.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.slim.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate").Include("~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate-unobtrusive").Include("~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}
