﻿using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.Objects.SqlClient;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;
using System;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections.Generic;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
   

    public class ParamsController : Controller
    {
        public ActionResult Index() {
            return View();
        }

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

        /// <summary>
        /// Get Actions_Fee entities for List of Values
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public JsonResult getActions()
        {
            using (QuotingToolRepository db = new QuotingToolRepository())
            {

                var fakeRepository = new List<ActionMock>();
                fakeRepository.Add(new ActionMock { ActionID = 1, Description = "Fee" });
                fakeRepository.Add(new ActionMock { ActionID = 2, Description = "Surcharge" });
                fakeRepository.Add(new ActionMock { ActionID = 3, Description = "Discount" });
                fakeRepository.Add(new ActionMock { ActionID = 4, Description = "Waiver" });

                var dataSet = fakeRepository.Select(action => new { value = action.ActionID, label = action.Description.Trim().ToUpper()}).ToList();
                return Json(dataSet, JsonRequestBehavior.AllowGet);
            }
        }
        public class ActionMock
        {
            public short? ActionID;
            public string Description;
        }

        #endregion
    }
}