USE [BD_ServicoAssociado]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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