using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;


namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public abstract class FeesMasterModel {
        public String State { get; set; }
        public String FeeType { get; set; }
        public String FeeSubType { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<FeeType> FeeTypes { get; set; }
        public IEnumerable<FeeType> FeeSubTypes { get; set; }
        public IEnumerable<int> Periods
        {
            get
            {
                List<int> response = new List<int>();
                for (int year = 2020; year <= DateTime.Now.Year + 1; year++)
                    response.Add(year);
                return response;
            }
        }
        public FeesGridModel FeesModel { get; set; }
        public FeesGridModel RangesModel { get; set; }
        public IEnumerable<vw_Customers> Customers { get; set; }
        public string Title { get; set; }
    }
    
    
    public class FeesByTypeModel : FeesMasterModel
    {

        public FeesByTypeModel()
        {
            this.FeeTypes    = new List<FeeType>();
            this.FeeSubTypes = new List<FeeType>();

        }
    }



    public class FeesByCustomerModel : FeesMasterModel
    { 
        
        public FeesByCustomerModel() {
            this.FeeTypes = new List<FeeType>();
            this.FeeSubTypes = new List<FeeType>();
            Customers = new List<vw_Customers>();
        }
    }
}
