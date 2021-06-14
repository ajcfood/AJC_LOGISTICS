using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class AGController : Controller
    {
        public ActionResult Index() {
            return View();
        }
        
        /// <summary>
        /// Get TestData entities for Ag-Grid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult getTestData([FromBody] Business.AGRequestModel request)
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                object entities = null;
                var repo = db.Test.Select(a => new { a.id, a.fechadesde, a.fechahasta, a.precio, a.zona, a.zonaDescripcion }).ToList();
                
                if (request.endRow == 0)
                {
                    entities = repo;
                }
                else
                {
                    var itemsToTake = (request.endRow >= repo.Count() ? repo.Count() : request.endRow) - request.startRow;
                    entities = repo.Skip(request.startRow).Take(itemsToTake);
                }
                return Json(new { rows = entities, rowsTotalQuantity = repo.Count() } , JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get TestData entities for Ag-Grid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult getFeeData([FromBody] Business.AGRequestModel request)
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                object entities = null;
                var repo = db.Fees.Select(fee => new { 
                    id = fee.FeeID, 
                    state = fee.State,
                    island = fee.IslandID, 
                    city = fee.CityID,
                    zipCodes = fee.ZipCodes,
                    fee = fee.Fee,
                    discount = fee.Discount,
                    feeMin = fee.FeeMin,
                    feeMax = fee.FeeMax,
                    validFrom = fee.ValidFrom, 
                    validTo = fee.ValidUntil 
                }).ToList();

                if (request.endRow == 0)
                {
                    entities = repo;
                }
                else
                {
                    var itemsToTake = (request.endRow >= repo.Count() ? repo.Count() : request.endRow) - request.startRow;
                    entities = repo.Skip(request.startRow).Take(itemsToTake);
                }
                return Json(new { rows = entities, rowsTotalQuantity = repo.Count() }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
