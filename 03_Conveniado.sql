USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Conveniado') AND type = 'U')
CREATE TABLE [dbo].[Conveniado](
   [Seql_Conveniado]       [int]                NOT NULL,
   [Num_Documento]         [bigint]             NOT NULL,
   [Nom_Conveniado]        [varchar]   (255)    NOT NULL,
   [Num_DocProfissional]   [varchar]   (30)     NOT NULL,
   [Inst_Cadastro]         [datetime]           NOT NULL,
   [Inst_Atualização]      [datetime]               NULL
 CONSTRAINT [PK_Conveniado] PRIMARY KEY CLUSTERED 
(
   [Seql_Conveniado] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Conveniado_Inst_Cadastro' AND parent_object_id = object_id ('dbo.Conveniado') AND type = 'D')
ALTER TABLE [dbo].[Conveniado] ADD  CONSTRAINT [DF_Conveniado_Inst_Cadastro]  DEFAULT (getdate()) FOR [Inst_Cadastro]
GO


-- USE [BD_ServicoAssociado]
-- GO

-- INSERT INTO [dbo].[Conveniado]
--            ([Seql_Conveniado]
--            ,[Num_Documento]
--            ,[Nom_Conveniado]
--            ,[Num_DocProfissional]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (1
--            ,12345678901234
--            ,'Clínica Médica'
--            ,'12345'
--            ,getdate()
--            ,getdate())
-- GO

-- INSERT INTO [dbo].[Conveniado]
--            ([Seql_Conveniado]
--            ,[Num_Documento]
--            ,[Nom_Conveniado]
--            ,[Num_DocProfissional]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (2
--            ,22345678901234
--            ,'Consultório'
--            ,'54321'
--            ,getdate()
--            ,getdate())
-- GO

-- INSERT INTO [dbo].[Conveniado]
--            ([Seql_Conveniado]
--            ,[Num_Documento]
--            ,[Nom_Conveniado]
--            ,[Num_DocProfissional]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (3
--            ,12345678901
--            ,'Dr. Jose Silva'
--            ,'CRM-12345'
--            ,getdate()
--            ,getdate())
-- GO


