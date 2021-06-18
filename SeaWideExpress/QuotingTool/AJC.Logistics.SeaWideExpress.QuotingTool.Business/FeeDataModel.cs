using System;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
    public class FeeDataModel
    {

		public int id { get; set; }
		public int? state { get; set; }
		public int? island { get; set; }
        public int? uom { get; set; }
		public string  zipCodes { get; set; }
		public string zone { get; set; }
		public int? city{ get; set; }
		public decimal? fee{ get; set; }
		public int per{ get; set; }
		public decimal? discount { get; set; }
		public decimal?  feeMin { get; set; }
		public decimal?  feeMax { get; set; }
		public string addedBy { get; set; }
		public DateTime?  validFrom { get; set; }
		public DateTime?  validTo { get; set; }
    }
}