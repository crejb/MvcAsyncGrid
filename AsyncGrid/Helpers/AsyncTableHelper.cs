using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AsyncGrid.Helpers
{
    public static class AsyncTableHelper
    {
        public static IHtmlString TableHeaderLink(this HtmlHelper helper, string target, string caption, string name = null)
        {
            name = name ?? caption;
            return helper.ActionLink(caption, target, new { SortBy = name, SortAsc = helper.ViewBag.SortDirections[name] });
        }
    }
}