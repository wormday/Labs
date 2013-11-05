using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTest
{
    public class SimpleModule : IHttpModule
    {

        public void Dispose()
        {
           
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += context_PostResolveRequestCache;

        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            string s = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.ToString();
            //HttpContext.Current.Response.Write("dddd");
        }
    }
}