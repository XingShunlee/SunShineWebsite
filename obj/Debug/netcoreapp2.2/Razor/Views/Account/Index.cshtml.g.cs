#pragma checksum "D:\CodeStore\ehaikerv202010\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2973c68acfce0b339ea695a4e50b5b0b0e4aa728"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Index.cshtml", typeof(AspNetCore.Views_Account_Index))]
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
#line 1 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010;

#line default
#line hidden
#line 2 "D:\CodeStore\ehaikerv202010\Views\_ViewImports.cshtml"
using ehaikerv202010.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2973c68acfce0b339ea695a4e50b5b0b0e4aa728", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("loginform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("uloginForm ulogin-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\CodeStore\ehaikerv202010\Views\Account\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(29, 17, true);
            WriteLiteral("<!DOCTYPE html>\r\n");
            EndContext();
            BeginContext(46, 1034, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2973c68acfce0b339ea695a4e50b5b0b0e4aa7284571", async() => {
                BeginContext(52, 1021, true);
                WriteLiteral(@"
  <meta charset=""utf-8"" />
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
  <meta name=""renderer"" content=""webkit"" />
  <link rel=""shortcut icon"" href=""../common/css/favicon.ico"" type=""image/x-icon"" />
  <link rel=""icon"" href=""../common/css/favicon.ico"" type=""image/x-icon"" />
  <title>游戏分享平台-数据分享平台-ehaiker官网</title>
  <meta name=""keywords"" content=""游戏分享平台,数据分享平台,ehaiker官网"" />
  <meta name=""description"" content=""ehaiker是一个网络游戏分享平台，通过对游戏进行多维度的数据分析，让用户能在充分了解游戏过程中的难点与收益时效，为用户的“投资决策”提供必要的数据解决方案.""/>
 <link rel=""stylesheet"" href=""../common/css/common.min.css"" />
  <link rel=""stylesheet"" href=""../common/css/icon.min.css"" />
  <link rel=""stylesheet"" href=""../common/css/fuceng.min.css"" />
    <link rel=""stylesheet"" href=""../common/css/Login/home-page.min.css"" />
  <script src=""../common/js/jquery.min.js""></script>
    <script src=""../common/js/AdminLogin.js""></script>
    <!--QQ-第三方登录---->
    <script type=""text/javascript"" 
        src=""../common/js/DaojishiPlug.js""></script>
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
            BeginContext(1080, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1082, 2145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2973c68acfce0b339ea695a4e50b5b0b0e4aa7286829", async() => {
                BeginContext(1088, 26, true);
                WriteLiteral("\r\n\t\r\n<!-- 顶部导航区域 -->\r\n<!--");
                EndContext();
                BeginContext(1115, 365, true);
                WriteLiteral(@"@Html.Partial(""TopBlock"")-->
	<div class=""page-body"">
		<div id=""left-right-layout"">
			<!-- 区域顶部-->
			<div class=""block-top""></div>

			<!-- 区域主侧 -->
			<div class=""block-main"">
		<div class=""index-login"">
        <div class=""customer-nav-href size-18""><span class=""bottom-border nav-3f3f4d"">管理员登录</span></div>
			<div class=""index-login-bg""></div>
			");
                EndContext();
                BeginContext(1480, 1588, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2973c68acfce0b339ea695a4e50b5b0b0e4aa7287742", async() => {
                    BeginContext(1533, 16, true);
                    WriteLiteral("\r\n              ");
                    EndContext();
                    BeginContext(1550, 23, false);
#line 40 "D:\CodeStore\ehaikerv202010\Views\Account\Index.cshtml"
         Write(Html.AntiForgeryToken());

#line default
#line hidden
                    EndContext();
                    BeginContext(1573, 283, true);
                    WriteLiteral(@"
			<div class=""unlogin-box"">
				<span class=""login-error error-text""></span>
				<label class=""login-input clear-fix focus-style"">
					<span class=""left-pic left-pic-01""></span>
					<input class=""input-text"" id=""account"" type=""text"" name=""account"" placeholder=""请输入邮箱/ID/手机号""");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 1856, "\"", 1864, 0);
                    EndWriteAttribute();
                    BeginContext(1865, 205, true);
                    WriteLiteral(">\r\n\t\t\t\t</label>\r\n\t\t\t\t<label class=\"login-input clear-fix\">\r\n\t\t\t\t\t<span class=\"left-pic left-pic-02\"></span>\r\n\t\t\t\t\t<input class=\"input-text\" id=\"password\" type=\"password\" name=\"password\" placeholder=\"请输入密码\"");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 2070, "\"", 2078, 0);
                    EndWriteAttribute();
                    BeginContext(2079, 203, true);
                    WriteLiteral(">\r\n\t\t\t\t</label>\r\n\t\t\t\t<label class=\"login-input clear-fix\">\r\n\t\t\t\t\t<span class=\"left-pic left-pic-03\"></span>\r\n\t\t\t\t\t<input class=\"input-text width-yzm\" id=\"code\" type=\"text\" name=\"code\" placeholder=\"5位验证码\"");
                    EndContext();
                    BeginWriteAttribute("value", " value=\"", 2282, "\"", 2290, 0);
                    EndWriteAttribute();
                    BeginContext(2291, 338, true);
                    WriteLiteral(@">
					<span class=""error-text02""></span>
					<a class=""yzm-pic"" style=""display:none;""><img class=""J_validate_code"" id=""J_validate_code"" src=""/EHaiker/GetValidateCode"" width=""88"" height=""32""></a>
				</label>
				<label class=""auto-login-box clear-fix "">
					<a class=""forget-password""   href=""/ServicesCenter/ManageForgetPassword""");
                    EndContext();
                    BeginWriteAttribute("title", " title=\"", 2629, "\"", 2637, 0);
                    EndWriteAttribute();
                    BeginContext(2638, 147, true);
                    WriteLiteral(">忘记密码?</a>\r\n\t\t\t\t</label>\r\n                <div class=\" clear-fix focus-style\">\r\n\t\t\t\t<a  id=\"btnsubmit\" class=\"login-btn\" href=\"javascript:void(0);\"");
                    EndContext();
                    BeginWriteAttribute("title", " title=\"", 2785, "\"", 2793, 0);
                    EndWriteAttribute();
                    BeginContext(2794, 267, true);
                    WriteLiteral(@">登 录</a></div>
				<label class=""faster-login clear-fix"">
                    <!--QQ---->	
                      <span class=""faster-login-text"" id=""plugtest"" >QQ快速登录</span>
                    </a>
                </label>
                </div>
             ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3068, 152, true);
                WriteLiteral("</div>\r\n\t</div>\r\n\r\n\t\t\t<!-- 区域右侧 -->\r\n\t\t\t<div class=\"block-right\"></div>\r\n\r\n\t\t\t<!-- 区域底部 -->\r\n\t\t\t<div class=\"block-bottom\"></div>\r\n\t\t</div>\r\n\t</div>\r\n\t\r\n");
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
            BeginContext(3227, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
