#pragma checksum "E:\CodeStore\ehaikerv202010\Views\AdminLogin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43c8d6309c2519c7f5b1c137812a3b770fee9cd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminLogin_Index), @"mvc.1.0.view", @"/Views/AdminLogin/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminLogin/Index.cshtml", typeof(AspNetCore.Views_AdminLogin_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43c8d6309c2519c7f5b1c137812a3b770fee9cd3", @"/Views/AdminLogin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminLogin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaiker.LoginViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("loginform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("uloginForm ulogin-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\CodeStore\ehaikerv202010\Views\AdminLogin\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(58, 17, true);
            WriteLiteral("<!DOCTYPE html>\r\n");
            EndContext();
            BeginContext(75, 986, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43c8d6309c2519c7f5b1c137812a3b770fee9cd35037", async() => {
                BeginContext(81, 735, true);
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
    <meta name=""renderer"" content=""webkit"" />
    <link rel=""shortcut icon"" href=""../css/favicon.ico"" type=""image/x-icon"" />
    <link rel=""icon"" href=""../css/favicon.ico"" type=""image/x-icon"" />
    <title>游戏分享平台-数据分享平台-ehaiker官网</title>
    <meta name=""keywords"" content=""游戏分享平台,数据分享平台"" />
    <meta name=""description"" content=""ehaiker是一个网络游戏分享平台，通过对游戏进行多维度的数据分析，让用户能在充分了解游戏过程中的难点与收益时效，为用户的“投资决策”提供必要的数据解决方案."" />
    <link rel=""stylesheet"" href=""../css/websitebase.css"" />
    <link rel=""stylesheet"" href=""../css/common.min.css"" />
    <link rel=""stylesheet"" href=""../css/Login/home-page.min.css"" />
    <!--jquery-->
    ");
                EndContext();
                BeginContext(816, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43c8d6309c2519c7f5b1c137812a3b770fee9cd36193", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 19 "E:\CodeStore\ehaikerv202010\Views\AdminLogin\Index.cshtml"
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
                BeginContext(893, 161, true);
                WriteLiteral("\r\n    <script src=\"../js/AdminLogin.js\"></script>\r\n    <!--QQ-第三方登录---->\r\n    <script type=\"text/javascript\"\r\n            src=\"../js/DaojishiPlug.js\"></script>\r\n");
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
            BeginContext(1061, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1063, 2170, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43c8d6309c2519c7f5b1c137812a3b770fee9cd39219", async() => {
                BeginContext(1069, 26, true);
                WriteLiteral("\r\n\t\r\n<!-- 顶部导航区域 -->\r\n<!--");
                EndContext();
                BeginContext(1096, 365, true);
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
                BeginContext(1461, 1588, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "43c8d6309c2519c7f5b1c137812a3b770fee9cd310132", async() => {
                    BeginContext(1514, 16, true);
                    WriteLiteral("\r\n              ");
                    EndContext();
                    BeginContext(1531, 23, false);
#line 40 "E:\CodeStore\ehaikerv202010\Views\AdminLogin\Index.cshtml"
         Write(Html.AntiForgeryToken());

#line default
#line hidden
                    EndContext();
                    BeginContext(1554, 1488, true);
                    WriteLiteral(@"
			<div class=""unlogin-box"">
				<span class=""login-error error-text""></span>
				<label class=""login-input clear-fix focus-style"">
					<span class=""left-pic left-pic-01""></span>
					<input class=""input-text"" id=""account"" type=""text"" name=""account"" placeholder=""请输入邮箱/ID/手机号"" value="""">
				</label>
				<label class=""login-input clear-fix"">
					<span class=""left-pic left-pic-02""></span>
					<input class=""input-text"" id=""password"" type=""password"" name=""password"" placeholder=""请输入密码"" value="""">
				</label>
				<label class=""login-input clear-fix"">
					<span class=""left-pic left-pic-03""></span>
					<input class=""input-text width-yzm"" id=""code"" type=""text"" name=""code"" placeholder=""5位验证码"" value="""">
					<span class=""error-text02""></span>
					<a class=""yzm-pic"" style=""display:none;""><img class=""J_validate_code"" id=""J_validate_code"" src=""/Account/GetValidateCode"" width=""88"" height=""32""></a>
				</label>
				<label class=""auto-login-box clear-fix "">
					<a class=""forget-password""   href=""/Serv");
                    WriteLiteral(@"icesCenter/ManageForgetPassword"" title="""">忘记密码?</a>
				</label>
                <div class="" clear-fix focus-style"">
				<a  id=""btnsubmit"" class=""login-btn"" href=""javascript:void(0);"" title="""">登 录</a></div>
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
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3049, 177, true);
                WriteLiteral("</div>\r\n\t</div>\r\n\r\n\t\t\t<!-- 区域右侧 -->\r\n\t\t\t<div class=\"block-right\"></div>\r\n\r\n\t\t\t<!-- 区域底部 -->\r\n\t\t\t<div class=\"block-bottom\"></div>\r\n\t\t</div>\r\n\t</div>\r\n\t\r\n\r\n  \r\n  <!-- 底部区域 -->\r\n\r\n");
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
            BeginContext(3233, 11, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaiker.LoginViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591