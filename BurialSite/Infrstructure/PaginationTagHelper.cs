using System;
using System.Collections.Generic;
using BurialSite.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
namespace BurialSite.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "pagination-info")]
    public class PaginationTagHelper : TagHelper
    {
        // get url info
        private IUrlHelperFactory urlInfo;

        // says what element this tag applies to

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;

        }

        // to put in difs
        public bool StuffWorks { get; set; }
        // use this t store info from the model
        public PageNumberingInfo PaginationInfo { get; set; }
        public object DepthFilter { get; set; }



        [HtmlAttributeName(DictionaryAttributePrefix = ("url-helper-"))]
        // make dictionary for some reason overly complicated
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        // get view conext
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        // process method
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // use this instead of string
            IUrlHelper urlBuilder = urlInfo.GetUrlHelper(ViewContext);

            // give filter values that are passed
           // KeyValuePairs["depthfilter"] =;

            /// what will be returned
            TagBuilder finishedTag = new TagBuilder("div");

            for (int i = 1; i <= PaginationInfo.NumPages; i++)
            {

                KeyValuePairs["pagenumber"] = i;
                // stuff for anchord
                TagBuilder indyTag = new TagBuilder("a");
                // make a tags
                // could be string but use url helper to build based on action and key values
                indyTag.Attributes["href"] = urlBuilder.Action("FilterBurials", KeyValuePairs);
                indyTag.InnerHtml.Append($" {i} ");

                // append to whole tag
                finishedTag.InnerHtml.AppendHtml(indyTag);
            }

            finishedTag.AddCssClass("navvy");
            // put it on output
            output.Content.AppendHtml(finishedTag.InnerHtml);

        }
    }
}
