USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Associado') AND type = 'U')
CREATE TABLE [dbo].[Associado](
	[Id]				[bigint]  NOT NULL,
	[Nome]				[varchar](100) NOT NULL,
	[CPF]				[bigint] NOT NULL,
	[DataNascimento]	[date] NOT NULL,
	[NomeMae]			[varchar](100) NOT NULL,
	[CNS]				[bigint] NULL,
	[PisPasep]			[bigint] NULL,
	[Email]				[varchar](100) NOT NULL,
	[Senha]				[varchar](100) NOT NULL,
 CONSTRAINT [PK_Associado] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.columns WHERE name = 'TitularId' AND object_id = object_id ('dbo.Associado'))
ALTER TABLE [Associado] ADD TitularId [bigint] null
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Associado_Titular' AND parent_object_id = object_id ('dbo.Associado') AND type = 'F')
ALTER TABLE [Associado] ADD CONSTRAINT FK_Associado_Titular FOREIGN KEY (TitularId) REFERENCES Associado(Id);
GO
