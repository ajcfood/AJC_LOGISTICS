using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult GeneralError(string httpStatusCode)
        {
            ViewBag.Description = httpStatusCode;
            try
            {
                Response.StatusCode = Convert.ToInt32(httpStatusCode);
            }
            catch { }
            return this.View();
        }
    }
}
