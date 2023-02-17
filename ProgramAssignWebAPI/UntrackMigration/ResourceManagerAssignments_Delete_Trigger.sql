USE [ProgramsAutoAssignDB]
GO

/****** Object:  Trigger [dbo].[ResourceManagerAssignments_Delete_Trigger]    Script Date: 18-02-2023 01:40:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[ResourceManagerAssignments_Delete_Trigger]
ON [dbo].[ResourceMangerAssignments]
FOR DELETE
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
      ,[HistoryProgramTrackerId],'Delete' FROM inserted






GO

ALTER TABLE [dbo].[ResourceMangerAssignments] ENABLE TRIGGER [ResourceManagerAssignments_Delete_Trigger]
GO


