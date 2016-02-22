CREATE TABLE [dbo].[GruposMusculares]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nome] NVARCHAR(150) NOT NULL, 
    CONSTRAINT [PK_GruposMusculares] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_GruposMusculares_Id] ON [dbo].[GruposMusculares] ([Id])

GO

CREATE INDEX [IX_GruposMusculares_Nome] ON [dbo].[GruposMusculares] ([Nome])

GO