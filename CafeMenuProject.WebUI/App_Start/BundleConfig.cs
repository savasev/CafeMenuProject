using System.Web.Optimization;

namespace CafeMenuProject.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/adminlte/css").Include(
                "~/Content/adminlte/plugins/fontawesome-free/css/all.min.css",
                "~/Content/adminlte/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                "~/Content/adminlte/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/Content/adminlte/plugins/jqvmap/jqvmap.min.css",
                "~/Content/adminlte/dist/css/adminlte.min.css",
                "~/Content/adminlte/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/Content/adminlte/plugins/daterangepicker/daterangepicker.css",
                "~/Content/adminlte/plugins/summernote/summernote-bs4.min.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/adminlte/js").Include(
                "~/Content/adminlte/plugins/jquery/jquery.min.js",
                "~/Content/adminlte/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/adminlte/plugins/chart.js/Chart.min.js",
                "~/Content/adminlte/plugins/sparklines/sparkline.js",
                "~/Content/adminlte/plugins/jqvmap/jquery.vmap.min.js",
                "~/Content/adminlte/plugins/jqvmap/maps/jquery.vmap.usa.js",
                "~/Content/adminlte/plugins/jquery-knob/jquery.knob.min.js",
                "~/Content/adminlte/plugins/moment/moment.min.js",
                "~/Content/adminlte/plugins/daterangepicker/daterangepicker.js",
                "~/Content/adminlte/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/Content/adminlte/plugins/summernote/summernote-bs4.min.js",
                "~/Content/adminlte/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                "~/Content/adminlte/dist/js/adminlte.js",
                "~/Content/adminlte/dist/js/demo.js",
                "~/Content/adminlte/dist/js/pages/dashboard.js"
            ));
        }
    }
}
