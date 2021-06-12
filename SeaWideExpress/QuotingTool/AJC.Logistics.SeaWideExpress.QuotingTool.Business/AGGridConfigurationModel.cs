using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class AGGridConfigurationModel
    {
        public enum Mode { 
            Rates,
            Ranges
        }
        public Mode GridMode{ get; set; }
    }
}
