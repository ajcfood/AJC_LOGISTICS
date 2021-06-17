CREATE TABLE [dbo].[QuotingV2_ZipCodes]
(
	[CountryID]	[int]			NOT NULL, 
	[ZipCode]	[int]			NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL,

	-- Constraints
	CONSTRAINT [QuotingV2_ZipCodes_PK] PRIMARY KEY ([CountryID], [ZipCode]),

	CONSTRAINT [QuotingV2_ZipCodes_Country_FK] 
		FOREIGN KEY ([CountryID]) 
		REFERENCES [QuotingV2_Countries]([CountryID])
)
