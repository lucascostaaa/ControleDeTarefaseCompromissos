CREATE TABLE [dbo].[TB_Compromisso] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Assunto]          VARCHAR (200) NULL,
    [Local]            VARCHAR (200) NULL,
    [Data_Compromisso] DATE          NULL,
    [Hora_Inicio]      VARCHAR (200) NULL,
    [Hora_Termino]     VARCHAR (200) NULL,
    [Id_Contato]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Id_Contato]) REFERENCES [dbo].[TB_Contatos] ([Id])
);

