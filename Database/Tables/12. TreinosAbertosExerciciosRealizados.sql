CREATE TABLE [dbo].[TreinosAbertosExerciciosRealizados]
(
	[IdTreinoAberto] INT NOT NULL, 
    [IdExercicio] INT NOT NULL, 
    CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_TreinosAbertos] FOREIGN KEY ([IdTreinoAberto]) REFERENCES [TreinosAbertos]([Id]), 
    CONSTRAINT [FK_TreinosAbertosExerciciosRealizados_Exercicios] FOREIGN KEY ([IdExercicio]) REFERENCES [Exercicios]([Id])
)
