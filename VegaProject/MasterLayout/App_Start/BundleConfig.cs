using System.Web;
using System.Web.Optimization;

namespace MasterLayout
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

          
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/umd/popper.min.js",
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                         "~/Scripts/angular.js"));
            bundles.Add(new ScriptBundle("~/bundles/angularCodeRole").Include(
                       "~/Scripts/angularCode.js"));
        }
    }
}
