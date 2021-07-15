

CREATE VIEW [dbo].[vw_Customers]
AS
SELECT ISNULL(a.CustomerID, -100000) as CustomerID, a.Name FROM 
(
SELECT PK_CustNo As CustomerID
     , CustName  As [Name]
FROM [AirTrak].[dbo].[tbl_Customers]
UNION
SELECT -ProspectID As CustomerID
     , [Name]
FROM QuotingV2_Prospects
) a