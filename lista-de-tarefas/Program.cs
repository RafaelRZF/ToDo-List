using lista_de_tarefas.Repositories;

var repo = new TarefaRepository();

// Teste: criar uma tarefa
repo.Criar("Minha primeira tarefa");

// Teste: listar tarefas
var tarefas = repo.Listar();
foreach (var t in tarefas)
{
    Console.WriteLine($"[{t.Id}] {t.Titulo} - Concluida: {t.Concluida} - Criada em: {t.CriadaEm}");
}

Console.ReadKey();