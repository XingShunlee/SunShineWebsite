using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ehaiker.Controllers;

namespace ehaiker.Auth
{
    public class InstallController 
    {
      //根据controller创建权限列表到数据库
        public static void   CreateDBPermission(Controller customController)
        {
             CreatePermission(customController);
              //  
             var roleApi = new RoleService();
        }
        private static void CreatePermission(Controller customController)
        {
          var roleApi = new RoleService();

            var controllerName = "";
            var controller = "";
            var controllerNo = 0;
            var actionName = "";
            var action = "";
            var actionNo = 0;
            var controllerDesc = new DescriptionAttribute();

            var controllerType = customController.GetType();

            //remove controller posfix
            controller = controllerType.Name.Replace("Controller", "");
            controllerDesc = Getdesc(controllerType);
            if (!string.IsNullOrEmpty(controllerDesc.Name))
            {
                controllerName = controllerDesc.Name.Trim();
                controllerNo = controllerDesc.No;
                foreach (var m in controllerType.GetMethods())
                {
                    var mDesc = GetPropertyDesc(m);
                    if (string.IsNullOrEmpty(mDesc.Name)) continue;
                    action = m.Name.Trim();
                    actionName = mDesc.Name.Trim();
                    actionNo = mDesc.No;
                    //添加项到数据库
                    roleApi.CreatePermissions(actionNo, controllerNo, actionName, controllerName, controller, action,mDesc.isGet,mDesc.ShowInMgrbar ) ;
                }
            }
        }
        private static DescriptionAttribute Getdesc(Type type)
        {
            var descriptionAttribute = (DescriptionAttribute)(type.GetCustomAttributes(false).FirstOrDefault(x => x is DescriptionAttribute));
            if (descriptionAttribute == null) return new DescriptionAttribute();
            return descriptionAttribute;
        }
        private static DescriptionAttribute GetPropertyDesc(System.Reflection.MethodInfo type)
        {
            var descriptionAttribute = (DescriptionAttribute)(type.GetCustomAttributes(false).FirstOrDefault(x => x is DescriptionAttribute));
            if (descriptionAttribute == null) return new DescriptionAttribute();
            return descriptionAttribute;
        }
        public static void InstallSQL()
        {
            //首页
            CreateDBPermission(new EHaikerController());
           
            //账单中心
            CreateDBPermission(new PayCenterController());
            //会员中心--单独检测
            //CreateDBPermission(new personalController());
            //管理中心
            CreateDBPermission(new AdminHomeController());
            //新闻中心
            CreateDBPermission(new NewsCenterController());
            //服务中心
            CreateDBPermission(new ServicesCenterController());
            //客服中心
            CreateDBPermission(new CSController());
        }
    }
    
}