using MvcSiteMapProvider;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure.SiteMapProvers
{
    public class CategoriesSiteMapProvider : DynamicNodeProviderBase
    {
        readonly ShopContext shopContext = new ShopContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> retList = new List<DynamicNode>();

            foreach (var category in shopContext.Categories)
            {
                DynamicNode dynamicNode = new DynamicNode()
                {
                    Title = category.Name,
                    Key = "Category_" + category.CategoryId,
                };
                dynamicNode.RouteValues.Add("id", category.CategoryId);
                retList.Add(dynamicNode);
            }

            return retList;
        }
    }
}