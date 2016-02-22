CREATE TABLE [dbo].[CategoriasTreino]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Descricao] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_CategoriasTreino] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_CategoriasTreino_Id] ON [dbo].[CategoriasTreino] ([Id])
