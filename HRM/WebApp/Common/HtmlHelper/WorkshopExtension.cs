using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using Hrm.WebApp.Common.Cache;

namespace Hrm.WebApp.Common.HtmlHelper
{
    public static class WorkshopExtension
    {
        public static MvcHtmlString WorkshopDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object defaultValue, string optionLabel, object htmlAttributes)
        {

            var list = WorkshopCache.GetList().ToSelectListBy("WorkShopID","WorkShopName");
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, defaultValue, list, optionLabel, htmlAttributes);
        }

        public static MvcHtmlString WorkshopDropDownList(this System.Web.Mvc.HtmlHelper htmlHelper, string name, string optionLabel, object htmlAttributes)
        {

            var list = WorkshopCache.GetList().ToSelectListBy("WorkShopID", "WorkShopName");
            return System.Web.Mvc.Html.SelectExtensions.DropDownList(htmlHelper, name, list, optionLabel, htmlAttributes);
        }
    }
}