CREATE TABLE [dbo].[ExerciciosGruposMusculares]
(
	[IdExercicio] INT NOT NULL, 
    [IdGrupoMuscular] INT NOT NULL, 
    CONSTRAINT [FK_ExerciciosGruposMusculares_Exercicios] FOREIGN KEY ([IdExercicio]) REFERENCES [Exercicios]([Id]), 
    CONSTRAINT [FK_ExerciciosGruposMusculares_GruposMusculares] FOREIGN KEY ([IdGrupoMuscular]) REFERENCES [GruposMusculares]([Id])
)

GO

CREATE INDEX [IX_ExerciciosGruposMusculares_IdExercicio] ON [dbo].[ExerciciosGruposMusculares] ([IdExercicio])

GO

CREATE INDEX [IX_ExerciciosGruposMusculares_IdGrupoMuscular] ON [dbo].[ExerciciosGruposMusculares] ([IdGrupoMuscular])
