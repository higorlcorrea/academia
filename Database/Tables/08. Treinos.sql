CREATE TABLE [dbo].[Treinos]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [IdUsuarioAluno] INT NOT NULL, 
    [IdUsuarioCriacao] INT NOT NULL, 
    [IdCategoriaTreino] INT NULL, 
    [Descricao] NVARCHAR(50) NOT NULL, 
    [DiaSemana] INT NULL, 
    CONSTRAINT [PK_Treinos] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Treinos_UsuariosAluno] FOREIGN KEY ([IdUsuarioAluno]) REFERENCES [Usuarios]([Id]), 
    CONSTRAINT [FK_Treinos_UsuariosCriacao] FOREIGN KEY ([IdUsuarioCriacao]) REFERENCES [Usuarios]([Id]), 
    CONSTRAINT [FK_Treinos_CategoriasTreino] FOREIGN KEY ([IdCategoriaTreino]) REFERENCES [CategoriasTreino]([Id])
)

GO

CREATE INDEX [IX_Treinos_Id] ON [dbo].[Treinos] ([Id])

GO

CREATE INDEX [IX_Treinos_IdUsuarioAluno] ON [dbo].[Treinos] ([IdUsuarioAluno])
