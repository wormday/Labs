using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinMVC
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}