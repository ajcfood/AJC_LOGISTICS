--DROP TABLE [QuotingV2_Fees]
CREATE TABLE [QuotingV2_Fees]
(
	[FeeID]			[int] IDENTITY(1,1) NOT NULL,
	[FeeTypeID]		[int]				NOT NULL,

	[State]			[varchar](2)	NULL,
	[IslandID]		[int]			NULL,
	[ZoneID]		[int]			NULL,
	[CityID]		[int]			NULL,
	[ZipCodes]		[varchar](4000)	NULL,
	[CustomerID]	[int]			NULL,

	-- Fee by "unit of meassure" and Discount
	[Fee]			[decimal](5, 2) NULL,
	[ByUomID]		[int]			NULL,
	[Discount]		[decimal](3, 3) NULL,

	-- Fee limits
	[FeeMin]		[decimal](7, 2) NULL,
	[FeeMax]		[decimal](7, 2) NULL,

	-- Ranges by "unit of meassure" + hierarchy
	[RangeByUomID]	[int]			NULL,
	[ParentFeeID]	[int]			NULL,
	[RangeFrom]		[decimal](7, 2) NULL,
	[RangeTo]		[decimal](7, 2) NULL,

	-- Validity and Notes
	[ValidFrom]		[datetime]		NULL,
	[ValidUntil]	[datetime]		NULL,
	[Notes]			[varchar](100)	NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT [QuotingV2_Fees_PK] PRIMARY KEY ([FeeID]),

	CONSTRAINT [QuotingV2_Fees_Types_FK] 
		FOREIGN KEY ([FeeTypeID]) 
		REFERENCES [QuotingV2_FeeTypes]([FeeTypeID]),

	CONSTRAINT [QuotingV2_Fees_Uom_FK] 
		FOREIGN KEY ([ByUomID]) 
		REFERENCES [QuotingV2_UOMs]([UomID]),

	CONSTRAINT [QuotingV2_Fees_RangeUom_FK] 
		FOREIGN KEY ([RangeByUomID]) 
		REFERENCES [QuotingV2_UOMs]([UomID]),

	CONSTRAINT [QuotingV2_Fees_Parent_FK] 
		FOREIGN KEY ([ParentFeeID]) 
		REFERENCES [QuotingV2_Fees]([FeeID])
)