using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Text;
using ehaiker.Models;

namespace ehaiker
{
    public class Security
    {
        /// <summary>
        /// 创建验证码字符
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns>验证码字符</returns>
        public static string CreateVerificationText(int length)
        {
            char[] _verification = new char[length];
            char[] _dictionary = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random _random = new Random();
            for (int i = 0; i < length; i++) { _verification[i] = _dictionary[_random.Next(_dictionary.Length - 1)]; }
            return new string(_verification);
        }
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="verificationText">验证码字符串</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片长度</param>
        /// <returns>图片</returns>
        public static Bitmap CreateVerificationImage(string verificationText, int width, int height)
        {
            Pen _pen = new Pen(Color.Black);
            Font _font = new Font("Arial", 14, FontStyle.Bold);
            Brush _brush = null;
            Bitmap _bitmap = new Bitmap(width, height);
            Graphics _g = Graphics.FromImage(_bitmap);
            SizeF _totalSizeF = _g.MeasureString(verificationText, _font);
            SizeF _curCharSizeF;
            PointF _startPointF = new PointF((width - _totalSizeF.Width) / 2, (height - _totalSizeF.Height) / 2);
            //随机数产生器
            Random _random = new Random();
            _g.Clear(Color.White);
            Matrix matrix = new Matrix();
            for (int i = 0; i < verificationText.Length; i++)
            {
                matrix.Reset();
                matrix.Rotate( _random.Next(0,18));
                _g.Transform = matrix;
                _brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255)), Color.FromArgb(_random.Next(255), _random.Next(255), _random.Next(255)));
                _g.DrawString(verificationText[i].ToString(), _font, _brush, _startPointF);
                _curCharSizeF = _g.MeasureString(verificationText[i].ToString(), _font);
                _startPointF.X += _curCharSizeF.Width;
            }
            _g.Dispose();
            return _bitmap;
        }
        /// <summary>
        /// 256位散列加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        public static string Sha256(string plainText)
        {
            SHA256Managed _sha256 = new SHA256Managed();
            byte[] _cipherText = _sha256.ComputeHash(Encoding.Default.GetBytes(plainText));
            return Convert.ToBase64String(_cipherText);
        }
    }
    /*
    /// <summary>
    /// 管理员身份验证类---如果要全局调用，则需要在在Global.asax中注册该filter
    /// </summary>
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 重写自定义授权检查
        /// </summary>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Request.IsAuthenticated ) return false;
            else return true;
        }
        /// <summary>
        /// 重写未授权的 HTTP 请求处理
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new System.Web.Mvc.JsonResult()
                {
                    Data = new PostResult { ErrorCode = 301, msg = "会话失效，请重新登录", errMessage = "会话失效，请重新登录", iSuccessCode = 0, SuccessCode = "-1" },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    ContentType = "json"
                };
            }
            else
            {
                // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "EHaiker", action = "Index", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                filterContext.Result = new RedirectResult("../AdminLogin/Index?returnUrl=" + filterContext.HttpContext.Request.Url + "&returnMessage=权限不足或登录超时.");
            }
        }
        /// <summary>
        /// 下面可以定义到每个Action对应人员的访问细节
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
           //细节控制
            base.OnAuthorization(filterContext);
        }
    }
    /// <summary>
    /// 会员身份验证类：主要只是检测是否登录网站，其他不必检测
    /// </summary>
    public class MemberShipAuthorizeAttribute : AuthorizeAttribute
    {
        
        /// <summary>
        /// 重写未授权的 HTTP 请求处理
        /// </summary>
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    filterContext.Result = new RedirectResult("/EHaiker");
        //}

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    isAuth = true;
                }
            }
            if (!isAuth)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new System.Web.Mvc.JsonResult()
                        {
                            Data = new { ErrorCode = 301, msg = "会话失效，请重新登录", iSuccessCode = 0, SuccessCode = "-1" },
                            ContentEncoding = System.Text.Encoding.UTF8,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            ContentType = "json"
                        };
                }
                else
                {
                   // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "EHaiker", action = "Index", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                    filterContext.Result = new RedirectResult("/EHaiker/Login?returnUrl=" + filterContext.HttpContext.Request.Url + "&returnMessage=权限不足或登录超时.");
                }
                return;
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
    /// <summary>
    /// 管理员身份验证类：基本的都要验证！
    /// </summary>
    public class AuthAuthorizeAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 重写未授权的 HTTP 请求处理
        /// </summary>
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    IList<Permission> pList = null;
                    var roleService = new RoleService();
                    var actionDescriptor = filterContext.ActionDescriptor;
                    var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                    var controller = controllerDescriptor.ControllerName;
                    var action = actionDescriptor.ActionName;
                    var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;
                    var userData = (filterContext.RequestContext.HttpContext.User as MyFormsPrincipal<UserInfo>).UserData;
                    var cache = HttpRuntime.Cache.Get(userData.perskey) as List<Permission>;
                    if (cache != null)
                    {
                        pList = cache;
                    }

                    if (pList != null && userData.GroupId != 1)//1为超级管理员不用检查
                    {
                        isAuth = pList.Any(x => x.Controller.ToLower() == controller.ToLower() && x.Action.ToLower() == action.ToLower());
                    }
                    else
                    {
                        isAuth = true;
                    }
                }
            }
            if (!isAuth)
            {
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "EHaiker", action = "Index", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                filterContext.Result = new RedirectResult("../AdminLogin/Index?returnUrl=" + filterContext.HttpContext.Request.Url + "&returnMessage=权限不足或登录超时.");
                return;
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
    //客服安全类
    public class KefuAuthorizeAttribute : AuthorizeAttribute
    {
       
        //进行Controller 与action的细分
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var isAuth = false;
            if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            {
                isAuth = false;
            }
            else
            {
                //action
                if (filterContext.RequestContext.HttpContext.User.Identity != null)
                {
                    IList<Permission> pList = null;
                    var roleService = new RoleService();
                    var actionDescriptor = filterContext.ActionDescriptor;
                    var controllerDescriptor = actionDescriptor.ControllerDescriptor;
                    var controller = controllerDescriptor.ControllerName;
                    var action = actionDescriptor.ActionName;
                    var ticket = (filterContext.RequestContext.HttpContext.User.Identity as FormsIdentity).Ticket;
                    var userData = (filterContext.RequestContext.HttpContext.User as MyFormsPrincipal<UserInfo>).UserData;
                    var cache = HttpRuntime.Cache.Get(userData.perskey) as List<Permission>;
                    if (cache != null)
                    {
                        pList = cache;
                    }

                    if (pList != null && userData.GroupId != 1)//1为超级管理员不用检查
                    {
                        isAuth = pList.Any(x => x.Controller.Trim().ToLower() == controller.ToLower() && x.Action.Trim().ToLower() == action.ToLower());
                    }
                    else
                    {
                        isAuth = true;
                    }
                }
            }
            if (!isAuth)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new System.Web.Mvc.JsonResult()
                    {
                        Data = new { ErrorCode = 301, msg = "会话失效，请重新登录",iSuccessCode=0,SuccessCode="-1" },
                        ContentEncoding = System.Text.Encoding.UTF8,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentType = "json"
                    };
                }
                else
                {
                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "AdminLogin", action = "Index", returnUrl = filterContext.HttpContext.Request.Url, returnMessage = "您无权查看." }));
                    filterContext.Result = new RedirectResult("../AdminLogin/Index?returnUrl=" + filterContext.HttpContext.Request.Url + "&returnMessage=权限不足或登录超时.");
                }
                return;
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }*/
}