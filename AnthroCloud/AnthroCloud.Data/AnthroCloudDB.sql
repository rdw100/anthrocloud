USE MASTER;  
GO  

--CREATE DATABASE AnthroCloudDB;  
--GO  

IF EXISTS 
   (
     SELECT name FROM master.dbo.sysdatabases 
    WHERE name = N'AnthroCloudDB'
    )
BEGIN
    SELECT 'Database Name already Exist' AS Message
END
ELSE
BEGIN
    CREATE DATABASE AnthroCloudDB
    SELECT 'New Database is Created'
END

IF NOT EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'Rudy')
BEGIN
    USE AnthroCloudDB;
	GO;
	CREATE LOGIN [LoginName] WITH PASSWORD = N'W0RLD0NF1R3'
END



IF NOT EXISTS
    (SELECT name
     FROM sys.database_principals
     WHERE name = 'Rudy')
BEGIN
    CREATE USER [Rudy] FOR LOGIN [Rudy] 
END

/*
USE dbModule11_rdw;  
GO  IF OBJECT_ID('dbo.tblModule11Test_rdw') IS NOT NULL  
DROP TABLE dbo.tblModule11Test_rdw;  
GO  
CREATE TABLE dbo.tblModule11Test_rdw(    
	Id INT IDENTITY(1,1) PRIMARY KEY,    
	Data INT CONSTRAINT DF_tblModule11Test_rdw_Data DEFAULT CHECKSUM(NEWID()) 
); 
*/

USE AnthroCloudDB;
GO
IF OBJECT_ID('dbo.WeightForLength') IS NOT NULL  
DROP TABLE dbo.tblModule11Test_rdw;  
GO  

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'WeightForLength' )


BEGIN
	CREATE TABLE dbo.WeightForLength  
	( 
	  AgeInDays		smallint,	--hardcoded to 1,2
	  Sex			tinyint,
	  LengthInCM	decimal(3,1), 
	  L				decimal(5,4),  
	  M				decimal(6,4),  
	  S				decimal(6,5), 
	  SD3neg		decimal(6,3),
	  SD2neg		decimal(6,3),
	  SD1neg		decimal(6,3),
	  SD0			decimal(6,3),
	  SD1			decimal(6,3),
	  SD2			decimal(6,3),
	  SD3			decimal(6,3),
	  P3			decimal(6,3),	
	  P15			decimal(6,3),	
	  P50			decimal(6,3),	
	  P85			decimal(6,3),	
	  P97			decimal(6,3)
	);  
END 

	GO  
	INSERT INTO dbo.WeightForLength VALUES (0,1,-0.3521,18.2689,0.08755,1.863,1.987,2.064,2.107,2.175,2.223,2.296,2.441,2.599,2.689,2.753,2.851);  
	GO  
	SELECT AgeInDays, Sex, LengthInCM, L, M, S, SD3neg, SD2neg, SD1neg, SD0, SD1, SD2, SD3, P3, P15, P50, P85, P97
	FROM dbo.WeightForLength;   
