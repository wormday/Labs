using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinMVC
{
    public interface IActionInvoker
    {
        void InvokeAction(ControllerContext controllerContext, string actionName);
    }
}