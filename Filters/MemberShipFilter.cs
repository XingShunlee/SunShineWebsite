using ehaiker;
using ehaiker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Filters
{
    //VIP分级会员验证
    public class VIPMembersRequiredAttribute : ActionFilterAttribute
    {
        private EhaikerContext DbContext;
        public VIPMembersRequiredAttribute(EhaikerContext _cont)
        {
            DbContext = _cont;
        }

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
                   .Any(a => a.GetType().Equals(typeof(VIPMembersRequiredAttribute)));
                if (!isNeedVarified)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }

            if (isNeedVarified && filterContext.HttpContext.Session.GetString("memshipUserInfo") == null)
            {
                filterContext.Result = new RedirectResult("/Account/NoAccessed");
                return;
            }
            MemberShip sessionUserInfo = MemUserDataManager.GetMemSessionData<MemberShip>(filterContext.HttpContext, "memshipUserInfo");
            if (sessionUserInfo != null)
            {
                if (sessionUserInfo.VIPLevel < 1)
                    return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
    //登录状态验证
    public class LoginStateRequiredAttribute : ActionFilterAttribute
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
                   .Any(a => a.GetType().Equals(typeof(LoginStateRequiredAttribute)));
                if (!isNeedVarified)
                {
                    base.OnActionExecuting(filterContext);
                    return;
                }
            }

            if (isNeedVarified && filterContext.HttpContext.Session.GetString("memshipUserInfo") == null)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    } //不需要登录
    public class NoLoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

    }
}
