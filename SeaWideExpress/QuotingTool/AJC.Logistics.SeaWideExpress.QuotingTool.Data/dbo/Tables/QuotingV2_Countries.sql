CREATE TABLE [dbo].[QuotingV2_Countries]
(
	[CountryID]		[int]			NOT NULL IDENTITY(1,1), 

    [ShortCode]		[varchar](2)    NOT NULL,
    [LongCode]		[varchar](3)    NOT NULL,
    [Name]			[varchar](50)   NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT [QuotingV2_Countries_PK] PRIMARY KEY ([CountryID]),
	CONSTRAINT [QuotingV2_Countries_SCode_UK] UNIQUE ([ShortCode]),
	CONSTRAINT [QuotingV2_Countries_LCode_UK] UNIQUE ([LongCode])
)
