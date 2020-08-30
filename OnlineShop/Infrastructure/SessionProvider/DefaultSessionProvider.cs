using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace OnlineShop.Infrastructure.SessionProvider
{
    public class DefaultSessionProvider : ISessionProvider
    {
        private HttpSessionState session { get { return HttpContext.Current.Session; } }

        public static string CartElementsSessionName { get { return "CartElements_session"; } }

        public void Set<T>(string key, T obj)
        {
            session.Add(key, obj);
        }

        public T Get<T>(string key)
        {
            return (T)session[key];
        }

        public void Delete(string key)
        {
            session.Remove(key);
        }
    }
}