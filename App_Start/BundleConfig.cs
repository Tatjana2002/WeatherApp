using System.Web;
using System.Web.Optimization;

namespace AplikacijaVremenskePrognoze
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-spacelab.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/ForecastForNext5Days")
            .Include("~/Scripts/ForecastForNext5Days.js"));

            bundles.Add(new ScriptBundle("~/bundles/ActiveButton")
            .Include("~/Scripts/ActiveButton.js"));

            bundles.Add(new ScriptBundle("~/bundles/Search")
            .Include("~/Scripts/Search.js"));
            bundles.Add(new ScriptBundle("~/bundles/Refresh")
           .Include("~/Scripts/Refresh.js"));
        }
    }
}
