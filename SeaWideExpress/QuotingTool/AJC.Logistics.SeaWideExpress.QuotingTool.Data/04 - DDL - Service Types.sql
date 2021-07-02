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
Go

/*
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Will Call', 'Will Call', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Hazardous Materials', 'Hazardous Materials', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Lift Gate', 'Lift Gate', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Inside Delivery', 'Inside Delivery', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Residential', 'Residential', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Excessive Length', 'Excessive Length', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Limited Access', 'Limited Access', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Appointment', 'Appointment', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Notification', 'Notification', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Collect on Delivery', 'Collect on Delivery', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Military Delivery', 'Military Delivery', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Mine Site Delivery', 'Mine Site Delivery', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Oil Field Location', 'Oil Field Location', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Tradeshow Delivery', 'Tradeshow Delivery', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Keep From Freezing', 'Keep From Freezing (KFF)', GetDate(), 'SYSTEM');
INSERT INTO [QuotingV2_ServiceTypes]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Container Drop', 'Container Drop', GetDate(), 'SYSTEM');
*/

--DROP TABLE [QuotingV2_ServiceTypeFees]
CREATE TABLE [QuotingV2_ServiceTypeFees]
(
	[ServiceTypeChargeID]	[int]	IDENTITY(1,1)	NOT NULL,

	[ServiceTypeID]			[int]	NOT NULL,
	[FeeTypeID]				[int]	NOT NULL,

	-- Constraints
	CONSTRAINT [QuotingV2_ServiceTypeCharges_PK]	PRIMARY KEY([ServiceTypeChargeID]),

	CONSTRAINT [QuotingV2_ServiceTypeCharges_ServiceType_FK] 
		FOREIGN KEY ([ServiceTypeID]) 
		REFERENCES [QuotingV2_ServiceTypes]([ServiceTypeID]),

	CONSTRAINT [QuotingV2_ServiceTypeCharges_FeeType_FK] 
		FOREIGN KEY ([FeeTypeID]) 
		REFERENCES [QuotingV2_FeeTypes]([FeeTypeID]),

	CONSTRAINT [QuotingV2_ServiceTypeCharges_UK]	UNIQUE ([ServiceTypeID], [FeeTypeID])
)
Go