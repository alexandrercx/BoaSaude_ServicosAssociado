USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Agendamento') AND type = 'U')
CREATE TABLE [dbo].[Agendamento](
   [Seql_Agendamento]      [int]       IDENTITY (1, 1)   NOT NULL,
   [Cod_TipoAtendimento]   [int]                         NOT NULL,
   [Seql_Associado]        [int]                         NOT NULL,
   [Seql_Conveniado]       [int]                         NOT NULL,
   [Seql_Endereco]         [int]                         NOT NULL,
   [Inst_Atendimento]      [datetime]                    NOT NULL,
   [Inst_Agendamento]      [datetime]                    NOT NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
   [Seql_Agendamento] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Agendamento_Inst_Agendamento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'D')
ALTER TABLE [dbo].[Agendamento] ADD  CONSTRAINT [DF_Agendamento_Inst_Agendamento]  DEFAULT (getdate()) FOR [Inst_Agendamento]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_TipoAtendimento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_TipoAtendimento] FOREIGN KEY([Cod_TipoAtendimento])
REFERENCES [dbo].[TipoAtendimento] ([Cod_TipoAtendimento])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_TipoAtendimento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_TipoAtendimento]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Associado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Associado] FOREIGN KEY([Seql_Associado])
REFERENCES [dbo].[Associado] ([Seql_Associado])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Associado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Associado]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Conveniado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Conveniado] FOREIGN KEY([Seql_Conveniado])
REFERENCES [dbo].[Conveniado] ([Seql_Conveniado])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Conveniado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Conveniado]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Endereco' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Endereco] FOREIGN KEY([Seql_Endereco])
REFERENCES [dbo].[Endereco] ([Seql_Endereco])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Endereco' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Endereco]
GO
