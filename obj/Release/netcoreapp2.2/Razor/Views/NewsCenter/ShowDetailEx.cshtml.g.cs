#pragma checksum "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb0290a34035044f4f0fe4b7fcf96c49c1edb3a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NewsCenter_ShowDetailEx), @"mvc.1.0.view", @"/Views/NewsCenter/ShowDetailEx.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/NewsCenter/ShowDetailEx.cshtml", typeof(AspNetCore.Views_NewsCenter_ShowDetailEx))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb0290a34035044f4f0fe4b7fcf96c49c1edb3a3", @"/Views/NewsCenter/ShowDetailEx.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_NewsCenter_ShowDetailEx : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaikerv202010.Models.NewsModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
  
    Layout = null;
    ViewData["Title"] = "新闻中心";
    var types = ViewBag.Types as IEnumerable<SelectListItem>;

#line default
#line hidden
            BeginContext(163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(165, 1334, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb0290a34035044f4f0fe4b7fcf96c49c1edb3a34271", async() => {
                BeginContext(171, 13, true);
                WriteLiteral("\r\n    <title>");
                EndContext();
                BeginContext(185, 11, false);
#line 9 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
      Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(196, 247, true);
                WriteLiteral("</title>\r\n    <link rel=\"stylesheet\" href=\"/css/common.min.css\" /><!--菜单与悬浮样式应用-->\r\n    <link rel=\"stylesheet\" href=\"/css/icon.min.css\" />\r\n    <link rel=\"stylesheet\" href=\"/css/personal/home-page.min.css\" /> <!--主体样式应用-->\r\n    <!--jquery-->\r\n    ");
                EndContext();
                BeginContext(443, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb0290a34035044f4f0fe4b7fcf96c49c1edb3a35258", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 14 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
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
                BeginContext(520, 972, true);
                WriteLiteral(@"
    <script src=""../Scripts/news_showdetailEx.js""></script>
    <script src=""/plugins/tinymce/tinymce.min.js""></script>
    <link rel=""stylesheet"" href=""/css/CommonDialog.css"" />
    <script type=""text/javascript"" src=""/js/CommonDialog.js""></script>
    <script>
        tinymce.init({
            selector: '#idContent',
            language: 'zh_CN',
            directionality: 'ltr',
            browser_spellcheck: true,
            contextmenu: false,
            plugins: [
                ""advlist autolink lists link image charmap print preview anchor"",
                ""searchreplace visualblocks code fullscreen"",
                ""insertdatetime media table contextmenu paste imagetools wordcount"",
                ""code""
            ],
            toolbar: ""insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | code"",

        });
    </script>
");
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
            BeginContext(1499, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1501, 985, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb0290a34035044f4f0fe4b7fcf96c49c1edb3a39108", async() => {
                BeginContext(1507, 304, true);
                WriteLiteral(@"
    <div  style=""margin-top:10px;margin-bottom:10px;"">
        <div class=""box-wrap"">
            <div class=""login-input clear-fix focus-style"">
			<span class=""Title"">标题：</span>
			<input id=""idTitle"" name=""idTitle"" class=""input-text"" type=""text"" placeholder=""请输入标题，不超过255个字符"" style=""width:100%;""");
                EndContext();
                BeginWriteAttribute("value", " value=", 1811, "", 1830, 1);
#line 42 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
WriteAttributeValue("", 1818, Model.Title, 1818, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1830, 40, true);
                WriteLiteral(" />\r\n\t\t\t<input id=\"newsID\" type=\"hidden\"");
                EndContext();
                BeginWriteAttribute("value", " value=", 1870, "", 1886, 1);
#line 43 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
WriteAttributeValue("", 1877, Model.Id, 1877, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1886, 200, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\" form-group\">\r\n               <span style=\"font-size:24px;\">请在下面输入内容(1024)：</span><br />\r\n                <textarea id=\"idContent\" cols=\"10\" rows=\"50\">");
                EndContext();
                BeginContext(2087, 13, false);
#line 47 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
                                                        Write(Model.Content);

#line default
#line hidden
                EndContext();
                BeginContext(2100, 88, true);
                WriteLiteral("</textarea>\r\n            </div>\r\n            <div class=\" form-group\">\r\n                ");
                EndContext();
                BeginContext(2189, 101, false);
#line 50 "E:\CodeStore\ehaikerv202010\Views\NewsCenter\ShowDetailEx.cshtml"
           Write(Html.DropDownList("Types", ViewData["Types"] as SelectList, "--请选择--", new { @class = "SelectList" }));

#line default
#line hidden
                EndContext();
                BeginContext(2290, 135, true);
                WriteLiteral("\r\n            </div>\r\n            <hr />\r\n             <div class=\"login-btn\"><a id=\"personal-shiwan-add-btn\" href=\"javascript:void(0)\"");
                EndContext();
                BeginWriteAttribute("title", " title=\"", 2425, "\"", 2433, 0);
                EndWriteAttribute();
                BeginContext(2434, 45, true);
                WriteLiteral(">立即提交</a></div>\r\n        </div>\r\n    </div>\r\n");
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
            BeginContext(2486, 13, true);
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
