UPDATE [dbo].[Tarefas]
SET [Concluido] = @Concluido,
    [DataAtualizacao] = getdate()
WHERE Id = @Id;

