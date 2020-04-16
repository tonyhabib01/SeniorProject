using System.Web;
using System.Web.Optimization;

namespace GymApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
              bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/DataTables/jquery.datatables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/jquery-ui-1.12.1/jquery-ui.js"));              
              
              bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/bootstrap/js/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Scripts/jquery-ui-1.12.1/jquery-ui.css",
                      "~/Content/datatables/css/dataTables.bootstrap4.css"));
        }
    }
}
