#pragma checksum "D:\CodeStore\ehaikerv202010\Views\CSServer\weChat_KeFu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa960281eae9ccc69e7b4afff414bdcb5fd4b79e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CSServer_weChat_KeFu), @"mvc.1.0.view", @"/Views/CSServer/weChat_KeFu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CSServer/weChat_KeFu.cshtml", typeof(AspNetCore.Views_CSServer_weChat_KeFu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa960281eae9ccc69e7b4afff414bdcb5fd4b79e", @"/Views/CSServer/weChat_KeFu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_CSServer_weChat_KeFu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ff"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:100%;width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\CodeStore\ehaikerv202010\Views\CSServer\weChat_KeFu.cshtml"
  
    ViewBag.Title = "客服中心";
    Layout = null;

#line default
#line hidden
            BeginContext(56, 25, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(81, 12029, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa960281eae9ccc69e7b4afff414bdcb5fd4b79e4559", async() => {
                BeginContext(87, 12016, true);
                WriteLiteral(@"
	<title>客服中心</title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no"">
	<meta name=""apple-mobile-web-app-capable"" content=""yes"">
	<meta name=""apple-mobile-web-app-status-bar-style"" content=""black"">
	<!--不缓存东西  start-->
	<meta http-equiv=""Pragma"" content=""no-cache"" />
	<meta http-equiv=""Expires"" content=""0"" />
	<style type=""text/css"">
	    .CustomerBG
	    {
	        display:block;
	    }
		.myclass{
			width:100%;
			font-size: 12pt;
			padding-bottom: 10px;
		}
		.myclass span{
			width:100px;
			background-color: #66b3ff;
			border: 1px;
		}
		.mylinkbutton
		{
		    display:block;
		    width:150px;
            height:35px;
            float:left;
            background: #95B8E7;
	        font-weight: bold;
	        color: white;
	        border:1px solid gray;
	        border-radius: 2px;
	        cursor: pointer;
		}
		.mylinkbutton:hover
		{
		     color:Lime;
		    border:1px solid #27AE60; 
		}
	</style>
	<");
                WriteLiteral(@"link rel=""stylesheet"" type=""text/css"" href=""/lib/EASYUI/themes/default/easyui.css""/>
    <script charset=utf-8 language=javascript src =""/lib/jquery/dist/jquery.min.js""></script>
    <script charset=utf-8 language=javascript src =""/lib/EASYUI/jquery.easyui.min.js""></script>
    <script type=""text/javascript"" src=""/lib/EASYUI/themes/locale/easyui-lang-zh_CN.js""></script>
	<script type=""text/javascript"">
    
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
	            $(""#contentCS"").append(""<div style='"" + style +");
                WriteLiteral(@" ""'>"" + flagH + hour + flagM + min + ""</div>"")
	            datetemp = date;
	        }
	    }

	    function getAllRecord() {
	        $.ajax({
	            url: ""./getSAllChatRecord?idTemp=user_id&id="" + id + ""&oldId="" + oldId,
	            type: ""POST"",
	            dataType: ""json"",
	            data: null,
	            success: function (data) {
	                if (data.iSuccessCode) {
	                    //将聊天信息显示到页面上
	                    for (var i in data.obj) {

	                        var csChatRecord = data.obj[i];
	                        if (csChatRecord.kfContent != null && csChatRecord.kfContent != '') {
	                            computeTime(csChatRecord.Time, ""text-align:right;"");
	                            $(""#contentCS"").append(""<div class='myclass' style='text-align:right ;'><span>""
																									+ unescape( csChatRecord.kfContent )
																							+ ""</span></div>"");
	                        }
	                        if (csChatRecord.custom");
                WriteLiteral(@"erContent != null && csChatRecord.customerContent != '') {
	                            computeTime(csChatRecord.Time, ""text-align:left;"");
	                            $(""#contentCS"").append(""<div class='myclass'><span>""
																									+ unescape(csChatRecord.customerContent)
																							+ ""</span></div>"");
	                        }

	                        oldId = csChatRecord.RecordId;
	                    }
	                }
	                else {
	                    
	                    if (data.ErrorCode != 0) {
	                        clearTimeout(g_timerId_getmsg);
	                    }
	                    //alert(data.msg);
	                }
	            },
	            error: function (result) {
	                clearTimeout(g_timerId_getlist);
	                clearTimeout(g_timerId_getmsg);
	                window.close();
	            }
	        });
	    }
	    //获取左侧正在沟通的用户列表
	    function getCustomerList() {

	        $.ajax({
	       ");
                WriteLiteral(@"     url: ""./getCustomerList"",
	            type: ""POST"",
	            dataType: ""json"",
	            success: function (data) {
	                //清空用户
	                $("".CustomerBG"").remove();
	                if (data.iSuccessCode) {
	                    var onlineFlag = 1;
	                    //用户下线，如果客服人员正在与此人沟通，那么清空聊天页面
	                    for (var i in data.obj) {
	                        var customer = data.obj[i];
	                        if (id == customer.customerId) {
	                            onlineFlag = 0;
	                        }
	                    }
	                    //清空右边内容
	                    if (onlineFlag == 1) {
	                        $(""#contentCS"").html("""");
	                        id = """";
	                    }
	                    
	                    //获取之前的用户列表
	                    var exitstbg;
	                   
	                    //获得用户列表，显示到页面上
	                    for (var i in data.obj) {
	                        var customer");
                WriteLiteral(@" = data.obj[i];
	                        cId = customer.customerId;
	                        var cHeadImg = customer.headImg;
	                        var cName = customer.UserName;
	                        exitstbg = $(""div#"" + cId + "".CustomerBG"")
	                        if (customer.isOnline > 0 && exitstbg.length < 1) {
	                            $(""#westList"").append(
						        	                    ""<div id="" + cId + "" class='CustomerBG'><img alt='加载中' src='../../kefu/""
										                    + cHeadImg
										                    + ""' height='40px' width='40px' >""
						        	                    + ""<label id='labelId' class='checkLabel' style='font-size: 12pt;'data_id='""
										                    + cId
										                    + ""'>""
                                                            + cName

                                                        + ""</div>"");
	                           
	                        }
	                        else {
	");
                WriteLiteral(@"                            //--移除下线的用户
	                            if (exitstbg != null && customer.isOnline <= 0) {
	                                $(exitstbg).remove()
	                            }
	                            $(""div#"" + cId + "".CustomerBG>img"").attr(""src"", '../../kefu/'
										                    + cHeadImg);
	                        }
	                        //防止列表刷新将选中的用户置为未选中状态
	                        if (cId == id) {
	                            $(""div#"" + cId).css('background', '#00ffff');
	                        }

	                    } //--for
	                    //剔除下线的用户
	                    // $("".CustomerBG"").each(
	                } else {
	                    //读取失败
	                    if (data.ErrorCode != 0) {
	                        clearTimeout(g_timerId_getlist);
	                    }
	                }
	            }, //success
	            error: function (result) {
	                clearTimeout(g_timerId_getlist);
	               ");
                WriteLiteral(@" clearTimeout(g_timerId_getmsg);
	                window.close();

	            }
	        });
		}
		//数据定义 应用入口
	    var datetemp = new Date(0); //用于计算时间差的中间变量
	    var date;
	    var oldId = 1;
	    var id = """";
	    var g_timerId_getmsg;
		var g_timerId_getlist;
		var g_timerId_jq;
		//判断JQ是否完成加载
		IsJQureyLoadCompleted();
		function IsJQureyLoadCompleted() {
			if (typeof $ != 'undefined' && document.body) {
				JQEntryMain();
                clearTimeout(g_timerId_jq);
			}
			else {
                clearTimeout(g_timerId_jq);
                g_timerId_jq=setTimeout(IsJQureyLoadCompleted,1000);
			}
		}
		function JQEntryMain() {
            $(function () {
                //获取用户列表
                //定时刷新
                g_timerId_getlist = setInterval('getCustomerList()', 750);
                //消息存入数据库
                $(""#send"").click(function () {
                    if (id === """") {
                        alert(""请择用户对象"");
                        return;
           ");
                WriteLiteral(@"         }
                    var content = $(""#textId"").val();
                    $.ajax({
                        url: ""./saveUserChatRecord?id="" + id,
                        type: ""POST"",
                        dataType: ""json"",
                        /* 向后端传输的数据 */
                        data: { userContent: escape(content.replace(/(?!<(img|p|span).*?>)<.*?>/g, """")) },
                        success: function (data) {
                            if (!data.iSuccessCode) {
                                alert(data.msg);
                            }
                            $(""#textId"").textbox('clear');
                        },
                        error: function (result) {
                            clearTimeout(g_timerId_getlist);
                            clearTimeout(g_timerId_getmsg);
                            window.close();
                        }
                    });
                });
                //一键换人
                $(""#sendRg"").click(functi");
                WriteLiteral(@"on () {
                    //关闭
                    clearTimeout(g_timerId_getlist);
                    clearTimeout(g_timerId_getmsg);
                    $.ajax({
                        url: ""./ChangeKefu"",
                        type: ""POST"",
                        success: function (data) {
                            if (!data.iSuccessCode) {
                                alert(data.msg);
                            }
                            window.location.href = ""../ManagerMain/Index"";
                        },
                        error: function (result) {
                            clearTimeout(g_timerId_getlist);
                            clearTimeout(g_timerId_getmsg);
                            window.close();
                        }
                    });
                });
                //
                $(""#sendLeave"").click(function () {
                    //关闭
                    clearTimeout(g_timerId_getlist);
                    clearTime");
                WriteLiteral(@"out(g_timerId_getmsg);
                    $.ajax({
                        url: ""./KefuOffline"",
                        type: ""POST"",
                        success: function (data) {
                            if (!data.iSuccessCode) {
                                alert(data.msg);
                            }
                            window.location.href = ""../ManagerMain/Index"";
                        },
                        error: function (result) {
                            window.close();
                        }
                    });
                });


            });
            $(document).off(""click"", "".CustomerBG"").on(""click"", "".CustomerBG"", function () {
                oldId = 0;
                datetemp = new Date(0);
                id = $(this.lastElementChild).attr(""data_id"");
                $(this).css('background', '#ffffff');
                $(""div#"" + id).css('background', '#00ffff');
                $(""#contentCS"").html("""");
              ");
                WriteLiteral(@"  $(""#contentCS"").append(""<div class='myclass'>当前正在沟通的用户："" + $(this.lastElementChild).text() + ""</div>"");
                // 定时刷新组件，读取数据库信息 
                g_timerId_getmsg = setInterval('getAllRecord()', 3000);
            });
            $(document).keydown(function () {
                if ((event.keyCode == 116) || //屏蔽F5 
                    (event.ctrlkey && event.keycode == 82)) {//CTRL +R
                    event.keycode = 0;
                    event.returnValue = false;
                }
            });
		}
       
        window.onbeforeunload = function () {
			if (window.event.clientY < 0 || window.event.altkey) {
				$.ajax({
					url: ""./KefuOffline"",
					type: ""POST""
				});
			}
	    }     
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
            BeginContext(12110, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12112, 1205, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa960281eae9ccc69e7b4afff414bdcb5fd4b79e18343", async() => {
                BeginContext(12118, 238, true);
                WriteLiteral("\r\n\t<div id=\"cc\" class=\"easyui-layout\" style=\"width:600px;height:500px;\" fit=\"true\">   \r\n\t    <!-- <div data-options=\"region:\'north\'\" style=\"height:10%\"></div>   --> \r\n\t    <div data-options=\"region:\'south\'\" style=\"height:30%;\">   \r\n\t    \t");
                EndContext();
                BeginContext(12356, 570, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa960281eae9ccc69e7b4afff414bdcb5fd4b79e18999", async() => {
                    BeginContext(12402, 517, true);
                    WriteLiteral(@"   
			    <div>   
			        <input id=""textId"" class=""easyui-textbox"" name=""userContent"" style=""height:120px;width:100%;border: 0;"" multiline=""true"" prompt=""说点什么吧..."" />   
			    </div>  
			    <div style=""float:right"" >   
                    <button type=""button"" id=""sendLeave"" class=""mylinkbutton"" >离开会话</button>
                    <button type=""button"" id=""sendRg"" class=""mylinkbutton""  >一键移交</button>
					<button type=""button"" id=""send""  class=""mylinkbutton""  >发送</button>

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
                BeginContext(12926, 384, true);
                WriteLiteral(@"  
		</div>
	    <!-- <div data-options=""region:'east'"" style=""width:10%;""></div>    -->
	    <div id=""westList"" data-options=""region:'west'"" style=""width:20%;"">
		  <!--  <button type=""button"" id=""list"" style=""display: block"">正在沟通的用户</button>-->
	    </div>   
	    <div id=""contentCS"" data-options=""region:'center'"" style=""padding:5px;"" >
	    	
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
            BeginContext(13317, 11, true);
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