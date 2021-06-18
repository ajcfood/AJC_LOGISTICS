using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;
using System;
using Newtonsoft.Json;

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

        #region FeeData
        /// <summary>
        /// Get FeeData entities for Ag-Grid
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult getFeeData([FromBody] Business.AGRequestModel request)
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                object entities = null;
                var repo = db.Fees.Select(fee => new Business.FeeDataModel {
                    id = fee.FeeID,
                    state = fee.StateID,
                    island = fee.IslandID,
                    city = fee.CityID,
                    zipCodes = fee.ZipCodes,
                    fee = fee.Value,
                    uom = fee.ByUomID,
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
                return Json(new { rows = entities, rowsTotalQuantity = repo.Count()}, JsonRequestBehavior.AllowGet);
            }
        }

        
        /// <summary>
        /// Update FeeData
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult updateFeeData([FromBody] Business.FeeDataModel request) {
            var respuesta = new { message = "OK", error = "", DataReceived = request, OldData = "" };
            Fees oldData = null;
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                try
                {
                    var FeeData = request.id > -1 ? db.Fees.Where(i => i.FeeID == request.id).Single() : new Fees();
                    oldData = FeeData;
                    if (request.id > -1)
                    {
                        FeeData.DateUpdated = System.DateTime.Now;
                        FeeData.UpdatedBy = "Admin"; // Replace with the right identity,
                    }
                    else
                    {
                        FeeData.DateAdded = System.DateTime.Now;
                        FeeData.AddedBy = "Admin"; // Replace with the right identity,
                    }

                    FeeData.ByUomID = request.uom;
                    FeeData.CityID = request.city;
                    FeeData.StateID = request.state;
                    FeeData.Discount = request.discount;
                    FeeData.IslandID = request.island;
                    FeeData.Value = request.fee;
                    FeeData.ZipCodes = request.zipCodes;
                    FeeData.FeeMin = request.feeMin;
                    FeeData.FeeMax = request.feeMax;
                    FeeData.ValidFrom = request.validFrom;
                    FeeData.ValidUntil = request.validTo;
                    if (request.id == -1)
                        db.Fees.AddObject(FeeData);
                    
                    if(db.SaveChanges() > 0)
                        respuesta = new { message = "OK", error = "", DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
                catch (Exception ex) {
                    Response.StatusCode = 500;
                    respuesta = new { message = "ERROR", error = ex.Message, DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Get Simple Data
        /// <summary>
        /// Get Country entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getCountries()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var dataSet = db.Countries.Select(country => new {value = country.CountryID, label = country.Name.Trim().ToUpper()}).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get State entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getStates()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var dataSet = db.States.Select(state => new { value = state.StateID, label = state.Name.Trim().ToUpper() }).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get Island entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getIslands()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var dataSet = db.Islands.Select(island => new { value = island.IslandID, label = island.Name.Trim().ToUpper() }).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get City entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getCities()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var dataSet = db.Cities.Select(city => new { value = city.CityID, label = city.Name.Trim() }).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get UOM entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getUoms()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                var dataSet = db.UOMs.Select(uom => new { value = uom.UomID, label = uom.Name.Trim().ToUpper() }).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}
