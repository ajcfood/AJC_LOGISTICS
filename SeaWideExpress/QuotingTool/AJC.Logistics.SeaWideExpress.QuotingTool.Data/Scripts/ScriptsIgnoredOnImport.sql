

/*
--SELECT * FROM [QuotingV2_UOMs]
DELETE FROM [QuotingV2_UOMs];
DBCC CHECKIDENT ('[QuotingV2_UOMs]', RESEED, 1);
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Weight','Total Weight (LB)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Volume','Total Volume (CuFT)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Volume (45LB)','Total Volume (CuFT w/45LB Rule)',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Units','Unit Count',GetDate(),'SYSTEM');
INSERT INTO [QuotingV2_UOMs]([Name],[Description],[DateAdded],[AddedBy]) VALUES('Units (Oversize)','Oversized Unit Count',GetDate(),'SYSTEM');

DELETE FROM [QuotingV2_FeeTypes];
DBCC CHECKIDENT ('[QuotingV2_FeeTypes]', RESEED, 1);
INSERT INTO [QuotingV2_FeeTypes]([Name],[Description],[ParentFeeTypeID],[DateAdded],[AddedBy])
VALUES('Ocean', 'Ocean Rates', NULL, GETDATE(), 'SYSTEM');
INSERT INTO [QuotingV2_FeeTypes]([Name],[Description],[ParentFeeTypeID],[DateAdded],[AddedBy])
VALUES('Ocean Base', 'Base Rate for Ocean', SCOPE_IDENTITY(), GETDATE(), 'SYSTEM');

DELETE FROM [QuotingV2_Countries];
DBCC CHECKIDENT ('[QuotingV2_Countries]', RESEED, 1);
INSERT INTO [QuotingV2_Countries]([ShortCode],[LongCode],[Name],[DateAdded],[AddedBy])
VALUES('US','USA','United States of America',GETDATE(),'SYSTEM');

DELETE FROM [QuotingV2_States];
DBCC CHECKIDENT ('[QuotingV2_States]', RESEED, 1);
INSERT INTO [QuotingV2_States]([Code],[Name],[CountryID],[DateAdded],[AddedBy])
VALUES('HI','Hawaii',1,GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_States]([Code],[Name],[CountryID],[DateAdded],[AddedBy])
VALUES('AK','Alaska',1,GETDATE(),'SYSTEM');

DELETE FROM [QuotingV2_Islands];
DBCC CHECKIDENT ('[QuotingV2_Islands]', RESEED, 1);
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Hawaii',GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Linai',GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Molokai',GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Oahu',GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Maui',GETDATE(),'SYSTEM');
INSERT INTO [QuotingV2_Islands]([StateID],[Name],[DateAdded],[AddedBy])
VALUES(1,'Kauai',GETDATE(),'SYSTEM');

DELETE FROM [QuotingTool].[dbo].[QuotingV2_Fees];
DBCC CHECKIDENT ('[QuotingV2_Fees]', RESEED, 1);
INSERT INTO [QuotingV2_Fees]([FeeTypeID],[StateID],[IslandID],[Value],[DateAdded],[AddedBy])
VALUES(2, 1, NULL, 6.13, GETDATE(), 'SYSTEM');
INSERT INTO [QuotingV2_Fees]([FeeTypeID],[StateID],[IslandID],[Value],[DateAdded],[AddedBy])
VALUES(2, 1, 2, 2, GETDATE(), 'SYSTEM');
INSERT INTO [QuotingV2_Fees]([FeeTypeID],[StateID],[IslandID],[Value],[DateAdded],[AddedBy])
VALUES(2, 1, 3, 2, GETDATE(), 'SYSTEM');

*/


GO
