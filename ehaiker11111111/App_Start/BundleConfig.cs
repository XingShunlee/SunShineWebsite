using System.Web;
using System.Web.Optimization;

namespace ehaiker
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = false;
            //jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery", "//cdn.bootcss.com/jquery/3.2.1/jquery.min.js").Include(
                        "~/Scripts/jquery-{version}.js"));
            //bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "//cdn.bootcss.com/bootstrap/4.0.0-beta/js/bootstrap.min.js").Include(
                      "~/Scripts/bootstrap.js"));
            //bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap1", "https://cdn.bootcss.com/popper.js/1.15.0/esm/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap2", "https://cdn.bootcss.com/popper.js/1.10.0/umd/popper.min.js"));
            //vue
            bundles.Add(new ScriptBundle("~/bundles/vue", "https://cdn.jsdelivr.net/npm/vue/dist/vue.js").Include(
                       "~/Scripts/vue.js"));
            //css
            bundles.Add(new StyleBundle("~/Content/css", "//maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"
                      )
                      );
        }
    }
}