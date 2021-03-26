using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace TSPOnline.Extensions
{
    public static class CookiesExtensions
    {
        public static List<Cookie> GetAllCookies(this CookieContainer cc)
        {
            var cookies = new List<Cookie>();
            var table = (Hashtable)cc.GetType().InvokeMember(
                name: "m_domainTable",
                invokeAttr: BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                binder: null,
                target: cc,
                args: new object[] { });
            foreach (var pathList in table.Values)
            {
                var cookieCols = (SortedList)pathList.GetType().InvokeMember(
                    name: "m_list",
                    invokeAttr: BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                    binder: null,
                    target: pathList,
                    args: new object[] { });
                foreach (var colCookies in cookieCols.Values)
                    foreach (var c in colCookies as CookieCollection)
                        cookies.Add(c as Cookie);
            }
            return cookies;
        }
    }
}
