CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL  IDENTITY(1,1), 
    [NomeCompleto] NVARCHAR(100) NOT NULL, 
    [Cpf] NVARCHAR(14) NOT NULL, 
    [DataNascimento] DATETIME NOT NULL, 
    [Ativo] BIT NOT NULL, 
    [AdicionadoPor] INT NULL, 
    [Login] NVARCHAR(100) NOT NULL, 
    [Senha] NVARCHAR(20) NOT NULL, 
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Usuarios_Usuarios] FOREIGN KEY ([Id]) REFERENCES [Usuarios]([Id])
)

GO

CREATE INDEX [IX_Usuarios_Id] ON [dbo].[Usuarios] ([Id])

GO

CREATE INDEX [IX_Usuarios_NomeCompleto] ON [dbo].[Usuarios] ([NomeCompleto])

GO

CREATE INDEX [IX_Usuarios_Cpf] ON [dbo].[Usuarios] ([Cpf])

