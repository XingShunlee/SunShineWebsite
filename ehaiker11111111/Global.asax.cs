using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ehaiker.kefu;

namespace ehaiker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            webCounter gamewenzhan = new webCounter();
            gamewenzhan.DoCountEvent += Gamewenzhan_DoCountEvent;
            gamewenzhan.GetItemCountEvent += Gamewenzhan_GetItemCountEvent;
            gamewenzhan.StartWrite();
            Application.Add("gamewenzhan", gamewenzhan);
          //  CSService kfsvr = new CSService();
            //Application.Add("KFSVR", kfsvr);
        }

       

        protected void Application_End()
        {
            Application.Lock();
                webCounter tt =(webCounter)Application["gamewenzhan"];
                Application.Remove("gamewenzhan");
            Application.UnLock();
            tt.StopWrite();
            tt.accessTodayJob();
        }
        //自定义Forms验证：能让上面的页面代码发挥工作，必须在页面显示前重新设置HttpContext.User对象
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            MyFormsPrincipal<UserInfo>.TrySetUserInfo(app.Context);
        }
        public override void Init()
        {
            //注册事件
            this.AuthenticateRequest += WebApiApplication_AuthenticateRequest;
            base.Init();
        }
        //开启session支持
        void WebApiApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            //启用 webapi 支持session 会话
            HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }
       
        private void Gamewenzhan_DoCountEvent(object sender, CountItemdEventArgs<string> e)
        {
            try
            {
                int id = Convert.ToInt32(e.Value);
                ehaiker.Models.IRepository<GameStrategies> _noteRepository = new GameStrategiesRepository();
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
                if (notes != null)
                {
                    GameStrategies item = notes as GameStrategies;
                    item.readers = e.count;
                    _noteRepository.Update(item);
                }
            }
            catch
            {
                ;
            }
        }
        private void Gamewenzhan_GetItemCountEvent(object sender, CountItemdEventArgs<string> e)
        {
            int id = Convert.ToInt32(e.Value);
            ehaiker.Models.IRepository<GameStrategies> _noterepository = new GameStrategiesRepository();
            var notes = _noterepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
            if (notes != null)
            {
                GameStrategies item = notes as GameStrategies;
                e.count = item.readers + e.count;
            }
        }
    }
}