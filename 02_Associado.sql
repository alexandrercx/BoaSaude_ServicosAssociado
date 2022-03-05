USE [ServicoAssociado]
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