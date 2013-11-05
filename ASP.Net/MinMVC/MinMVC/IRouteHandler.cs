using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinMVC
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}