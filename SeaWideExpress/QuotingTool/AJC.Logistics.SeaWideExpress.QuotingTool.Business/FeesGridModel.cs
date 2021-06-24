using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class FeesGridModel
    {
        public enum Mode {
            Fees,
            Ranges
        }

        public FeesGridModel(Mode GridMode)
        {
            this.GridMode = GridMode;
            this.FilterBy = new List<string>();
        }

        public FeesGridModel(Mode GridMode, IList<string> FilterBy)
        {
            this.GridMode = GridMode;
            this.FilterBy = FilterBy;
        }

        public Mode GridMode { get; set; }

        public IList<string> FilterBy { get; set; }
    }
}
