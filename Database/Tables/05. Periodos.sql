CREATE TABLE [dbo].[Periodos]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Descricao] NVARCHAR(30) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    CONSTRAINT [PK_Periodos] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_Periodos_Id] ON [dbo].[Periodos] ([Id])
