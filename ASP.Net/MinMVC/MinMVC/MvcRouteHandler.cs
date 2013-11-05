using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinMVC
{
    public class MvcRouteHandler:IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MvcHandler(requestContext);
        }
    }
}