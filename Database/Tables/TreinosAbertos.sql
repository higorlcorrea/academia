CREATE TABLE [dbo].[TreinosAbertos]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [IdTreino] INT NOT NULL, 
    [DataAbertura] DATETIME NOT NULL DEFAULT GETDATE(), 
    CONSTRAINT [FK_TreinosAbertos_Treinos] FOREIGN KEY ([IdTreino]) REFERENCES [Treinos]([Id]), 
    CONSTRAINT [PK_TreinosAbertos] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_TreinosAbertos_DataAbertura] ON [dbo].[TreinosAbertos] ([DataAbertura])
