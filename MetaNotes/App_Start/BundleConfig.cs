using System.Web.Optimization;

namespace MetaNotes
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/main").Include(
                        "~/Scripts/jquery*",
                        "~/Scripts/bootstrap*"));

            bundles.Add(new StyleBundle("~/bundles/styles/main").Include(
                "~/Content/Styles/bootstrap/bootstrap*"));
        }
    }
}
