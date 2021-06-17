CREATE TABLE [dbo].[QuotingV2_Zones]
(
	[ZoneID]	[int]			NOT NULL IDENTITY(1,1), 

	[StateID]	[int]			NOT NULL,
	[IslandID]	[int]			NULL, 
	[CityID]	[int]			NULL, 
	[Code]		[varchar](10)	NOT NULL,
    [Name]		[varchar](50)	NOT NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL,

	-- Constraints
	CONSTRAINT [QuotingV2_Zones_PK] PRIMARY KEY ([ZoneID]),
	CONSTRAINT [QuotingV2_Zones_Code_UK] UNIQUE ([StateID], [IslandID], [CityID], [Code]),
	CONSTRAINT [QuotingV2_Zones_Name_UK] UNIQUE ([StateID], [IslandID], [CityID], [Name]),

	CONSTRAINT [QuotingV2_Zones_State_FK] 
		FOREIGN KEY ([StateID]) 
		REFERENCES [QuotingV2_States]([StateID]),

	CONSTRAINT [QuotingV2_Zones_Island_FK] 
		FOREIGN KEY ([IslandID]) 
		REFERENCES [QuotingV2_Islands]([IslandID]),

	CONSTRAINT [QuotingV2_Zones_City_FK] 
		FOREIGN KEY ([CityID]) 
		REFERENCES [QuotingV2_Cities]([CityID]),
)
