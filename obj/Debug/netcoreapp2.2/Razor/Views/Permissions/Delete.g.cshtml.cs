#pragma checksum "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d322de7ebeb7d0fc3359db55238c0aa65f6e0329"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permissions_Delete), @"mvc.1.0.view", @"/Views/Permissions/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Permissions/Delete.cshtml", typeof(AspNetCore.Views_Permissions_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d322de7ebeb7d0fc3359db55238c0aa65f6e0329", @"/Views/Permissions/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_Permissions_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaiker.Auth.Permission>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(76, 196, true);
            WriteLiteral("\r\n<h2 style=\"margin-top:30px;\">Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Permission</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(273, 44, false);
#line 15 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GlobalNo));

#line default
#line hidden
            EndContext();
            BeginContext(317, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(361, 40, false);
#line 18 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GlobalNo));

#line default
#line hidden
            EndContext();
            BeginContext(401, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(445, 53, false);
#line 21 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ChineseActionName));

#line default
#line hidden
            EndContext();
            BeginContext(498, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(542, 49, false);
#line 24 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ChineseActionName));

#line default
#line hidden
            EndContext();
            BeginContext(591, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(635, 46, false);
#line 27 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Controller));

#line default
#line hidden
            EndContext();
            BeginContext(681, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(725, 42, false);
#line 30 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Controller));

#line default
#line hidden
            EndContext();
            BeginContext(767, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(811, 42, false);
#line 33 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Action));

#line default
#line hidden
            EndContext();
            BeginContext(853, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(897, 38, false);
#line 36 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Action));

#line default
#line hidden
            EndContext();
            BeginContext(935, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(979, 47, false);
#line 39 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1026, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1070, 43, false);
#line 42 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1113, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1157, 41, false);
#line 45 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.isGet));

#line default
#line hidden
            EndContext();
            BeginContext(1198, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1242, 37, false);
#line 48 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.isGet));

#line default
#line hidden
            EndContext();
            BeginContext(1279, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1323, 52, false);
#line 51 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShowInManagerBar));

#line default
#line hidden
            EndContext();
            BeginContext(1375, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1419, 48, false);
#line 54 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShowInManagerBar));

#line default
#line hidden
            EndContext();
            BeginContext(1467, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1511, 46, false);
#line 57 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VisitLevel));

#line default
#line hidden
            EndContext();
            BeginContext(1557, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1601, 42, false);
#line 60 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VisitLevel));

#line default
#line hidden
            EndContext();
            BeginContext(1643, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1681, 195, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d322de7ebeb7d0fc3359db55238c0aa65f6e032911504", async() => {
                BeginContext(1707, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1717, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d322de7ebeb7d0fc3359db55238c0aa65f6e032911897", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 65 "C:\Users\LeeXingShun\source\repos\ehaikerv202010\Views\Permissions\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1753, 80, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"删除\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1833, 30, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d322de7ebeb7d0fc3359db55238c0aa65f6e032913801", async() => {
                    BeginContext(1855, 4, true);
                    WriteLiteral("返回列表");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1863, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1876, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaiker.Auth.Permission> Html { get; private set; }
    }
}
#pragma warning restore 1591
