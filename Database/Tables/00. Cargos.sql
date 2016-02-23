CREATE TABLE [dbo].[Cargos]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nome] NVARCHAR(50) NOT NULL, 
    [Ativo] BIT NOT NULL, 
    CONSTRAINT [PK_Cargos] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_Cargos_Id] ON [dbo].[Cargos] ([Id])
