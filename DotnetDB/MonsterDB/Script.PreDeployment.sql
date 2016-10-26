/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use master;
go


if(DB_ID(N'MonsterDB') is not null) /*The 'N' means treat as an Nvarchar*/
begin
	drop database MonsterDB;
end;

create database MonsterDB;
go

use MonsterDB;
go

if(SCHEMA_ID(N'Monster') is not null)
begin 
	drop schema Monster;
end;
