CREATE TABLE [QuotingV2_Quote]
(
	[QuoteID]		[int] IDENTITY(1,1)	NOT NULL,

	[QuoteNo]		[varchar](100)	NULL,
	[CustomerID]	[int]			NOT NULL,
	[Gateway]		[varchar](100)	NULL,

	[OrigState]		[varchar](2)	NULL,
	[OrigCity]		[varchar](100)	NULL,
	[OrigZipCode]	[varchar](5)	NULL,

	[DestState]		[varchar](2)	NULL,
	[DestCity]		[varchar](100)	NULL,
	[DestZipCode]	[varchar](5)	NULL,

	[ShipDate]		[datetime]		NULL,

	-- Audit Fields
	[DateAdded]		[datetime]		NOT NULL,
	[AddedBy]		[varchar](100)	NOT NULL,
	[DateUpdated]	[datetime]		NULL,
	[UpdatedBy]		[varchar](100)	NULL,

	-- Constraints
	CONSTRAINT [QuotingV2_Quote_PK]	PRIMARY KEY([QuoteID])
)
Go

CREATE TABLE [QuotingV2_QuoteServices]
	[QuoteServiceID]	[int]	IDENTITY(1,1)	NOT NULL,

	[QuoteID]			[int]	NOT NULL,
	[ServiceTypeID]		[int]	NOT NULL

	-- Constraints
	CONSTRAINT [QuotingV2_QuoteServices_PK]	PRIMARY KEY([QuoteServiceID]),

	CONSTRAINT [QuotingV2_QuoteServices_UK]	UNIQUE ([QuoteID], [ServiceTypeID]),

	CONSTRAINT [QuotingV2_QuoteServices_Quote_FK] 
		FOREIGN KEY ([QuoteID]) 
		REFERENCES [QuotingV2_Quote]([QuoteID]),

	CONSTRAINT [QuotingV2_QuoteServices_ServiceType_FK] 
		FOREIGN KEY ([ServiceTypeID]) 
		REFERENCES [QuotingV2_ServiceTypes]([ServiceTypeID])
)
Go

CREATE TABLE [QuotingV2_QuoteItems]
(
	QuoteItemID		[int] IDENTITY(1,1)	NOT NULL,

	[QuoteID]		[int] NOT NULL,

	[Units]			[decimal](6, 2)		NULL,
	[PKGType]		[varchar](25)		NULL,
	[Weight]		[decimal](6, 2)		NULL,

	[Length]		[decimal](6, 2)		NULL,
	[Width]			[decimal](6, 2)		NULL,
	[Height]		[decimal](6, 2)		NULL,

	[Class]			[varchar](7)		NULL,
	[Commodity]		[varchar](200)		NULL,

	-- What are these???
	/*
	[NMFCNo]		[varchar](10) NULL,
	[Terms]			[varchar](10) NULL,
	[Value]			[varchar](100) NULL,
	*/
)
Go

select * from Quoting_SWEDetails where value <> ''

CREATE TABLE [QuotingV2_QuoteCharges]
	[QuoteID]
	[FeeSubTypeID]
	[Fee]
	[Discount]
	[FeeMin]
	[FeeMax]
	[Charge]
)
Go

USE [AirTrak]
GO

