using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.Mvc;
using AJC.Logistics.SeaWideExpress.QuotingTool.Business;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class FeesByTypeController : Controller
    {
        public ActionResult Index() {
            Business.FeesMasterModel theModel = TempData["Model"] == null ? BuildModel() : (Business.FeesMasterModel)TempData["Model"];
            
            return View(theModel);
        }

        private FeesMasterModel BuildModel()
        {
            Business.FeesByTypeModel theModel = new FeesByTypeModel();
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                theModel.States = db.States.ToList();
                theModel.State = theModel.States.First().StateID.ToString();
                theModel.FeeTypes = db.FeeTypes.Where(feeType => feeType.ParentFeeTypeID == null).ToList();
            }
            theModel.FeesModel = new Business.FeesGridModel(Business.FeesGridModel.Mode.Fees, new List<string> { "ParentFeeID", "StateID", "FeeTypeID"});
            theModel.RangesModel = new Business.FeesGridModel(Business.FeesGridModel.Mode.Ranges, new List<string> { "ParentFeeID" });
            theModel.Title = "Master Tariff Rates";
            return theModel; 
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
