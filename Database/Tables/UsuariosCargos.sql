CREATE TABLE [dbo].[UsuariosCargos]
(
	[IdUsuario] INT NOT NULL, 
    [IdCargo] INT NOT NULL, 
    CONSTRAINT [FK_UsuariosCargos_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios]([Id]), 
    CONSTRAINT [FK_UsuariosCargos_Cargos] FOREIGN KEY ([IdCargo]) REFERENCES [Cargos]([Id])
)

GO

CREATE INDEX [IX_UsuariosCargos_IdUsuario] ON [dbo].[UsuariosCargos] ([IdUsuario])

GO

CREATE INDEX [IX_UsuariosCargos_IdCargo] ON [dbo].[UsuariosCargos] ([IdCargo])
