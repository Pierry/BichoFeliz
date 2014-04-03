using System.Web.Optimization;

namespace BichoFelizMVC
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/body.css",
                "~/content/bootstrap/bootstrap.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/bootstrap-mvc-validation.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery-ui.css",
                "~/Content/themes/base/jquery-ui.all.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css"));
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-migrate-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/knockout-3.0.0.js",
                "~/Scripts/knockout-3.0.0.debug.js",
                "~/scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.unobtrusive-custom-for-bootstrap.js"
                ));
            bundles.Add(new ScriptBundle("~/usuarioViewModel").Include(
                "~/ViewModels/UsuarioViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/empresaViewModel").Include(
                "~/ViewModels/EmpresaViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/clienteViewModel").Include(
                "~/ViewModels/ClienteViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/animalViewModel").Include(
                "~/ViewModels/AnimalViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/tipoServicoViewModel").Include(
                "~/ViewModels/TipoServicoViewModel.js"
                ));
            bundles.Add(new ScriptBundle("~/servicoViewModel").Include(
                "~/ViewModels/ServicoViewModel.js"
                ));
        }
    }
}