using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web.Mvc;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class FeesByCustomerController : Controller
    {
        public ActionResult Index() {
            Business.FeesByCustomerModel theModel = new Business.FeesByCustomerModel();

            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var customers = db.vw_Customers.ToList();
                customers.Add(new vw_Customers { Name = "--All--"});
                theModel.States    = db.States.ToList();
                theModel.State     = theModel.States.First().StateID.ToString();
                theModel.FeeTypes  = db.FeeTypes.Where(feeType => feeType.ParentFeeTypeID == null).ToList();
                theModel.Customers = customers.ToList();
            }

            theModel.FeesModel   = new Business.FeesGridModel(Business.FeesGridModel.Mode.Fees  , new List<string> { "ParentFeeID", "StateID", "CustomerID" });
            theModel.RangesModel = new Business.FeesGridModel(Business.FeesGridModel.Mode.Ranges, new List<string> { "ParentFeeID" });
            theModel.Title = "Rate Adjustments by Customer";
            
            TempData["Model"] = theModel;

            TempData["ShowCustomer"] = false;
            return RedirectToAction("Index", "FeesByType");
        }
    }
}
