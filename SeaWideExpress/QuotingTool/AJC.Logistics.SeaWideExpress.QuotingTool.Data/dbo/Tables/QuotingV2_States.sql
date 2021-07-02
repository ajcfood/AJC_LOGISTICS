CREATE TABLE [dbo].[QuotingV2_States]
(
	[StateID]		[int]			NOT NULL IDENTITY(1,1), 
	
	[Code]			[varchar](10)	NULL,
    [Name]			[varchar](50)	NOT NULL,

	[CountryID]		[int]			NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL

	-- Constraints
	CONSTRAINT [QuotingV2_States_PK] PRIMARY KEY ([StateID]),
	CONSTRAINT [QuotingV2_States_Name_UK] UNIQUE ([CountryID], [Name]),

	CONSTRAINT [QuotingV2_States_Country_FK] 
		FOREIGN KEY ([CountryID]) 
		REFERENCES [QuotingV2_Countries]([CountryID]),
)
