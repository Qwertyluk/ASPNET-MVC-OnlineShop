using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.SessionProvider
{
    public interface ISessionProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T obj);
        void Delete(string key);
    }
}
