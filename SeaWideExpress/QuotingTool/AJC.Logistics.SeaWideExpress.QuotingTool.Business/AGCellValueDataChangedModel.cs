using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class AGCellValueDataChangedModel
    {
        public string newValue { get; set; }
        public string oldValue { get; set; }
        public string field { get; set; }
        public int idEntity { get; set; }
    }
}
