#pragma checksum "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dac3687bbcee27c80115f27b0b17fa04e9b86cf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewsCenter_ShowDetail), @"mvc.1.0.view", @"/Views/NewsCenter/ShowDetail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewsCenter/ShowDetail.cshtml", typeof(AspNetCore.Views_NewsCenter_ShowDetail))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "E:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "E:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac3687bbcee27c80115f27b0b17fa04e9b86cf0", @"/Views/NewsCenter/ShowDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_ShowDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaikerv202010.Models.NewsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
  
    ViewBag.Title = Model.Title;
    Layout = "_layout";

#line default
#line hidden
            BeginContext(106, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(114, 1230, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac3687bbcee27c80115f27b0b17fa04e9b86cf04556", async() => {
                BeginContext(120, 344, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
    <meta name=""renderer"" content=""webkit"" />
    <link rel=""shortcut icon"" href=""/css/favicon.ico"" type=""image/x-icon"" />
    <link rel=""icon"" href=""/css/favicon.ico"" type=""image/x-icon"" />
    <title data-title=""游戏分析平台-数据分析平台-ehaiker官网"">");
                EndContext();
                BeginContext(465, 11, false);
#line 13 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
                                           Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(476, 587, true);
                WriteLiteral(@"-数据分析平台</title>
    <meta name=""keywords"" content=游戏分析平台,数据分析平台,softlife>
    <meta name=""description"" content=softlife是一个网络游戏分析平台，通过对游戏进行多维度的数据分析，让用户能在充分了解游戏过程中的难点与收益时效，为用户的“投资决策”提供必要的数据解决方案。>
    
    <link rel=""stylesheet"" href=""/css/showdetail/home-page.min.css"" />
    <link rel=""stylesheet"" href=""/css/common.min.css"" />
    <link rel=""stylesheet"" href=""/css/icon.min.css"" />
    <link rel=""stylesheet"" type=""text/css"" href=""/lib/EASYUI/themes/default/easyui.css"" />
    <link rel=""stylesheet"" type=""text/css"" href=""/lib/EASYUI/themes/icon.css"" /> 
    <!--jquery-->
    ");
                EndContext();
                BeginContext(1063, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac3687bbcee27c80115f27b0b17fa04e9b86cf06282", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 23 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1140, 197, true);
                WriteLiteral("\r\n    <script charset=utf-8 language=javascript src=\"/lib/EASYUI/jquery.easyui.min.js\"></script>\r\n    <script type=\"text/javascript\" src=\"/lib/EASYUI/themes/locale/easyui-lang-zh_CN.js\"></script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1344, 3, true);
            WriteLiteral("\r\n ");
            EndContext();
            BeginContext(1347, 790, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dac3687bbcee27c80115f27b0b17fa04e9b86cf09346", async() => {
                BeginContext(1374, 161, true);
                WriteLiteral("\r\n\r\n<div class=\"page-body\">\r\n    <div id=\"left-right-layout\">\r\n    <div class=\"block-main\">\r\n\t<header class=\"article-header\">\r\n        <h1 class=\"article-title\">");
                EndContext();
                BeginContext(1536, 11, false);
#line 33 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
                             Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1547, 84, true);
                WriteLiteral("</h1>\r\n\t\t<div class=\"article-info\">\r\n\t\t\t<span><i class=\"article-lastedit\">最后修改：</i> ");
                EndContext();
                BeginContext(1632, 18, false);
#line 35 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
                                                   Write(Model.LastEditTime);

#line default
#line hidden
                EndContext();
                BeginContext(1650, 54, true);
                WriteLiteral(" </span>\r\n\t\t\t<span><i class=\"article-reader\">浏览量：</i> ");
                EndContext();
                BeginContext(1705, 13, false);
#line 36 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
                                                Write(Model.readers);

#line default
#line hidden
                EndContext();
                BeginContext(1718, 209, true);
                WriteLiteral(" </span>\r\n\t\t\t<span><i class=\"article-comment\">评论：</i><a href=\"#contabcomment1\"> 1 </a></span>\r\n\t\t</div>\r\n\t</header>\r\n\t<article class=\"article-content clear-fix\">\r\n    <div class=\"article-progra\" id=\"article\"> ");
                EndContext();
                BeginContext(1928, 24, false);
#line 41 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
                                         Write(Html.Raw(@Model.Content));

#line default
#line hidden
                EndContext();
                BeginContext(1952, 82, true);
                WriteLiteral(" </div>\r\n    </article>\r\n\r\n\t<div class=\"article-copyright clear-fix\"> \r\n    <p>本文 ");
                EndContext();
                BeginContext(2035, 15, false);
#line 45 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetail.cshtml"
     Write(Model.Announcer);

#line default
#line hidden
                EndContext();
                BeginContext(2050, 80, true);
                WriteLiteral(" 原创，转载保留链接</p>\r\n    </div>\r\n    </div>\r\n\t\r\n   \r\n    </div><!---fg-->\r\n</div>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2137, 13, true);
            WriteLiteral("\r\n</html>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaikerv202010.Models.NewsModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
