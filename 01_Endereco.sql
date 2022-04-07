USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Endereco') AND type = 'U')
CREATE TABLE [dbo].[Endereco](
	[Id]			[bigint] NOT NULL,
	[TipoEndereco]	[bigint] not null,
	[AssociadoId]	[bigint] not null,
	[Logradouro]	[varchar](250) not null,
	[Numero]		[varchar](50) not null,
	[Bairro]		[varchar](250) not null,
	[Cidade]		[varchar](250) not null,
	[CEP]			[varchar](50) not null,
	[UF]			[varchar](2) not null,
	[Complemento]	[varchar](250) null,
	[Pais]			[varchar](250) not null
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Endereco_Associado' AND parent_object_id = object_id ('dbo.Endereco') AND type = 'F')
ALTER TABLE [Endereco] ADD CONSTRAINT FK_Endereco_Associado FOREIGN KEY (AssociadoId) REFERENCES Associado(Id);
GO

