using System.Web.Mvc;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            Business.AGGridConfigurationModel theModel = new Business.AGGridConfigurationModel();
            theModel.GridMode =  Business.AGGridConfigurationModel.Mode.Ranges;

            return View(theModel);
        }
    }
}
