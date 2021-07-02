CREATE TABLE [dbo].[QuotingV2_Islands]
(
	[IslandID]	[int]         NOT NULL IDENTITY(1,1), 

	[StateID]	[varchar](2)  NOT NULL, 
    [Name]		[varchar](50) NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT [QuotingV2_Islands_PK] PRIMARY KEY ([IslandID]),
	CONSTRAINT [QuotingV2_Islands_Name_UK] UNIQUE ([StateID], [Name])
)
