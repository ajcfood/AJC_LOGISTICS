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
Go

/*
--SELECT * FROM [QuotingV2_UOMs]
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Weight','Total Weight (LB)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Volume','Total Volume (CuFT)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Volume (45LB)','Total Volume (CuFT w/45LB Rule)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Units','Unit Count',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Units (Oversize)','Oversized Unit Count',GetDate(),'SYSTEM');
*/