using System.Web;
using System.Web.Mvc;

namespace AJC.Logistics.SeaWideExpress.QuotingTool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}