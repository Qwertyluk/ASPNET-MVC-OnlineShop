using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Helpers
{
    public static class UrlHelpers
    {
        public static string GetImagePath(this UrlHelper helper, string imageName)
        {
            return helper.Content(Path.Combine(ConfigurationManager.AppSettings["ImageCatalogPath"], imageName));
        }

        public static string GetProductImagePath(this UrlHelper helper, string productImageName)
        {
            return helper.Content(Path.Combine(ConfigurationManager.AppSettings["ImageProductCatalogPath"], productImageName));
        }
    }
}