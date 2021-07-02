--DROP TABLE [QuotingV2_FeeTypes]
--DROP TABLE [QuotingV2_FeeSubTypes]
CREATE TABLE [QuotingV2_FeeTypes]
(
	[FeeTypeID]	[int]	IDENTITY(1,1)	NOT NULL,

	[Name]			[varchar](100)		NOT NULL,
	[Description]	[varchar](400)		NULL,

	-- Hierarchy
	[ParentFeeTypeID]	[int]		NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT QuotingV2_FeeTypes_PK		PRIMARY KEY([FeeTypeID]),

	CONSTRAINT QuotingV2_FeeTypes_Name_UK	UNIQUE ([ParentFeeTypeID], [Name]),

	CONSTRAINT [QuotingV2_FeeTypes_Parent_FK] 
		FOREIGN KEY ([ParentFeeTypeID]) 
		REFERENCES [QuotingV2_FeeTypes]([FeeTypeID]),
)