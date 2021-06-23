using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.Mvc;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class FeesByTypeController : Controller
    {
        public ActionResult Index() {
            Business.RatesAndRangesModel theModel = new Business.RatesAndRangesModel();

            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                theModel.States   = db.States.ToList();
                theModel.State    = theModel.States.First().StateID.ToString();
                theModel.FeeTypes = db.FeeTypes.Where(feeType => feeType.ParentFeeTypeID == null).ToList();
            }
            theModel.RatesModel  = new Business.AGGridConfigurationModel(Business.AGGridConfigurationModel.Mode.Rates);
            theModel.RangesModel = new Business.AGGridConfigurationModel(Business.AGGridConfigurationModel.Mode.Ranges);

            return View(theModel);
        }

        [HttpGet]
        public JsonResult GetFeeSubTypes(int? feeTypeID)
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var subTypesList = db.FeeTypes.Where(feeType => feeType.ParentFeeTypeID == feeTypeID)
                    .Select(feeType => new SelectListItem { Value = SqlFunctions.StringConvert((double)feeType.FeeTypeID), Text = feeType.Name })
                    .ToList();

                return Json(subTypesList, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
