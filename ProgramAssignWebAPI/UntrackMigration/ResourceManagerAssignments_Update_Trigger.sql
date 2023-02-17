USE [ProgramsAutoAssignDB]
GO

/****** Object:  Trigger [dbo].[ResourceManagerAssignments_Update_Trigger]    Script Date: 18-02-2023 02:14:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[ResourceManagerAssignments_Update_Trigger]
ON [dbo].[ResourceMangerAssignments]
FOR UPDATE
AS
INSERT INTO ResourceManagerAssignmentsHistory ([Id]
      ,[VAMID]
      ,[TechTrack]
      ,[Email]
      ,[ResourceName]
      ,[StartDate]
      ,[EndDate]
      ,[Manager]
      ,[SME]
      ,[SMEStatus]
      ,[ProgramStatus]
      ,[ProgramsTrackerId]
      ,[HistoryProgramTrackerId],
	  [ActionType]) 
	  SELECT [Id]
      ,[VAMID]
      ,[TechTrack],[Email]
      ,[ResourceName]
      ,[StartDate]
      ,[EndDate]
      ,[Manager]
      ,[SME]
      ,[SMEStatus]
      ,[ProgramStatus]
      ,[ProgramsTrackerId]
      ,[HistoryProgramTrackerId],'Update' FROM inserted






GO

ALTER TABLE [dbo].[ResourceMangerAssignments] ENABLE TRIGGER [ResourceManagerAssignments_Update_Trigger]
GO


