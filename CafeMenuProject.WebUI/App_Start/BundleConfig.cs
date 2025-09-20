using System.Web.Optimization;

namespace CafeMenuProject.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Admin area bundles

            bundles.Add(new StyleBundle("~/bundles/admin/css").Include(
                "~/Content/adminlte/plugins/fontawesome-free/css/all.min.css",
                "~/Content/adminlte/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/Content/adminlte/dist/css/adminlte.min.css",
                "~/Content/adminlte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/Content/adminlte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                "~/Content/adminlte/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/jquery").Include(
                "~/Content/adminlte/plugins/jquery/jquery.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/jquery-ui-overlay").Include(
                "~/Content/adminlte/plugins/jquery-ui/jquery-ui.min.js",
                "~/Content/adminlte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/bootstrap").Include(
                "~/Content/adminlte/plugins/bootstrap/js/bootstrap.bundle.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/adminlte").Include(
                "~/Content/adminlte/dist/js/adminlte.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/datatables").Include(
                "~/Content/adminlte/plugins/datatables/jquery.dataTables.min.js",
                "~/Content/adminlte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                "~/Content/adminlte/plugins/datatables-responsive/js/dataTables.responsive.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/admin/moment").Include(
                "~/Content/adminlte/plugins/moment/moment.min.js"
            ));
            
            #endregion

            #region Other bundles

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #endregion
        }
    }
}
