#pragma checksum "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8143b47358b24eec5799fac90b4a83463ba27e7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ItBlogShow_Index), @"mvc.1.0.view", @"/Views/ItBlogShow/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ItBlogShow/Index.cshtml", typeof(AspNetCore.Views_ItBlogShow_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8143b47358b24eec5799fac90b4a83463ba27e7f", @"/Views/ItBlogShow/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1098a2aec6f33ea0cefe3754aac50c0178964e", @"/Views/_ViewImports.cshtml")]
    public class Views_ItBlogShow_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ehaikerv202010.Models.ItBlogModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
  
    ViewBag.Title = Model.Title;
    var comments = ViewBag.Comments as List<ehaiker.Models.CommentModel>;

#line default
#line hidden
            BeginContext(160, 272, true);
            WriteLiteral(@"<link rel=""stylesheet"" href=""../css/showdetail/home-page.min.css"" />

    <div class=""page-body"">
        <div id=""left-right-layout"">
            <div class=""block-main"">
                <header class=""article-header"">
                    <h1 class=""article-title"">");
            EndContext();
            BeginContext(433, 11, false);
#line 13 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                         Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(444, 123, true);
            WriteLiteral("</h1>\r\n                    <div class=\"article-info\">\r\n                        <span><i class=\"article-lastedit\">最后修改：</i> ");
            EndContext();
            BeginContext(568, 18, false);
#line 15 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                               Write(Model.LastEditTime);

#line default
#line hidden
            EndContext();
            BeginContext(586, 75, true);
            WriteLiteral(" </span>\r\n                        <span><i class=\"article-reader\">浏览量：</i> ");
            EndContext();
            BeginContext(662, 13, false);
#line 16 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                            Write(Model.readers);

#line default
#line hidden
            EndContext();
            BeginContext(675, 101, true);
            WriteLiteral(" </span>\r\n                        <span><i class=\"article-comment\">评论：</i><a href=\"#articlecomment\"> ");
            EndContext();
            BeginContext(777, 14, false);
#line 17 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                                      Write(comments.Count);

#line default
#line hidden
            EndContext();
            BeginContext(791, 137, true);
            WriteLiteral(" </a></span>\r\n                        <span><i class=\"article-comment\"></i><a id=\"btnsubmit\" class=\"small-btn\" href=\"javascript:void(0);\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 928, "\"", 936, 0);
            EndWriteAttribute();
            BeginContext(937, 196, true);
            WriteLiteral(">收  藏</a></span>\r\n                    </div>\r\n                </header>\r\n                <article class=\"article-content clear-fix\">\r\n                    <div class=\"article-progra\" id=\"article\"> ");
            EndContext();
            BeginContext(1134, 24, false);
#line 22 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                         Write(Html.Raw(@Model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1158, 142, true);
            WriteLiteral(" </div>\r\n\r\n                </article>\r\n                <div class=\"article-copyright clear-fix\">\r\n                    <p class=\"ReferUri\">参考自:");
            EndContext();
            BeginContext(1301, 14, false);
#line 26 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                       Write(Model.ReferUri);

#line default
#line hidden
            EndContext();
            BeginContext(1315, 44, true);
            WriteLiteral(" </p>                 <p class=\"Author\">本文由 ");
            EndContext();
            BeginContext(1360, 12, false);
#line 26 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                                                  Write(Model.Author);

#line default
#line hidden
            EndContext();
            BeginContext(1372, 139, true);
            WriteLiteral(" 编辑，转载保留链接</p>\r\n                </div>\r\n                <!--討論-->\r\n                <div class=\"article-commentBlcok\" id=\"articlecomment\">\r\n");
            EndContext();
#line 30 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                      
                        var l = 0;
                        for (int m = 0; m < comments.Count; m++)
                        {
                            l = m + 1;

#line default
#line hidden
            BeginContext(1704, 53, true);
            WriteLiteral("                            <div class=\"commentItem\">");
            EndContext();
            BeginContext(1758, 1, false);
#line 35 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                Write(l);

#line default
#line hidden
            EndContext();
            BeginContext(1759, 3, true);
            WriteLiteral(" 樓 ");
            EndContext();
            BeginContext(1763, 30, false);
#line 35 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                     Write(Html.Raw(comments[m].UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1793, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1795, 32, false);
#line 35 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                                     Write(Html.Raw(comments[m].CreateTime));

#line default
#line hidden
            EndContext();
            BeginContext(1827, 10, true);
            WriteLiteral(":<br />   ");
            EndContext();
            BeginContext(1838, 29, false);
#line 35 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                                                                                Write(Html.Raw(comments[m].comment));

#line default
#line hidden
            EndContext();
            BeginContext(1867, 9, true);
            WriteLiteral(" </div>\r\n");
            EndContext();
#line 36 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(1926, 815, true);
            WriteLiteral(@"                </div>
                <div class=""article-commentBlcok"" style='display:none;' id=""speakcomment"">
                    <textarea id=""speakContent"" data-provider=""markdown"" rows=""5"" cols=""50"" class=""form-control""></textarea>
                    <button type=""submit"" class=""btn"" id=""SpeakComment"">发  表</button>
                </div>
            </div>


        </div><!---fg-->
    </div>

    <script>
        $(function () {
            $(""#btnsubmit"").on(""click"",
                function (o) {
                    o.stopPropagation();
                    
                    
                    $.ajax(
                        {
                            url: ""/MyItBlog/SaveMyItBlogs"",
                            type: ""post"",
                            data: { gid:");
            EndContext();
            BeginContext(2742, 8, false);
#line 60 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                   Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2750, 246, true);
            WriteLiteral("  },\r\n                            dataType: \"json\",\r\n                            success: function (o) {\r\n                                if (o.SuccessCode == \"0\") {\r\n                                    window.location.href = \"../ItBlogShow?Id=\"+");
            EndContext();
            BeginContext(2997, 8, false);
#line 64 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                          Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3005, 892, true);
            WriteLiteral(@";
                                    return;
                                }
                                else {
                                    alert(o.msg);
                                }

                            }
                            ,
                            error: function (o) {
                                alert(""请登录后再收藏"");
                            }

                        }); 
                });
            //SpeakComment 
            $(""#SpeakComment"").on(""click"",
                function (o) {
                    o.stopPropagation();
                    var content = $(""#speakContent"").val();
                    
                    $.ajax(
                        {
                            url: ""/CommentItBlog/commentSave"",
                            type: ""post"",
                            data: { uid:");
            EndContext();
            BeginContext(3898, 8, false);
#line 89 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                   Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3906, 314, true);
            WriteLiteral(@" ,customerContent: escape(content.replace(/(?!<(img|p|span).*?>)<.*?>/g, """"))},
                            dataType: ""json"",
                            success: function (o) {
                                if (o.Code == ""0"") {
                                    window.location.href = ""../ItBlogShow?Id=""+");
            EndContext();
            BeginContext(4221, 8, false);
#line 93 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
                                                                          Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4229, 483, true);
            WriteLiteral(@";
                                    return;
                                }
                                else {
                                    alert(o.msg);
                                }

                            }
                            ,
                            error: function (o) {
                                alert(""请登录后再发表评论"");
                            }

                        }); //ajax
                });
            if (");
            EndContext();
            BeginContext(4713, 14, false);
#line 108 "E:\CodeStore\ehaikerv202010\Views\ItBlogShow\Index.cshtml"
           Write(ViewBag.loging);

#line default
#line hidden
            EndContext();
            BeginContext(4727, 98, true);
            WriteLiteral(" > 0)\r\n                $(\"#speakcomment\").css(\'display\', \"block\");\r\n        });\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ehaikerv202010.Models.ItBlogModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
