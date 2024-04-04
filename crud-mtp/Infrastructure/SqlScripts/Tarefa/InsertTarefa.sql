INSERT INTO [dbo].[Tarefas]
           ([Id]
           ,[Nome]
           ,[Concluido]
           ,[DataCriacao]
           ,[DataAtualizacao])
     VALUES
           (newid()
           ,@Nome
           ,0
           ,getdate()
           ,getdate())
