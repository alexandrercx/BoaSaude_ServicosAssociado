USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Agendamento') AND type = 'U')
CREATE TABLE [dbo].[Agendamento](
   [Id]					[bigint]       IDENTITY (1, 1)   NOT NULL,
   [TipoAtendimentoId]  [int]                         NOT NULL,
   [AssociadoId]        [bigint]                         NOT NULL,
   [ConveniadoId]       [bigint]                         NOT NULL,
   [EnderecoId]         [bigint]                         NOT NULL,
   [DataAtendimento]    [datetime]                    NOT NULL,
   [DataAgendamento]    [datetime]                    NOT NULL,
 CONSTRAINT [PK_Agendamento] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Agendamento_DataAgendamento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'D')
ALTER TABLE [dbo].[Agendamento] ADD  CONSTRAINT [DF_Agendamento_DataAgendamento]  DEFAULT (getdate()) FOR [DataAgendamento]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_TipoAtendimento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_TipoAtendimento] FOREIGN KEY([TipoAtendimentoId])
REFERENCES [dbo].[TipoAtendimento] ([Id])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_TipoAtendimento' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_TipoAtendimento]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Associado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Associado] FOREIGN KEY([AssociadoId])
REFERENCES [dbo].[Associado] ([Id])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Associado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Associado]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Conveniado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Conveniado] FOREIGN KEY([ConveniadoId])
REFERENCES [dbo].[Conveniado] ([Id])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Conveniado' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Conveniado]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Endereco' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento]  WITH CHECK ADD  CONSTRAINT [FK_Agendamento_Endereco] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([Id])
GO

IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'FK_Agendamento_Endereco' AND parent_object_id = object_id ('dbo.Agendamento') AND type = 'F')
ALTER TABLE [dbo].[Agendamento] CHECK CONSTRAINT [FK_Agendamento_Endereco]
GO
