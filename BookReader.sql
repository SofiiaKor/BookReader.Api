/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Author]
      ,[Year]
  FROM [BookReader].[dbo].[Books]
  WHERE Year = '2008'