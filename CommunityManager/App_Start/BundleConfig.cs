using System.Web;
using System.Web.Optimization;

namespace CommunityManager.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css/base").Include(
                "~/Content/css/base.css"));

            bundles.Add(new StyleBundle("~/Content/css/acceso").Include(
                "~/Content/css/acceso.css"));

            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include(
                "~/Scripts/jquery-2.1.3.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.backstretch.min.js"));
        }
    }
}