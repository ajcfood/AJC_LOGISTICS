CREATE TABLE [dbo].[QuotingV2_Cities]
(
	[CityID]	[int]			NOT NULL IDENTITY(1,1), 

	[StateID]	[int]			NOT NULL, 
	[IslandID]	[int]			NULL,
    [Name]		[varchar](50)	NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL,

	-- Constraints
	CONSTRAINT [QuotingV2_Cities_PK] PRIMARY KEY ([CityID]),
	CONSTRAINT [QuotingV2_Cities_Name_UK] UNIQUE ([StateID], [Name]),

	CONSTRAINT [QuotingV2_Cities_State_FK] 
		FOREIGN KEY ([StateID]) 
		REFERENCES [QuotingV2_States]([StateID]),

	CONSTRAINT [QuotingV2_Cities_Island_FK] 
		FOREIGN KEY ([IslandID]) 
		REFERENCES [QuotingV2_Islands]([IslandID]),

)
