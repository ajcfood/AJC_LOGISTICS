using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.Objects.SqlClient;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;
using System;
using Newtonsoft.Json;
using System.Reflection;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class FeesGridController : Controller
    {
        public ActionResult Index() {
            return View();
        }
        
        ///// <summary>
        ///// Get TestData entities for Ag-Grid
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[System.Web.Mvc.HttpPost]
        //public JsonResult getTestData([FromBody] Business.AGRequestModel request)
        //{
        //    using (QuotingToolRepository db = new QuotingToolRepository())
        //    {
        //        object entities = null;
        //        var repo = db.Test.Select(a => new { a.id, a.fechadesde, a.fechahasta, a.precio, a.zona, a.zonaDescripcion }).ToList();
                
        //        if (request.endRow == 0)
        //        {
        //            entities = repo;
        //        }
        //        else
        //        {
        //            var itemsToTake = (request.endRow >= repo.Count() ? repo.Count() : request.endRow) - request.startRow;
        //            entities = repo.Skip(request.startRow).Take(itemsToTake);
        //        }
        //        return Json(new { rows = entities, rowsTotalQuantity = repo.Count() } , JsonRequestBehavior.AllowGet);
        //    }
        //}

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
                var query = db.Fees.Select(fee => new Business.FeeDataModel
                {
                    FeeID = fee.FeeID,
                    ParentFeeID = fee.ParentFeeID,
                    FeeTypeID = fee.FeeTypeID,
                    StateID = fee.StateID,
                    IslandID = fee.IslandID,
                    CityID = fee.CityID,
                    ZoneID = fee.ZoneID,
                    ZipCodes = fee.ZipCodes,
                    Value = fee.Value,
                    ActionID = fee.ActionID,
                    ByUomID = fee.ByUomID,
                    Discount = fee.Discount,
                    FeeMin = fee.FeeMin,
                    FeeMax = fee.FeeMax,
                    ValidFrom = fee.ValidFrom,
                    ValidUntil = fee.ValidUntil,
                    RangeByUomID = fee.RangeByUomID,
                    RangeFrom = fee.RangeFrom,
                    RangeTo = fee.RangeTo
                });

                if (request.whereClause != null && request.whereClause.Length>0)
                {
                    foreach(Business.AGRequestModel.WherePredicate predicate in request.whereClause)
                    {
                        int  intTemp;
                        int? intValue = null;

                        switch (predicate.Field)
                        {
                            case "ParentFeeID":
                                if (Int32.TryParse(predicate.Value, out intTemp)) intValue = intTemp;
                                if (intValue == null)
                                    query = query.Where(fee => fee.ParentFeeID == null);
                                else
                                    query = query.Where(fee => fee.ParentFeeID == intValue);
                                break;

                            case "StateID":
                                if (Int32.TryParse(predicate.Value, out intTemp)) intValue = intTemp;
                                if (intValue != null) query = query.Where(fee => fee.StateID == intValue);
                                break;

                            case "FeeTypeID":
                                if (Int32.TryParse(predicate.Value, out intTemp)) intValue = intTemp;
                                if (intValue != null) query = query.Where(fee => fee.FeeTypeID == intValue);
                                break;

                            case "ByUomID":
                                if (Int32.TryParse(predicate.Value, out intTemp)) intValue = intTemp;
                                if (intValue != null) query = query.Where(fee => fee.ByUomID == intValue);

                                break;
                        } 
                    }
                }
                var repo = query.ToList();
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
        /// Update or creates an entire FeeData Entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult updateFeeRepository([FromBody] Business.FeeDataModel request)
        {
            var respuesta = new { idEntity = request.FeeID, idEntityRequest = request.FeeID, message = "OK", error = "", DataReceived = request, OldData = "" };
            Fees oldData = null;
            using (QuotingToolRepository db = new QuotingToolRepository())
            {
                try
                {
                    var FeeData = request.FeeID > 0 ? db.Fees.Where(i => i.FeeID == request.FeeID).Single() : new Fees();
                    oldData = FeeData;
                    if (request.FeeID > 0)
                    {
                        FeeData.DateUpdated = System.DateTime.Now;
                        FeeData.UpdatedBy = "SYSTEM"; // Replace with the right identity,
                    }
                    else
                    {
                        FeeData.DateAdded = System.DateTime.Now;
                        FeeData.AddedBy = "SYSTEM"; // Replace with the right identity,
                    }

                    FeeData.FeeID       = request.FeeID;
                    FeeData.ParentFeeID = request.ParentFeeID;
                    FeeData.FeeTypeID   = request.FeeTypeID;
                    FeeData.ByUomID  = request.ByUomID;
                    FeeData.CityID   = request.CityID;
                    FeeData.StateID  = request.StateID;
                    FeeData.Discount = request.Discount;
                    FeeData.IslandID = request.IslandID;
                    FeeData.ActionID = request.ActionID;
                    FeeData.Value    = request.Value;
                    FeeData.ZipCodes = request.ZipCodes;
                    FeeData.FeeMin = request.FeeMin;
                    FeeData.FeeMax = request.FeeMax;
                    FeeData.RangeFrom = request.RangeFrom;
                    FeeData.RangeTo = request.RangeTo;
                    FeeData.ValidFrom = request.ValidFrom;
                    FeeData.ValidUntil = request.ValidUntil;

                    if (request.FeeID < 0 && Helpers.NewEntityCreationHelper.CheckMandatoryFields(FeeData, typeof(Fees)))
                        db.Fees.AddObject(FeeData);

                    if (db.SaveChanges() > 0)
                        respuesta = new { idEntity = FeeData.FeeID, idEntityRequest = request.FeeID, message = "OK", error = "", DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    respuesta = new { idEntity = request.FeeID, idEntityRequest = request.FeeID, message = "ERROR", error = ex.Message, DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
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
            var respuesta = new { idEntity = request.idEntity, message = "OK", error = "", DataReceived = request, OldData = "" };
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
                        respuesta = new { idEntity = request.idEntity, message = "OK", error = "", DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 500;
                    respuesta = new { idEntity = request.idEntity, message = "ERROR", error = ex.Message + System.Environment.NewLine + ex.InnerException?.Message, DataReceived = request, OldData = JsonConvert.SerializeObject(oldData) };
                }
            }

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

		[System.Web.Mvc.HttpPost]
        public JsonResult removeFeeData([FromBody] int[] ids) {
            var respuesta = new { message = "OK", error = "", DataReceived = JsonConvert.SerializeObject(ids), OldData = "" };
            try
            {
                using (QuotingToolRepository db = new QuotingToolRepository())
                {
                    foreach (int id in ids)
                    {
                        db.Fees.DeleteObject(db.Fees.Where(i => i.FeeID == id).Single());
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                respuesta = new { message = "ERROR", error = ex.Message, DataReceived = JsonConvert.SerializeObject(ids), OldData = "" };
            }
            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
