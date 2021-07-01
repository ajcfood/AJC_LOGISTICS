using System;

namespace AJC.Logistics.SeaWideExpress.QuotingTool.Business
{
	public class FeeDataModel
	{
		public int FeeID { get; set; }
		public int? ParentFeeID { get; set; }
		public int FeeTypeID { get; set; }
		public int? StateID { get; set; }
		public int? IslandID { get; set; }
		public int? ZoneID { get; set; }
		public int? ByUomID { get; set; }
		public string ZipCodes { get; set; }
		public int? CityID { get; set; }
		public decimal? Value { get; set; }
		public int per { get; set; }
		public decimal? Discount { get; set; }
		public decimal? FeeMin { get; set; }
		public decimal? FeeMax { get; set; }
		public string addedBy { get; set; }
		public DateTime? ValidFrom { get; set; }
		public DateTime? ValidUntil { get; set; }
		public string changedField { get; set; }
		public int? RangeByUomID { get; set; }
		public decimal? RangeFrom { get; set; }
		public decimal? RangeTo { get; set; }
		public short? ActionID { get; set; }
	}
}