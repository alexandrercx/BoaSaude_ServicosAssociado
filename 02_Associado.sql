USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Associado') AND type = 'U')
CREATE TABLE [dbo].[Associado](
   [Seql_Associado]     [int]                NOT NULL,
   [Num_Documento]      [bigint]             NOT NULL,
   [Nom_Associado]      [varchar]   (255)    NOT NULL,
   [Ind_Ativo]          [varchar]   (1)      NOT NULL,
   [Inst_Cadastro]      [datetime]           NOT NULL,
   [Inst_Atualização]   [datetime]               NULL
 CONSTRAINT [PK_Associado] PRIMARY KEY CLUSTERED 
(
   [Seql_Associado] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Associado_Inst_Cadastro' AND parent_object_id = object_id ('dbo.Associado') AND type = 'D')
ALTER TABLE [dbo].[Associado] ADD  CONSTRAINT [DF_Associado_Inst_Cadastro]  DEFAULT (getdate()) FOR [Inst_Cadastro]
GO


-- USE [BD_ServicoAssociado]
-- GO

-- INSERT INTO [dbo].[Associado]
--            ([Seql_Associado]
--            ,[Num_Documento]
--            ,[Nom_Associado]
--            ,[Ind_Ativo]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (1
--            ,12345678909
--            ,'Enzo Ferreira'
--            ,'S'
--            ,getdate()
--            ,getdate())
-- GO

-- INSERT INTO [dbo].[Associado]
--            ([Seql_Associado]
--            ,[Num_Documento]
--            ,[Nom_Associado]
--            ,[Ind_Ativo]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (2
--            ,09876543211
--            ,'Igor Ferreira'
--            ,'S'
--            ,getdate()
--            ,getdate())
-- GO

-- INSERT INTO [dbo].[Associado]
--            ([Seql_Associado]
--            ,[Num_Documento]
--            ,[Nom_Associado]
--            ,[Ind_Ativo]
--            ,[Inst_Cadastro]
--            ,[Inst_Atualização])
--      VALUES
--            (3
--            ,76859403212
--            ,'Jhon Ferreira'
--            ,'N'
--            ,getdate()
--            ,getdate())
-- GO
