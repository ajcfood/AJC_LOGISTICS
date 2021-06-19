using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;
using System;
using Newtonsoft.Json;
using System.Reflection;

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
                var repo = db.Fees.Select(fee => new Business.FeeDataModel
                {
                    FeeID = fee.FeeID,
                    StateID = fee.StateID,
                    IslandID = fee.IslandID,
                    CityID = fee.CityID,
                    ZoneID = fee.ZoneID,
                    ZipCodes = fee.ZipCodes,
                    Value = fee.Value,
                    ByUomID = fee.ByUomID,
                    Discount = fee.Discount,
                    FeeMin = fee.FeeMin,
                    FeeMax = fee.FeeMax,
                    ValidFrom = fee.ValidFrom,
                    ValidUntil = fee.ValidUntil,
                    RangeFrom = fee.RangeFrom,
                    RangeTo = fee.RangeTo
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
        /// Update entire FeeData Entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult updateFeeData([FromBody] Business.FeeDataModel request)
        {
            var respuesta = new { message = "OK", error = "", DataReceived = request, OldData = "" };
            Fees oldData = null;
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                try
                {
                    var FeeData = request.FeeID > -1 ? db.Fees.Where(i => i.FeeID == request.FeeID).Single() : new Fees();
                    oldData = FeeData;
                    if (request.FeeID > -1)
                    {
                        FeeData.DateUpdated = System.DateTime.Now;
                        FeeData.UpdatedBy = "Admin"; // Replace with the right identity,
                    }
                    else
                    {
                        FeeData.DateAdded = System.DateTime.Now;
                        FeeData.AddedBy = "Admin"; // Replace with the right identity,
                    }

                    FeeData.ByUomID = request.ByUomID;
                    FeeData.CityID = request.CityID;
                    FeeData.StateID = request.StateID;
                    FeeData.Discount = request.Discount;
                    FeeData.IslandID = request.IslandID;
                    FeeData.Value = request.FeeID;
                    FeeData.ZipCodes = request.ZipCodes;
                    FeeData.FeeMin = request.FeeMin;
                    FeeData.FeeMax = request.FeeMax;
                    FeeData.ValidFrom = request.ValidFrom;
                    FeeData.ValidUntil = request.ValidUntil;
                    if (request.FeeID == -1)
                        db.Fees.AddObject(FeeData);

                    if (db.SaveChanges() > 0)
                        respuesta = new { message = "OK", error = "", DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    respuesta = new { message = "ERROR", error = ex.Message, DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Update just one FeeData's field
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult updateSingleFieldFeeData([FromBody] Business.AGCellValueDataChangedModel request)
        {
            var respuesta = new { message = "OK", error = "", DataReceived = request, OldData = "" };
            Fees oldData = null;
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                try
                {
                    var FeeData = request.idEntity > -1 ? db.Fees.Where(i => i.FeeID == request.idEntity).Single() : new Fees();
                    oldData = FeeData;
                    if (request.idEntity > -1)
                    {
                        FeeData.DateUpdated = System.DateTime.Now;
                        FeeData.UpdatedBy = "System"; // Replace with the right identity,
                    }
                    else
                    {
                        FeeData.DateAdded = System.DateTime.Now;
                        FeeData.AddedBy = "System"; // Replace with the right identity,
                    }

                    var properties = typeof(Fees).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var property in properties)
                    {
                        if (request.field == property.Name)
                        {
                            property.SetValue(FeeData, Helpers.TypesHelper.ChangeType(request.newValue, property.PropertyType), null);
                            break;
                        }
                    }

                    if (request.idEntity == -1)
                        db.Fees.AddObject(FeeData);

                    if (db.SaveChanges() > 0)
                        respuesta = new { message = "OK", error = "", DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    respuesta = new { message = "ERROR", error = ex.Message + System.Environment.NewLine + ex.InnerException?.Message, DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
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
