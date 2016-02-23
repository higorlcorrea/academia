CREATE TABLE [dbo].[Maquinas]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nome] NVARCHAR(30) NOT NULL, 
    [Imagem] NVARCHAR(200) NULL, 
    [Ativo] BIT NOT NULL, 
    CONSTRAINT [PK_Maquinas] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_Maquinas_Id] ON [dbo].[Maquinas] ([Id]);

GO

CREATE INDEX [IX_Maquinas_Nome] ON [dbo].[Maquinas] ([Nome]);
