using MvcSiteMapProvider;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Infrastructure.SiteMapProviders
{
    public class ProductsSiteMapProvider : DynamicNodeProviderBase
    {
        readonly ShopContext shopContext = new ShopContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            List<DynamicNode> retList = new List<DynamicNode>();

            foreach (var product in shopContext.Products)
            {
                DynamicNode dynamicNode = new DynamicNode()
                {
                    Title = product.Name,
                    Key = "Product_" + product.ProductId,
                    ParentKey = "Category_" + product.ProductCategory.CategoryId
                };
                dynamicNode.RouteValues.Add("id", product.ProductId);
                retList.Add(dynamicNode);
            }

            return retList;
        }
    }
}