/****** Object:  Table [dbo].[Quoting_SWESummary]    Script Date: 6/7/2021 2:21:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Quoting_SWESummary](
	[SummaryID] [int] IDENTITY(1,1) NOT NULL,
	[CustID] [int] NULL,
	[Gateway] [varchar](100) NULL,
	[TotPieces]  AS ([dbo].[GETTotalPieces]([SummaryID])),
	[TotWeight]  AS ([dbo].[GETTotalWeight]([SummaryID])),
	[TotCubicFeet] [int] NULL,
	[TotInlandFee] [decimal](7, 2) NULL,
	[OceanFee] [decimal](7, 2) NULL,
	[OceanDiscPerc] [decimal](7, 2) NULL,
	[OceanFSCPerc] [decimal](7, 2) NULL,
	[OceanFSCFee] [decimal](7, 2) NULL,
	[TotOceanFee] [decimal](7, 2) NULL,
	[DestDelivFee] [decimal](7, 2) NULL,
	[DestDelivFSCFee] [decimal](7, 2) NULL,
	[HZMTDestDelivFee] [decimal](7, 2) NULL,
	[TotInvasiveSpeciesFee] [decimal](7, 2) NULL,
	[TotWharfageFee] [decimal](7, 2) NULL,
	[HazmatOceanFee] [decimal](7, 2) NULL,
	[HazmatDeliveryFee] [decimal](7, 2) NULL,
	[WillCallFee] [decimal](7, 2) NULL,
	[LiftGateFee] [decimal](7, 2) NULL,
	[InsideDeliveryFee] [decimal](7, 2) NULL,
	[ResidentialDeliveryFee] [decimal](7, 2) NULL,
	[LimitedAccessFee] [decimal](7, 2) NULL,
	[AppointmentFee] [decimal](7, 2) NULL,
	[CollectOnDeliveryFee] [decimal](7, 2) NULL,
	[ExcessiveLengthFee] [decimal](7, 2) NULL,
	[TradeshowDeliveryFee] [decimal](7, 2) NULL,
	[NotificationFee] [decimal](7, 2) NULL,
	[ProtectFromFreezingFee] [decimal](7, 2) NULL,
	[MilitaryDeliveryFee] [decimal](7, 2) NULL,
	[MineSiteDeliveryFee] [decimal](7, 2) NULL,
	[OilFieldLocationFee] [decimal](7, 2) NULL,
	[InterIslandTransFee] [decimal](7, 2) NULL,
	[TotAccessorialFee] [decimal](7, 2) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Quoting_SWEDetails](
	[QuoteID] [int] IDENTITY(1,1) NOT NULL,
	[CustID] [int] NULL,
	[QuoteNo] [varchar](100) NULL,
	[OrigCity] [varchar](100) NULL,
	[OrigState] [varchar](2) NULL,
	[OrigZipCode] [varchar](5) NULL,
	[DestCity] [varchar](100) NULL,
	[DestState] [varchar](2) NULL,
	[DestZipCode] [varchar](5) NULL,
	[ShipDate] [datetime] NULL,
	[PKGType] [varchar](25) NULL,
	[WeightPerPKGType] [decimal](6, 2) NULL,
	[Length] [decimal](6, 2) NULL,
	[Width] [decimal](6, 2) NULL,
	[Height] [decimal](6, 2) NULL,
	[CubicFeet] [decimal](6, 2) NULL,
	[Units] [decimal](6, 2) NULL,
	[Class] [varchar](7) NULL,
	[Commodity] [varchar](200) NULL,
	[NMFCNo] [varchar](10) NULL,
	[Terms] [varchar](10) NULL,
	[Value] [varchar](100) NULL,
	[WillCall] [varchar](1) NULL,
	[IsHazmat] [varchar](1) NULL,
	[LiftGate] [varchar](1) NULL,
	[InsideDelivery] [varchar](1) NULL,
	[ResidentialDelivery] [varchar](1) NULL,
	[LimitedAccess] [varchar](1) NULL,
	[Appointment] [varchar](1) NULL,
	[CollectOnDelivery] [varchar](1) NULL,
	[CODAmountToCollect] [decimal](7, 2) NULL,
	[ExcessiveLength] [varchar](1) NULL,
	[TradeshowDelivery] [varchar](1) NULL,
	[Notification] [varchar](1) NULL,
	[ProtectFromFreezing] [varchar](1) NULL,
	[MilitaryDelivery] [varchar](1) NULL,
	[MineSiteDelivery] [varchar](1) NULL,
	[OilFieldLocation] [varchar](1) NULL,
	[DateQuoted] [datetime] NULL,
	[DateQuoteAccepted] [datetime] NULL,
	[UserID] [varchar](10) NULL,
	[ContainerDrop] [varchar](1) NULL
) ON [PRIMARY]
GO
