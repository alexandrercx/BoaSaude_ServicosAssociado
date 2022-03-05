USE [ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Endereco') AND type = 'U')
CREATE TABLE [dbo].[Endereco](
   [Seql_Endereco]      [int]             NOT NULL,
   [Nom_Endereco]       [varchar]   (72)  NOT NULL,
   [Nom_Numero]         [varchar]   (20)  NOT NULL,
   [Nom_Bairro]         [varchar]   (72)  NOT NULL,
   [Nom_Cidade]         [varchar]   (72)  NOT NULL,
   [Nom_Uf]             [char]      (02)  NOT NULL,
   [Num_CEP]            [int]             NOT NULL,
   [Nom_Complemento]    [varchar]   (20)      NULL
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
   [Seql_Endereco] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO