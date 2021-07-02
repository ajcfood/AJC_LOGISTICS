using System.Web;
using System.Web.Optimization;

namespace AJC.Logistics.SeaWideExpress.QuotingTool
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            //bundles.Add(new ScriptBundle("~/js/Scripts/jQuery.smoothness/Minifyed").Include("~/Scripts/jQuery.smoothness/jquery-ui.js"));
            //bundles.Add(new StyleBundle("~/Scripts/jQuery.smoothness/Minifyed", "~/Scripts/jQuery.smoothness/jquery-ui.css"));


        }
    }
} 