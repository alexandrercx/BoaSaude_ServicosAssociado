USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Conveniado') AND type = 'U')
CREATE TABLE [dbo].[Conveniado](
   [Id]					[bigint]                NOT NULL,
   [Documento]			[bigint]             NOT NULL,
   [Nome]				[varchar]   (255)    NOT NULL,
   [DocProfissional]	[varchar]   (30)     NOT NULL,
   [DataCadastro]       [datetime]           NOT NULL,
   [DataAtualização]    [datetime]               NULL
 CONSTRAINT [PK_Conveniado] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Conveniado_DataCadastro' AND parent_object_id = object_id ('dbo.Conveniado') AND type = 'D')
ALTER TABLE [dbo].[Conveniado] ADD  CONSTRAINT [DF_Conveniado_DataCadastro]  DEFAULT (getdate()) FOR [DataCadastro]
GO


 USE [BD_ServicoAssociado]
 GO

 INSERT INTO [dbo].[Conveniado]
            ([Id]
            ,[Documento]
            ,[Nome]
            ,[DocProfissional]
            ,[DataCadastro]
            ,[DataAtualização])
      VALUES
            (1
            ,12345678901234
            ,'Clínica Médica'
            ,'12345'
            ,getdate()
            ,getdate())
 GO

 INSERT INTO [dbo].[Conveniado]
            ([Id]
            ,[Documento]
            ,[Nome]
            ,[DocProfissional]
            ,[DataCadastro]
            ,[DataAtualização])
      VALUES
            (2
            ,22345678901234
            ,'Consultório'
            ,'54321'
            ,getdate()
            ,getdate())
 GO

 INSERT INTO [dbo].[Conveniado]
            ([Id]
            ,[Documento]
            ,[Nome]
            ,[DocProfissional]
            ,[DataCadastro]
            ,[DataAtualização])
      VALUES
            (3
            ,12345678901
            ,'Dr. Jose Silva'
            ,'CRM-12345'
            ,getdate()
            ,getdate())
 GO


