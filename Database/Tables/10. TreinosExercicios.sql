CREATE TABLE [dbo].[TreinosExercicios]
(
	[IdTreino] INT NOT NULL, 
    [IdExercicio] INT NOT NULL, 
    CONSTRAINT [FK_TreinosExercicios_Treinos] FOREIGN KEY ([IdTreino]) REFERENCES [Treinos]([Id]),
    CONSTRAINT [FK_TreinosExercicios_Exercicios] FOREIGN KEY ([IdExercicio]) REFERENCES [Exercicios]([Id])
)

GO

CREATE INDEX [IX_TreinosExercicios_IdTreino] ON [dbo].[TreinosExercicios] ([IdTreino])

GO

CREATE INDEX [IX_TreinosExercicios_IdExercicio] ON [dbo].[TreinosExercicios] ([IdExercicio])
