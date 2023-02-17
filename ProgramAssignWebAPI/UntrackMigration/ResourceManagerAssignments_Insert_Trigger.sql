USE [ProgramsAutoAssignDB]
GO

/****** Object:  Trigger [dbo].[ResourceManagerAssignments_Insert_Trigger]    Script Date: 18-02-2023 02:10:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[ResourceManagerAssignments_Insert_Trigger]
ON [dbo].[ResourceMangerAssignments]
FOR INSERT
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
	  [ActionType]
	 ) 
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
      ,[HistoryProgramTrackerId],'Insert' FROM inserted






GO

ALTER TABLE [dbo].[ResourceMangerAssignments] ENABLE TRIGGER [ResourceManagerAssignments_Insert_Trigger]
GO


