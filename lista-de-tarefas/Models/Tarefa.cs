namespace lista_de_tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
        public DateTime CriadaEm { get; set; }
    }
}