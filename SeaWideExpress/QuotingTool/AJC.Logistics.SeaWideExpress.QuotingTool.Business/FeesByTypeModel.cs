﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AJC.Logistics.SeaWideExpress.QuotingTool.Models;


namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class FeesByTypeModel
    {
        public String State { get; set; }
        public String FeeType { get; set; }
        public String FeeSubType { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<FeeType> FeeTypes { get; set; }
        public IEnumerable<FeeType> FeeSubTypes { get; set; }
        public FeesGridModel FeesModel{ get; set; }
        public FeesGridModel RangesModel{ get; set; }

        public FeesByTypeModel()
        {
            this.FeeTypes    = new List<FeeType>();
            this.FeeSubTypes = new List<FeeType>();
        }
    }
}
