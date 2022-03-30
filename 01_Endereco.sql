USE [BD_ServicoAssociado]
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

-- USE [BD_ServicoAssociado]
-- GO

-- INSERT INTO [dbo].[Endereco]
--            ([Seql_Endereco]
--            ,[Nom_Endereco]
--            ,[Nom_Numero]
--            ,[Nom_Bairro]
--            ,[Nom_Cidade]
--            ,[Nom_Uf]
--            ,[Num_CEP]
--            ,[Nom_Complemento])
--      VALUES
--            (1
--            ,'Rua Jacarezinho'
--            ,'1'
--            ,'Águas Claras'
--            ,'Manaus'
--            ,'AM'
--            ,5665010
--            ,'Conjunto 1')
-- GO

-- INSERT INTO [dbo].[Endereco]
--            ([Seql_Endereco]
--            ,[Nom_Endereco]
--            ,[Nom_Numero]
--            ,[Nom_Bairro]
--            ,[Nom_Cidade]
--            ,[Nom_Uf]
--            ,[Num_CEP]
--            ,[Nom_Complemento])
--      VALUES
--            (2
--            ,'Rua Tatuzinho'
--            ,'1'
--            ,'Cidade Nova'
--            ,'Manaus'
--            ,'AM'
--            ,2365010
--            ,'Conjunto 20')
-- GO

-- INSERT INTO [dbo].[Endereco]
--            ([Seql_Endereco]
--            ,[Nom_Endereco]
--            ,[Nom_Numero]
--            ,[Nom_Bairro]
--            ,[Nom_Cidade]
--            ,[Nom_Uf]
--            ,[Num_CEP]
--            ,[Nom_Complemento])
--      VALUES
--            (3
--            ,'Rua Tucunaré'
--            ,'1'
--            ,'Ponta Negra'
--            ,'Manaus'
--            ,'AM'
--            ,3465010
--            ,'Conjunto 3')
-- GO

