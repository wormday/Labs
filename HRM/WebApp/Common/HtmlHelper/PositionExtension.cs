using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using Hrm.WebApp.Common.Cache;

namespace Hrm.WebApp.Common.HtmlHelper
{
    public static class PositionExtension
    {
        public static MvcHtmlString PositionDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object defaultValue, string optionLabel, object htmlAttributes)
        {

            var list = PositionCache.GetList().ToSelectListBy("PositionID", "PositionName");
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, defaultValue, list, optionLabel, htmlAttributes);
        }

        public static MvcHtmlString PositionDropDownList(this System.Web.Mvc.HtmlHelper htmlHelper, string name, string optionLabel, object htmlAttributes)
        {

            var list = PositionCache.GetList().ToSelectListBy("PositionID", "PositionName");
            return System.Web.Mvc.Html.SelectExtensions.DropDownList(htmlHelper, name, list, optionLabel, htmlAttributes);
        }
    }
}