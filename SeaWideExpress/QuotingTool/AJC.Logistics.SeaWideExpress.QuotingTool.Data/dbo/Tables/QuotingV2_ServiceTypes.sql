CREATE TABLE [QuotingV2_ServiceTypes]
(
	[ServiceTypeID]	[int]	IDENTITY(1,1)	NOT NULL,

	[Name]			[varchar](100)			NOT NULL,
	[Description]	[varchar](400)			NULL,

	[Show]          [varchar](1)    NOT NULL DEFAULT 'Y',
	[Position]      [int]			NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT QuotingV2_ServiceTypes_PK		PRIMARY KEY([ServiceTypeID]),
	CONSTRAINT QuotingV2_ServiceTypes_Name_UK	UNIQUE ([Name])
)