CREATE TABLE [QuotingV2_UOMs]
(
	[UomID]		[int]	IDENTITY(1,1)	NOT NULL,

	[Name]			[varchar](100)			NOT NULL,
	[Description]	[varchar](400)			NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT [QuotingV2_UOMs_PK]	PRIMARY KEY([UomID]),
	CONSTRAINT [QuotingV2_UOMs_UK]	UNIQUE ([Name])
)