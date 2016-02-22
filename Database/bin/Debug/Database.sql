﻿/*
Deployment script for Database_1

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Database_1"
:setvar DefaultFilePrefix "Database_1"
:setvar DefaultDataPath "C:\Users\Higor Correa\AppData\Local\Microsoft\VisualStudio\SSDT\CorpoEmAcao\"
:setvar DefaultLogPath "C:\Users\Higor Correa\AppData\Local\Microsoft\VisualStudio\SSDT\CorpoEmAcao\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key 21e9d3c0-52ee-4c80-bedd-552f71ae793e is skipped, element [dbo].[Maquinas].[Descricao] (SqlSimpleColumn) will not be renamed to Imagem';


GO
PRINT N'Rename refactoring operation with key b6bce3cd-76c4-4328-a136-7f3fbcc913b5 is skipped, element [dbo].[Treinadores].[Telefone] (SqlSimpleColumn) will not be renamed to Celular';


GO
PRINT N'Rename refactoring operation with key 87b7b64c-1822-4210-a450-4cf6bfc892fb is skipped, element [dbo].[Periodos].[bit] (SqlSimpleColumn) will not be renamed to Ativo';


GO
PRINT N'Rename refactoring operation with key fa402940-21f0-4c74-8633-754cfdbf46df is skipped, element [dbo].[TreinadoresPeriodos].[Id] (SqlSimpleColumn) will not be renamed to IdTreinador';


GO
PRINT N'Rename refactoring operation with key 1695083e-e457-4bbc-aa42-2ee2345ada34 is skipped, element [dbo].[UsuariosCargos].[Id] (SqlSimpleColumn) will not be renamed to IdUsuario';


GO
PRINT N'Rename refactoring operation with key 3044382b-4b6f-4fb8-872d-22a23e65ff51 is skipped, element [dbo].[TreinosAbertosExerciciosRealizados].[Id] (SqlSimpleColumn) will not be renamed to IdTreinoAberto';


GO
PRINT N'Rename refactoring operation with key ce1838e7-8b78-4431-803b-69cfb3700f29 is skipped, element [dbo].[TreinosExercicios].[Id] (SqlSimpleColumn) will not be renamed to IdTreino';


GO
PRINT N'Creating [dbo].[Cargos]...';


GO
CREATE TABLE [dbo].[Cargos] (
    [Id]    INT           NOT NULL,
    [Nome]  NVARCHAR (50) NOT NULL,
    [Ativo] BIT           NOT NULL,
    CONSTRAINT [PK_Cargos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Cargos].[IX_Cargos_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Cargos_Id]
    ON [dbo].[Cargos]([Id] ASC);


GO
PRINT N'Creating [dbo].[CategoriasTreino]...';


GO
CREATE TABLE [dbo].[CategoriasTreino] (
    [Id]        INT           NOT NULL,
    [Descricao] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CategoriasTreino] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[CategoriasTreino].[IX_CategoriasTreino_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_CategoriasTreino_Id]
    ON [dbo].[CategoriasTreino]([Id] ASC);


GO
PRINT N'Creating [dbo].[Exercicios]...';


GO
CREATE TABLE [dbo].[Exercicios] (
    [Id]        INT            NOT NULL,
    [IdMaquina] INT            NULL,
    [Nome]      NVARCHAR (50)  NOT NULL,
    [Descricao] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Exercicios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Exercicios].[IX_Exercicios_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Exercicios_Id]
    ON [dbo].[Exercicios]([Id] ASC);


GO
PRINT N'Creating [dbo].[Exercicios].[IX_Exercicios_IdMaquina]...';


GO
CREATE NONCLUSTERED INDEX [IX_Exercicios_IdMaquina]
    ON [dbo].[Exercicios]([IdMaquina] ASC);


GO
PRINT N'Creating [dbo].[GruposMusculares]...';


GO
CREATE TABLE [dbo].[GruposMusculares] (
    [Id]   INT            NOT NULL,
    [Nome] NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_GruposMusculares] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[GruposMusculares].[IX_GruposMusculares_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_GruposMusculares_Id]
    ON [dbo].[GruposMusculares]([Id] ASC);


GO
PRINT N'Creating [dbo].[GruposMusculares].[IX_GruposMusculares_Nome]...';


GO
CREATE NONCLUSTERED INDEX [IX_GruposMusculares_Nome]
    ON [dbo].[GruposMusculares]([Nome] ASC);


GO
PRINT N'Creating [dbo].[Maquinas]...';


GO
CREATE TABLE [dbo].[Maquinas] (
    [Id]     INT            NOT NULL,
    [Nome]   NVARCHAR (30)  NOT NULL,
    [Imagem] NVARCHAR (200) NULL,
    [Ativo]  BIT            NOT NULL,
    CONSTRAINT [PK_Maquinas] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Maquinas].[IX_Maquinas_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Maquinas_Id]
    ON [dbo].[Maquinas]([Id] ASC);


GO
PRINT N'Creating [dbo].[Maquinas].[IX_Maquinas_Nome]...';


GO
CREATE NONCLUSTERED INDEX [IX_Maquinas_Nome]
    ON [dbo].[Maquinas]([Nome] ASC);


GO
PRINT N'Creating [dbo].[Periodos]...';


GO
CREATE TABLE [dbo].[Periodos] (
    [Id]        INT           NOT NULL,
    [Descricao] NVARCHAR (30) NOT NULL,
    [Ativo]     BIT           NOT NULL,
    CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Periodos].[IX_Periodos_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Periodos_Id]
    ON [dbo].[Periodos]([Id] ASC);


GO
PRINT N'Creating [dbo].[Treinos]...';


GO
CREATE TABLE [dbo].[Treinos] (
    [Id]                INT           NOT NULL,
    [IdUsuarioAluno]    INT           NOT NULL,
    [IdUsuarioCriacao]  INT           NOT NULL,
    [IdCategoriaTreino] INT           NULL,
    [Descricao]         NVARCHAR (50) NOT NULL,
    [DiaSemana]         INT           NULL,
    CONSTRAINT [PK_Treinos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Treinos].[IX_Treinos_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Treinos_Id]
    ON [dbo].[Treinos]([Id] ASC);


GO
PRINT N'Creating [dbo].[Treinos].[IX_Treinos_IdUsuarioAluno]...';


GO
CREATE NONCLUSTERED INDEX [IX_Treinos_IdUsuarioAluno]
    ON [dbo].[Treinos]([IdUsuarioAluno] ASC);


GO
PRINT N'Creating [dbo].[TreinosAbertos]...';


GO
CREATE TABLE [dbo].[TreinosAbertos] (
    [Id]           INT      NOT NULL,
    [IdTreino]     INT      NOT NULL,
    [DataAbertura] DATETIME NOT NULL,
    CONSTRAINT [PK_TreinosAbertos] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[TreinosAbertos].[IX_TreinosAbertos_DataAbertura]...';


GO
CREATE NONCLUSTERED INDEX [IX_TreinosAbertos_DataAbertura]
    ON [dbo].[TreinosAbertos]([DataAbertura] ASC);


GO
PRINT N'Creating [dbo].[TreinosAbertosExerciciosRealizados]...';


GO
CREATE TABLE [dbo].[TreinosAbertosExerciciosRealizados] (
    [IdTreinoAberto] INT NOT NULL,
    [IdExercicio]    INT NOT NULL
);


GO
PRINT N'Creating [dbo].[TreinosExercicios]...';


GO
CREATE TABLE [dbo].[TreinosExercicios] (
    [IdTreino]    INT NOT NULL,
    [IdExercicio] INT NOT NULL
);


GO
PRINT N'Creating [dbo].[TreinosExercicios].[IX_TreinosExercicios_IdTreino]...';


GO
CREATE NONCLUSTERED INDEX [IX_TreinosExercicios_IdTreino]
    ON [dbo].[TreinosExercicios]([IdTreino] ASC);


GO
PRINT N'Creating [dbo].[TreinosExercicios].[IX_TreinosExercicios_IdExercicio]...';


GO
CREATE NONCLUSTERED INDEX [IX_TreinosExercicios_IdExercicio]
    ON [dbo].[TreinosExercicios]([IdExercicio] ASC);


GO
PRINT N'Creating [dbo].[Usuarios]...';


GO
CREATE TABLE [dbo].[Usuarios] (
    [Id]             INT            NOT NULL,
    [NomeCompleto]   NVARCHAR (100) NOT NULL,
    [Cpf]            NVARCHAR (14)  NOT NULL,
    [DataNascimento] DATETIME       NOT NULL,
    [Ativo]          BIT            NOT NULL,
    [AdicionadoPor]  INT            NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Usuarios].[IX_Usuarios_Id]...';


GO
CREATE NONCLUSTERED INDEX [IX_Usuarios_Id]
    ON [dbo].[Usuarios]([Id] ASC);


GO
PRINT N'Creating [dbo].[Usuarios].[IX_Usuarios_NomeCompleto]...';


GO
CREATE NONCLUSTERED INDEX [IX_Usuarios_NomeCompleto]
    ON [dbo].[Usuarios]([NomeCompleto] ASC);


GO
PRINT N'Creating [dbo].[Usuarios].[IX_Usuarios_Cpf]...';


GO
CREATE NONCLUSTERED INDEX [IX_Usuarios_Cpf]
    ON [dbo].[Usuarios]([Cpf] ASC);


GO
PRINT N'Creating [dbo].[UsuariosCargos]...';


GO
CREATE TABLE [dbo].[UsuariosCargos] (
    [IdUsuario] INT NOT NULL,
    [IdCargo]   INT NOT NULL
);


GO
PRINT N'Creating [dbo].[UsuariosCargos].[IX_UsuariosCargos_IdUsuario]...';


GO
CREATE NONCLUSTERED INDEX [IX_UsuariosCargos_IdUsuario]
    ON [dbo].[UsuariosCargos]([IdUsuario] ASC);


GO
PRINT N'Creating [dbo].[UsuariosCargos].[IX_UsuariosCargos_IdCargo]...';


GO
CREATE NONCLUSTERED INDEX [IX_UsuariosCargos_IdCargo]
    ON [dbo].[UsuariosCargos]([IdCargo] ASC);


GO
PRINT N'Creating Default Constraint on [dbo].[TreinosAbertos]....';


GO
ALTER TABLE [dbo].[TreinosAbertos]
    ADD DEFAULT GETDATE() FOR [DataAbertura];


GO
PRINT N'Creating FK_Exercicios_Maquinas...';


GO
ALTER TABLE [dbo].[Exercicios] WITH NOCHECK
    ADD CONSTRAINT [FK_Exercicios_Maquinas] FOREIGN KEY ([IdMaquina]) REFERENCES [dbo].[Maquinas] ([Id]);


GO
PRINT N'Creating FK_Treinos_UsuariosAluno...';


GO
ALTER TABLE [dbo].[Treinos] WITH NOCHECK
    ADD CONSTRAINT [FK_Treinos_UsuariosAluno] FOREIGN KEY ([IdUsuarioAluno]) REFERENCES [dbo].[Usuarios] ([Id]);


GO
PRINT N'Creating FK_Treinos_UsuariosCriacao...';


GO
ALTER TABLE [dbo].[Treinos] WITH NOCHECK
    ADD CONSTRAINT [FK_Treinos_UsuariosCriacao] FOREIGN KEY ([IdUsuarioCriacao]) REFERENCES [dbo].[Usuarios] ([Id]);


GO
PRINT N'Creating FK_Treinos_CategoriasTreino...';


GO
ALTER TABLE [dbo].[Treinos] WITH NOCHECK
    ADD CONSTRAINT [FK_Treinos_CategoriasTreino] FOREIGN KEY ([IdCategoriaTreino]) REFERENCES [dbo].[CategoriasTreino] ([Id]);


GO
PRINT N'Creating FK_TreinosAbertos_Treinos...';


GO
ALTER TABLE [dbo].[TreinosAbertos] WITH NOCHECK
    ADD CONSTRAINT [FK_TreinosAbertos_Treinos] FOREIGN KEY ([IdTreino]) REFERENCES [dbo].[Treinos] ([Id]);


GO
PRINT N'Creating FK_TreinosAbertosExerciciosRealizados_TreinosAbertos...';


GO
ALTER TABLE [dbo].[TreinosAbertosExerciciosRealizados] WITH NOCHECK
    ADD CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_TreinosAbertos] FOREIGN KEY ([IdTreinoAberto]) REFERENCES [dbo].[TreinosAbertos] ([Id]);


GO
PRINT N'Creating FK_TreinosAbertosExerciciosRealizados_Exercicios...';


GO
ALTER TABLE [dbo].[TreinosAbertosExerciciosRealizados] WITH NOCHECK
    ADD CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_Exercicios] FOREIGN KEY ([IdExercicio]) REFERENCES [dbo].[Exercicios] ([Id]);


GO
PRINT N'Creating FK_TreinosExercicios_Treinos...';


GO
ALTER TABLE [dbo].[TreinosExercicios] WITH NOCHECK
    ADD CONSTRAINT [FK_TreinosExercicios_Treinos] FOREIGN KEY ([IdTreino]) REFERENCES [dbo].[Treinos] ([Id]);


GO
PRINT N'Creating FK_TreinosExercicios_Exercicios...';


GO
ALTER TABLE [dbo].[TreinosExercicios] WITH NOCHECK
    ADD CONSTRAINT [FK_TreinosExercicios_Exercicios] FOREIGN KEY ([IdExercicio]) REFERENCES [dbo].[Exercicios] ([Id]);


GO
PRINT N'Creating FK_UsuariosCargos_Usuarios...';


GO
ALTER TABLE [dbo].[UsuariosCargos] WITH NOCHECK
    ADD CONSTRAINT [FK_UsuariosCargos_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id]);


GO
PRINT N'Creating FK_UsuariosCargos_Cargos...';


GO
ALTER TABLE [dbo].[UsuariosCargos] WITH NOCHECK
    ADD CONSTRAINT [FK_UsuariosCargos_Cargos] FOREIGN KEY ([IdCargo]) REFERENCES [dbo].[Cargos] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '21e9d3c0-52ee-4c80-bedd-552f71ae793e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('21e9d3c0-52ee-4c80-bedd-552f71ae793e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b6bce3cd-76c4-4328-a136-7f3fbcc913b5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b6bce3cd-76c4-4328-a136-7f3fbcc913b5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '87b7b64c-1822-4210-a450-4cf6bfc892fb')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('87b7b64c-1822-4210-a450-4cf6bfc892fb')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'fa402940-21f0-4c74-8633-754cfdbf46df')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('fa402940-21f0-4c74-8633-754cfdbf46df')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1695083e-e457-4bbc-aa42-2ee2345ada34')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1695083e-e457-4bbc-aa42-2ee2345ada34')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3044382b-4b6f-4fb8-872d-22a23e65ff51')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3044382b-4b6f-4fb8-872d-22a23e65ff51')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ce1838e7-8b78-4431-803b-69cfb3700f29')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ce1838e7-8b78-4431-803b-69cfb3700f29')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Exercicios] WITH CHECK CHECK CONSTRAINT [FK_Exercicios_Maquinas];

ALTER TABLE [dbo].[Treinos] WITH CHECK CHECK CONSTRAINT [FK_Treinos_UsuariosAluno];

ALTER TABLE [dbo].[Treinos] WITH CHECK CHECK CONSTRAINT [FK_Treinos_UsuariosCriacao];

ALTER TABLE [dbo].[Treinos] WITH CHECK CHECK CONSTRAINT [FK_Treinos_CategoriasTreino];

ALTER TABLE [dbo].[TreinosAbertos] WITH CHECK CHECK CONSTRAINT [FK_TreinosAbertos_Treinos];

ALTER TABLE [dbo].[TreinosAbertosExerciciosRealizados] WITH CHECK CHECK CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_TreinosAbertos];

ALTER TABLE [dbo].[TreinosAbertosExerciciosRealizados] WITH CHECK CHECK CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_Exercicios];

ALTER TABLE [dbo].[TreinosExercicios] WITH CHECK CHECK CONSTRAINT [FK_TreinosExercicios_Treinos];

ALTER TABLE [dbo].[TreinosExercicios] WITH CHECK CHECK CONSTRAINT [FK_TreinosExercicios_Exercicios];

ALTER TABLE [dbo].[UsuariosCargos] WITH CHECK CHECK CONSTRAINT [FK_UsuariosCargos_Usuarios];

ALTER TABLE [dbo].[UsuariosCargos] WITH CHECK CHECK CONSTRAINT [FK_UsuariosCargos_Cargos];


GO
PRINT N'Update complete.';


GO
