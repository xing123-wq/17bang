namespace System.Web.Mvc.Html
{
    public static class HtmlExtensionMethods
    {

        public static MvcHtmlString Gender(this HtmlHelper htmlHelper, bool? isFemale)
        {
            TagBuilder span = new TagBuilder("span");

            string output = string.Empty;
            if (isFemale.HasValue)
            {
                output = isFemale.Value ? "男" : "女";
                output += "，";
            }

            span.InnerHtml = output.ToString();

            return new MvcHtmlString(span.ToString());
        }

        /// <summary>
        /// 给Request的Url添加：/Page-{0}
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns>带/Page-{0}的url</returns>
        public static string FormatPage(this HtmlHelper htmlHelper)
        {
            HttpRequestBase Request = new HttpRequestWrapper(HttpContext.Current.Request);

            string path = Request.Url.LocalPath;
            int start = path.ToLower().LastIndexOf("page-");
            string pathPrefix = start > -1 ? path.Substring(0, start) : path;

            if (!pathPrefix.EndsWith("/"))
            {
                pathPrefix += "/";
            }

            return pathPrefix + "Page-{0}" + Request.Url.Query;
        }

    }
}