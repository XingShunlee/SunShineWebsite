#pragma checksum "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0492f93f802eb64c96d1457461467419d20cc9f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewsCenter_ShowNews), @"mvc.1.0.view", @"/Views/NewsCenter/ShowNews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewsCenter/ShowNews.cshtml", typeof(AspNetCore.Views_NewsCenter_ShowNews))]
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
#line 1 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0492f93f802eb64c96d1457461467419d20cc9f0", @"/Views/NewsCenter/ShowNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_ShowNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ehaikerv202010.Models.NewsModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 2 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(73, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(81, 958, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0492f93f802eb64c96d1457461467419d20cc9f04160", async() => {
                BeginContext(87, 817, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
    <meta name=""renderer"" content=""webkit"" />
    <link rel=""shortcut icon"" href=""/css/favicon.ico"" type=""image/x-icon"" />
    <link rel=""icon"" href=""/css/favicon.ico"" type=""image/x-icon"" />
    <title>资讯中心-数据分享平台-ehaiker</title>
    <meta name=""keywords"" content=""游戏分享平台,数据分享平台,ehaiker"" />
    <meta name=""description"" content=""ehaiker是一个网络游戏分享平台，通过对游戏进行多维度的数据分析，让用户能在充分了解游戏过程中的难点与收益时效，为用户的“投资决策”提供必要的数据解决方案."" />
    <link rel=""stylesheet"" href=""/css/websitebase.css"" /><!--基本样式应用-->
    <link rel=""stylesheet"" href=""/css/common.min.css"" /><!--菜单与悬浮样式应用-->
    <link rel=""stylesheet"" href=""/css/icon.min.css"" />
    <link rel=""stylesheet"" href=""/css/personal/home-page.min.css"" />
    <!--jquery-->
    ");
                EndContext();
                BeginContext(904, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0492f93f802eb64c96d1457461467419d20cc9f05402", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 20 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
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
                BeginContext(981, 51, true);
                WriteLiteral("\r\n    <script src=\"/js/newscenter.js\"></script>\r\n\r\n");
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
            BeginContext(1039, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1041, 384, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0492f93f802eb64c96d1457461467419d20cc9f08332", async() => {
                BeginContext(1047, 129, true);
                WriteLiteral("\r\n<!-- 顶部导航区域 -->\r\n<div id=\"left-right-layout\">\r\n    <div class=\"block-main\">\r\n        <div class=\"datagrid-container-fliud\">\r\n\r\n");
                EndContext();
#line 30 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
                BeginContext(1225, 46, true);
                WriteLiteral("        <div class=\"data-row\">\r\n            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 1271, "\'", 1320, 2);
                WriteAttributeValue("", 1278, "../NewsCenter/ShowDetailEx?newsID=", 1278, 34, true);
#line 33 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
WriteAttributeValue("", 1312, item.Id, 1312, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1321, 16, true);
                WriteLiteral(" target=\'_self\'>");
                EndContext();
                BeginContext(1338, 10, false);
#line 33 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
                                                                           Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1348, 22, true);
                WriteLiteral("</a>\r\n        </div>\r\n");
                EndContext();
#line 35 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\NewsCenter\ShowNews.cshtml"
         }

#line default
#line hidden
                BeginContext(1382, 36, true);
                WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1425, 13, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ehaikerv202010.Models.NewsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
