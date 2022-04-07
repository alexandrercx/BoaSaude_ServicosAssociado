USE [BD_ServicoAssociado]
GO

/****** Object:  Table [dbo].[Associado]    Script Date: 23/02/2022 20:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Associado](
	--[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint]  NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] bigint NOT NULL,
	[DataNascimento] date NOT NULL,
	[NomeMae]  [varchar](100) NOT NULL,
	[CNS] bigint NULL,
	[PisPasep] bigint NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Associado] ADD TitularId [bigint] null

ALTER TABLE [Associado] ADD CONSTRAINT FK_Associado_Titular FOREIGN KEY (TitularId) REFERENCES Associado(Id);


--===========================================
CREATE TABLE [dbo].[Plano](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[ValorBase] decimal(10,2)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO PLANO VALUES('Saúde - Básico', 50.00)
INSERT INTO PLANO VALUES('Saúde - Intermediário', 100.00)

--==========================

CREATE TABLE [dbo].[PlanoFaixaEtaria](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PlanoId] [bigint] not null,
	[IdadeInicial] int not null,
	[IdadeFinal] int not null,
	[ValorAdicional] decimal(10,2)
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [PlanoFaixaEtaria] ADD CONSTRAINT FK_PlanoFaixaEtaria_Plano FOREIGN KEY (PlanoId) REFERENCES Plano(Id);

INSERT INTO [PlanoFaixaEtaria] VALUES(1, 30,39,20.00)
INSERT INTO [PlanoFaixaEtaria] VALUES(1, 40,49,40.00)


--===================================

CREATE TABLE [dbo].[AssociadoPlano](
	--[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[AssociadoId] [bigint] not null,
	[PlanoId] [bigint] not null,
	[PlanoFaixaEtariaId] [bigint] null,
	[ValorContratado] decimal(10,2),
	[DataAtivacao] date not null,
	[DataInativacao] date null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [AssociadoPlano] ADD CONSTRAINT FK_AssociadoPlano_Associado FOREIGN KEY (AssociadoId) REFERENCES Associado(Id);
ALTER TABLE [AssociadoPlano] ADD CONSTRAINT FK_AssociadoPlano_Plano FOREIGN KEY (PlanoId) REFERENCES Plano(Id);
ALTER TABLE [AssociadoPlano] ADD CONSTRAINT FK_AssociadoPlano_PlanoFaixaEtaria FOREIGN KEY ([PlanoFaixaEtariaId]) REFERENCES [PlanoFaixaEtaria](Id);

--=============================

CREATE TABLE [dbo].[Endereco](
	--[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[TipoEndereco] bigint not null,
	[AssociadoId] [bigint] not null,
	[Logradouro] varchar(250) not null,
	[Numero] varchar(50) not null,
	[Bairro] varchar(250) not null,
	[Cidade] varchar(250) not null,
	[CEP] varchar(50) not null,
	[UF] varchar(2) not null,
	[Complemento] varchar(250) null,
	[Pais] varchar(250) not null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Endereco] ADD CONSTRAINT FK_Endereco_Associado FOREIGN KEY (AssociadoId) REFERENCES Associado(Id);


--=============================

CREATE TABLE [dbo].[Telefone](
	--[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[AssociadoId] [bigint] not null,
	[TipoTelefone] int not null,
	[DDI] varchar(3) not null,
	[DDD] varchar(3) not null,
	[Numero] varchar(50) not null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Telefone] ADD CONSTRAINT FK_Telefone_Associado FOREIGN KEY (AssociadoId) REFERENCES Associado(Id);


--=============================

CREATE TABLE [dbo].[ContaBanco](
--	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [bigint] NOT NULL,
	[AssociadoId] [bigint] not null,
	[BancoId] int not null,
	[Agencia] varchar(10) not null,
	[DigitoAgencia] varchar(2) null,
	[Conta] varchar(20) not null,
	[DigitoConta] varchar(2) null,
	[TipoConta] varchar(50) not null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [ContaBanco] ADD CONSTRAINT FK_ContaBanco_Associado FOREIGN KEY (AssociadoId) REFERENCES Associado(Id);


IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.TipoAtendimento') AND type = 'U')
CREATE TABLE [dbo].[TipoAtendimento](
   [Id]		[int]             NOT NULL,
   [Nome]   [varchar]   (72)  NOT NULL
 CONSTRAINT [PK_TipoAtendimento] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[TipoAtendimento] ( 
          Id, Nome)
   SELECT tp.Cod, tp.Nom
      FROM (SELECT 1  'Cod', 'Consulta Presencial' 'Nom' UNION ALL
            SELECT 2  'Cod', 'Telemedicina'        'Nom' UNION ALL
            SELECT 3  'Cod', 'Exame'               'Nom' ) tp
      WHERE NOT EXISTS (SELECT * 
                           FROM [dbo].[TipoAtendimento] ta
                           WHERE ta.Id = tp.Cod)


IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = object_id ('dbo.Conveniado') AND type = 'U')
CREATE TABLE [dbo].[Conveniado](
   [Id]					[bigint]                NOT NULL,
   [Documento]			[bigint]             NOT NULL,
   [Nome]				[varchar]   (255)    NOT NULL,
   [DocProfissional]	[varchar]   (30)     NOT NULL,
   [DataCadastro]       [datetime]           NOT NULL,
   [DataAtualização]    [datetime]               NULL
 CONSTRAINT [PK_Conveniado] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE name = 'DF_Conveniado_DataCadastro' AND parent_object_id = object_id ('dbo.Conveniado') AND type = 'D')
ALTER TABLE [dbo].[Conveniado] ADD  CONSTRAINT [DF_Conveniado_DataCadastro]  DEFAULT (getdate()) FOR [DataCadastro]
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
