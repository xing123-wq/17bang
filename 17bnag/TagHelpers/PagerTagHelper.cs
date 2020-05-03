using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bnag.TagHelpers
{
    /// <summary>
    /// pager指定tag的名字， Attribute指定tag里可以包含的属性
    /// </summary>
    [HtmlTargetElement("datetime", Attributes = _showicon + "," + _only)]
    ///必须继承自TagHelper
    public class PagerTagHelper : TagHelper
    {
        //context: 能够获取attributes的信息
        //output：输出的原生html标签
        private const string _only = "asp-only";
        private const string _showicon = "asp-showicon";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "small";   //原生标签名
            object asp = context.AllAttributes[_showicon].Value;
            output.Attributes.RemoveAll(_showicon);
            bool hasasp = bool.Parse(asp.ToString().ToLower());
            if (hasasp)
            {
                output.Content.AppendHtml("<span class='glyphicon glyphicon-calendar'></span>");
            }

            //分别取出pageIndex和path的值
            object asp_only = context.AllAttributes[_only].Value;
            output.Attributes.Remove(context.AllAttributes[_only]);
            bool hasOnly = asp_only.ToString().ToLower().Contains("date");
            if (hasOnly)
            {
                output.Content.AppendHtml(DateTime.Now.ToString("yyyy年MM月dd HH时mm分ss秒"));
            }

           
            //设置a标签里href的值
            output.Attributes.Add("href", $"{asp}/Page-{asp_only}");
            base.Process(context, output);
        }
    }
}
