CREATE TABLE [dbo].[Exercicios]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [IdMaquina] INT NULL, 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Descricao] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Exercicios] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Exercicios_Maquinas] FOREIGN KEY ([IdMaquina]) REFERENCES [Maquinas]([Id])
)

GO

CREATE INDEX [IX_Exercicios_Id] ON [dbo].[Exercicios] ([Id])

GO

CREATE INDEX [IX_Exercicios_IdMaquina] ON [dbo].[Exercicios] ([IdMaquina])
