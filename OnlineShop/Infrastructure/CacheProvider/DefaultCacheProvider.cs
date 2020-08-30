using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace OnlineShop.Infrastructure.CacheProvider
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private Cache cacheContext { get { return HttpContext.Current.Cache; } }
        public static string CategoriesCacheName { get { return "Categories_cache"; } }


        public T Get<T>(string key)
        {
            return (T)cacheContext.Get(key);
        }

        public void Set<T>(string key, T obj, int cacheTime)
        {
            cacheContext.Insert(key, obj, null, DateTime.Now + TimeSpan.FromSeconds(cacheTime), Cache.NoSlidingExpiration);
        }

        /*public bool isSet(string key)
        {
            return cacheContext.Get(key) != null;
        }*/

        public void Delete(string key)
        {
            cacheContext.Remove(key);
        }
    }
}