CREATE TABLE [dbo].[QuotingV2_Prospects] (
    [ProspectID]  INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50)  NOT NULL,
    [DateAdded]   DATETIME      NOT NULL,
    [AddedBy]     VARCHAR (100) NOT NULL,
    [DateUpdated] DATETIME      NULL,
    [UpdatedBy]   VARCHAR (100) NULL,
    CONSTRAINT [QuotingV2_Prospects_PK] PRIMARY KEY CLUSTERED ([ProspectID] ASC)
);

