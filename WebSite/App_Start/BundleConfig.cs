using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            #region Css
            bundles.Add(new StyleBundle("~/SiteCss").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-material-design.min.css",                
                "~/Content/font-awesome.css",
                "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/LoginCss").Include(
                "~/Content/Login/login.css"));

            #endregion

            #region JS

            bundles.Add(new ScriptBundle("~/SiteJs").Include(
                "~/Scripts/jquery-1.11.1.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.metisMenu.js",
                "~/Scripts/material.min.js",                
                "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/LoginJs").Include(
                "~/Scripts/Login/login.js"));

            bundles.Add(new ScriptBundle("~/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.validate.extensions.js"));

            #endregion

        }
    }
}
