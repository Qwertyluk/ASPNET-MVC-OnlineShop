using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.CacheProvider
{
    interface ICacheProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T obj, int cacheTime);
        //bool isSet(string key);
        void Delete(string key);
    }
}
