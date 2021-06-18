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

        public AGGridConfigurationModel(Mode GridMode)
        {
            this.GridMode = GridMode;
        }

        public Mode GridMode{ get; set; }
    }
}
