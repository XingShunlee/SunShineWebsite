using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Filters
{
    public class AuthoritiesFilters : AuthorizeFilter, IAllowAnonymousFilter
    {
    }
    public class LoginAuthorize : AuthorizeFilter
    {
        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (IsHaveAllow(context.Filters))
            {
                return;
            }
            var url = context.HttpContext.Request.Path.Value;
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            var list = url.Split("/");
            if (list.Length <= 0 || url == "/")
            {
                return;
            }
            var controllerName = list[1].ToString().Trim();
            var actionName = list[2].ToString().Trim();
            var flag = PowerIsTrue.IsHavePower(controllerName, actionName);
            if (flag.Item1 != 0)
            {
                context.Result = new RedirectResult("/Home/Index");
            }

        }

        private bool IsHaveAllow(IList<IFilterMetadata> filters)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i] is IAllowAnonymousFilter)
                    return true;
            }
            return false;
        }
    }

    internal class PowerIsTrue
    {
        internal static (int, string) IsHavePower(object controllerName, object actionName)
        {
            return (0, "通過");
        }
    }


    //public class AuthFilterAttribute1 : IAuthorizationFilter
    //{
    //    public override void OnAuthorization(AuthorizationFilterContext actionContext)
    //    {
    //        //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
    //        if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
    //        {
    //            return;
    //        }

    //        var dicHeader = actionContext.Request.Headers.ToDictionary(r => r.Key, r => r.Value);

    //        //var verifyResult = actionContext.Request.Headers.Authorization != null && actionContext.Request.Headers.Authorization.Scheme == "123456";
    //        var verifyResult = dicHeader.Any(r => r.Key == "Authorization" && r.Value != null && r.Value.Contains("123456"));

    //        if (!verifyResult)
    //        {
    //            //如果验证不通过，则返回401错误，并且Body中写入错误原因
    //            //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("Token 不正确"));
    //            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "请登录");
    //        }
    //    }


    //}
    //can use for phone remote varified!
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        private readonly string AuthHeaderKey;

        public string ResultMethodName { get; set; }

        public Type ResultMethodDelcaringType { get; set; }

        public AuthFilterAttribute(string authHeaderKey)
        {
            AuthHeaderKey = authHeaderKey;
            ResultMethodDelcaringType = typeof(AuthDefaultConst);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authResult = true;
            if (!string.IsNullOrEmpty(AuthHeaderKey))
            {
                var authInHeader = context?.HttpContext?.Request?.Headers[AuthHeaderKey];

                if (authInHeader.HasValue && authInHeader.Value.Count > 0)
                {
                    int headerValue;
                    if (int.TryParse(authInHeader.Value[0], out headerValue))
                    {
                        var authType = (LoginAuth)Enum.Parse(typeof(LoginAuth),
                                                                    (headerValue >= 0 ? headerValue : 0).ToString());

                        authResult = authType != LoginAuth.Illegal;
                    }
                }
            }

            if (!authResult)
            {
                //auth field,return default value
                object result = null;
                if (!string.IsNullOrEmpty(ResultMethodName))
                {
                    var method = ResultMethodDelcaringType.GetMethod(ResultMethodName);
                    if (method != null)
                    {
                        result = method.Invoke(null, null);
                    }
                }
                context.Result = new JsonResult(result);
                return;
            }

            //auth success,do other things
            base.OnActionExecuting(context);
        }
    }

    internal class AuthDefaultConst
    {
    }

    internal class LoginAuth
    {
        internal static LoginAuth Illegal;
    }

    public class PermissionRequiredAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            //查詢是否屬於不需要登陸的類，過濾
            var isDefined = false;
            var isNeedVarified = false;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                // look at if want a permission varified required.
                isNeedVarified = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                   .Any(a => a.GetType().Equals(typeof(PermissionRequiredAttribute)));
                if (!isNeedVarified)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                   .Any(a => a.GetType().Equals(typeof(NoPermissionRequiredAttribute)));
                //包含有匿名
                isDefined |= controllerActionDescriptor.MethodInfo.GetCustomAttributes(true).Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
            }
            if (isDefined || !isNeedVarified)//如果不需要驗證，直接返回
                return;

            base.OnActionExecuting(filterContext);
        }

    }

    //登录状态验证
    public class AdminLoginStateRequiredAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            //查詢是否屬於不需要登陸的類，過濾
            var isNeedVarified = true;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                //如果不是状态验证，跳过
                //需要驗證
                isNeedVarified = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                   .Any(a => a.GetType().Equals(typeof(AdminLoginStateRequiredAttribute)));
                if (!isNeedVarified)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }

            if (isNeedVarified && filterContext.HttpContext.Session.GetString("AdminUser") == null)
            {
                filterContext.Result = new RedirectResult("/AdminLogin");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }

    //不需要权限验证

    public class NoPermissionRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

    }


    //在不需要的方法上面打上标记

    // [NoPermissionRequired]
    //public ActionResult Login()

    //{
    //}
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class PermissionControlAttribute : Attribute
    {
        public string Description { set; get; }
        // public int ActionNo { set; get; }
        public virtual int GlobalNo { set; get; }


        /// <summary>
        /// Permission Action Name
        /// </summary>
        public string ChineseActionName { set; get; }
        public int isGet { set; get; }
        //控制显示再管理面板
        public int ShowInManagerBar { set; get; }
        public int VisitLevel { set; get; }


        public PermissionControlAttribute(int GlobalNo, string actionName, string description,
            int VisitLevel, int isGet, int ShowInManagerBar)
        {
            this.GlobalNo = GlobalNo;
            this.VisitLevel = VisitLevel;
            this.ChineseActionName = actionName;
            this.Description = description;
            this.isGet = isGet;
            this.ShowInManagerBar = ShowInManagerBar;

        }
    }

}
