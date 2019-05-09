using System.Web.Optimization;

namespace SocialCareProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-notify.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",

                      "~/Content/general_styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.mapping-latest.js"));
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/common.js"));
            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
            "~/Scripts/bootstrap-datepicker.js"));

            //sass
            bundles.Add(new StyleBundle("~/Content/customer_styles").Include(
                "~/Content/custom/customer_styles.css"));
            bundles.Add(new StyleBundle("~/Content/provider_styles").Include(
                "~/Content/custom/provider_styles.css"));
            bundles.Add(new StyleBundle("~/Content/worker_styles").Include(
                "~/Content/custom/worker_styles.css"));
            bundles.Add(new StyleBundle("~/Content/administration_styles").Include(
                "~/Content/custom/administration_styles.css"));

            bundles.Add(new StyleBundle("~/Content/accessdenied").Include(
                "~/Content/accessdenied.css"));

        }
    }
}
