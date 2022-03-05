USE [ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Agendamento') AND type = 'U')
CREATE TABLE [dbo].[Agendamento](
   [Seql_Agendamento]      [int]             NOT NULL,
   [Cod_TipoAtendimento]   [int]             NOT NULL,
   [Seql_Associado]        [int]             NOT NULL,
   [Seql_Conveniado]       [int]             NOT NULL,
   [Seql_Endereco]         [int]             NOT NULL,
   [Inst_Atendimento]      [datetime]        NOT NULL,
   [Inst_Agendamento]      [datetime]        NOT NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
   [Seql_Agendamento] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO