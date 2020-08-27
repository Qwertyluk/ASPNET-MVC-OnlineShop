using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.CacheProvider
{
    interface ICacheProvider
    {
        object Get(string key);
        void Set(string key, object obj, int cacheTime);
        bool isSet(string key);
        void Delete(string key);
    }
}
