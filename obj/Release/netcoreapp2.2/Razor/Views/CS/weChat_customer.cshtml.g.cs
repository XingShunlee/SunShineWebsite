#pragma checksum "E:\CodeStore\ehaikerv202010\Views\CS\weChat_customer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f77897b728db34b50089c3c32ec786ccf27ce05"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CS_weChat_customer), @"mvc.1.0.view", @"/Views/CS/weChat_customer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CS/weChat_customer.cshtml", typeof(AspNetCore.Views_CS_weChat_customer))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f77897b728db34b50089c3c32ec786ccf27ce05", @"/Views/CS/weChat_customer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_CS_weChat_customer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/lib/jquery/dist/jquery.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ff"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:100%;width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "E:\CodeStore\ehaikerv202010\Views\CS\weChat_customer.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(27, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(52, 6809, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f77897b728db34b50089c3c32ec786ccf27ce055042", async() => {
                BeginContext(58, 1376, true);
                WriteLiteral(@"
    <title>客服中心</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no"">
    <meta name=""apple-mobile-web-app-capable"" content=""yes"">
    <meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
    <!--微信不缓存东西  start-->
    <meta http-equiv=""Pragma"" content=""no-cache"" />
    <meta http-equiv=""Expires"" content=""0"" />
    <meta charset=""utf-8"" />
    <style type=""text/css"">
        .myclass {
            width: 100%;
            font-size: 12pt;
            padding-bottom: 10px;
        }

        span {
            width: 100px;
            background-color: #66b3ff;
            border: 1px;
        }

        .mylinkbutton {
            display: block;
            width: 150px;
            height: 35px;
            float: left;
            background: #95B8E7;
            font-weight: bold;
            color: white;
            border: 1px solid gray;
            border-radius: 2px;
            cursor: pointe");
                WriteLiteral(@"r;
        }

            .mylinkbutton:hover {
                color: Lime;
                border: 1px solid #27AE60;
            }
    </style>
    <link rel=""stylesheet"" type=""text/css"" href=""/lib/EASYUI/themes/default/easyui.css"" />
    <link rel=""stylesheet"" type=""text/css"" href=""/lib/EASYUI/themes/icon.css"" />
    <!--jquery-->
    ");
                EndContext();
                BeginContext(1434, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f77897b728db34b50089c3c32ec786ccf27ce056871", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 49 "E:\CodeStore\ehaikerv202010\Views\CS\weChat_customer.cshtml"
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
                BeginContext(1511, 5343, true);
                WriteLiteral(@"
    <script charset=utf-8 language=javascript src=""/lib/EASYUI/jquery.easyui.min.js""></script>
    <script type=""text/javascript"" src=""/lib/EASYUI/themes/locale/easyui-lang-zh_CN.js""></script>
    <script type=""text/javascript"">

        //计算时间间隔
        var oldId = 1;
        //计算时间间隔
        function computeTime(oldTime, style) {
            date = new Date(oldTime);
            var date2 = date.getTime() - datetemp.getTime();
            //一分钟内再次发消息，则不显示发送消息的时间
            if (date2 > 60000) {
                var flagH = """";
                var flagM = """";
                var hour = date.getHours();
                var min = date.getMinutes();
                //解决小时和分钟小于10，数字前面不显示0的情况
                if (hour < 10) flagH = ""0""; else flagH = """";
                if (min < 10) flagM = "":0""; else flagM = "":"";
                //发送内容时间
                $(""#content"").append(""<div style='"" + style + ""'>"" + flagH + hour + flagM + min + ""</div>"")
                datetemp = date;
            }
                WriteLiteral(@"
        }
        function getAllRecord() {
            $.ajax({
                url: ""../CS/getAllChatRecord?idTemp=customer_id&oldId="" + oldId,
                type: ""POST"",
                dataType: ""json"",
                success: function (data) {
                    if (data.iSuccessCode) {
                        for (var i in data.obj) {
                            var csChatRecord = data.obj[i];
                            if (csChatRecord.kfContent != null && csChatRecord.kfContent != '') {
                                computeTime(csChatRecord.Time, ""text-align:left;"");
                                //发送的内容
                                $(""#content"").append(""<div class='myclass'><span>""
                                    + unescape(csChatRecord.kfContent)
                                    + ""</span></div>"");
                            }
                            if (csChatRecord.customerContent != null && csChatRecord.customerContent != '') {
                         ");
                WriteLiteral(@"       computeTime(csChatRecord.Time, ""text-align:right;"");
                                $(""#content"").append(""<div class='myclass' style='text-align:right ;'><span>""
                                    + unescape(csChatRecord.customerContent)
                                    + ""</span></div>"");
                            }
                            oldId = csChatRecord.RecordId;
                        }
                    } else {
                        if (data.ErrorCode != 0) {
                            clearTimeout(g_timerId_getmsg);
                        }
                        alert(data.ErrorCode+1);
                    }
                },
                error: function (result) {
                    clearTimeout(g_timerId_getmsg);
                    window.close();
                }
            });
        }
        var datetemp = new Date(0);//用于计算时间差的中间变量
        var date;
        var g_timerId_getmsg;
        $(function () {
            /* 定时刷新组件，读取数据库信息");
                WriteLiteral(@" */
            g_timerId_getmsg = setInterval('getAllRecord()', 1000);
            /* 定时刷新组件，读取时间 */
            $(""#send"").click(function () {
                var content = $(""#textId"").val();
                $.ajax({
                    url: ""../CS/saveCustomerChatRecord"",
                    type: ""POST"",
                    dataType: ""json"",
                    /* 向后端传输的数据 */
                    data: { customerContent: escape(content.replace(/(?!<(img|p|span).*?>)<.*?>/g, """")) },
                    success: function (data) {
                        if (data.iSuccessCode) {
                            $(""#textId"").textbox('clear');
                            $.messager.show(
                                {
                                    title: '消息發送成功',
                                    timeout: 5000,
                                    showType: 'slide',
                                    msg: '消息發送成功！'
                                }
                            );
  ");
                WriteLiteral(@"                      } else {
                            alert(data.msg);
                            $(""#textId"").textbox('clear');
                            $.messager.show(
                                {
                                    title: '消息發送失敗',
                                    timeout: 5000,
                                    showType: 'slide',
                                    msg: data.msg
                                }
                            );
                        }
                    },
                    error: function (result) {
                        clearTimeout(g_timerId_getmsg);
                        $.messager.show(
                            {
                                title: '消息發送失敗',
                                timeout: 5000,
                                showType: 'slide',
                                msg: data.msg
                            }
                        );
                    }
                }");
                WriteLiteral(");\r\n            });\r\n        });\r\n        window.onbeforeunload = function () {\r\n            $.ajax({\r\n                url: \"../CS/customerOffline\",\r\n                type: \"POST\"\r\n            });\r\n        }\r\n    </script>\r\n");
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
            BeginContext(6861, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(6863, 912, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f77897b728db34b50089c3c32ec786ccf27ce0515336", async() => {
                BeginContext(6869, 259, true);
                WriteLiteral(@"
	<div id=""cc"" class=""easyui-layout"" style=""width:600px;height:400px;"" fit=""true"">  
	    <div data-options=""region:'north'"" style=""height:15%"">
	    	<h1 >客服中心</h1>  
	    </div>   
	    <div data-options=""region:'south'"" style=""height:25%;"">   
	    	");
                EndContext();
                BeginContext(7128, 373, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f77897b728db34b50089c3c32ec786ccf27ce0515995", async() => {
                    BeginContext(7174, 320, true);
                    WriteLiteral(@"   
			    <div>   
			        <input id=""textId"" class=""easyui-textbox"" name=""customerContent"" style=""height:100px;width:100%"" multiline=""true"" prompt=""说点什么吧..."" />   
			    </div>   
			    <div style=""float:right"" >   
					<button type=""button"" id=""send"" class=""mylinkbutton"">发送</button>
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
                BeginContext(7501, 267, true);
                WriteLiteral(@"  
		</div>
	    <!-- <div data-options=""region:'east'"" style=""width:10%;""></div>   
	    <div data-options=""region:'west'"" style=""width:10%;""></div> -->   
	    <div id=""content"" data-options=""region:'center'"" style=""padding:5px;"" >
	    </div>   
	</div>   
");
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
            BeginContext(7775, 9, true);
            WriteLiteral("\r\n</html>");
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