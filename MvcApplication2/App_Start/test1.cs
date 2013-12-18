using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class MyHtml
    {

        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc, string actionName = "", string controllerName = "", object routeValue = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);

            string linkUrl = urlHelper.Action(actionName, controllerName, routeValue);

            TagBuilder linkTagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            linkTagBuilder.MergeAttribute("href", linkUrl);

            return new MvcHtmlString(linkTagBuilder.ToString(TagRenderMode.Normal));
        }

    }
}
