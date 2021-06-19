using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class AGRequestModel
    {
        /// <summary>
        /// Used for pagination, this is the FIRST row of the collection.
        /// </summary>
        public int startRow { get; set; }

        /// <summary>
        /// Used for pagination, this is the LAST row of the collection.
        /// </summary>
        public int endRow { get; set; }

        public string[] rowGroupCols { get; set; }
        public string[] valueCols { get; set; }
        public string[] pivotCols { get; set; }
        public bool pivotMode { get; set; }
        public string[] groupKeys { get; set; }
        public FilterModel filterModel { get; set; }
        public string[] sortModel { get; set; }
        public WherePredicate[] whereClause { get; set; }

        public class WherePredicate
        {
            public String Field { set; get; }
            public String Value { set; get; }
            public String[] Values { set; get; }
        }

        public class FilterModel
        {
        }
    }

    
}
