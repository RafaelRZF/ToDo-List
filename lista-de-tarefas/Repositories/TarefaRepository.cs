using MySql.Data.MySqlClient;
using lista_de_tarefas.Models;
using lista_de_tarefas.Database;

namespace lista_de_tarefas.Repositories
{
    public class TarefaRepository
    {
        public void Criar(string titulo)
        {
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand(
                "INSERT INTO tarefas (titulo) VALUES (@titulo)", conn);
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.ExecuteNonQuery();
        }

        public List<Tarefa> Listar()
        {
            var lista = new List<Tarefa>();
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand("SELECT * FROM tarefas", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Tarefa
                {
                    Id = reader.GetInt32("id"),
                    Titulo = reader.GetString("titulo"),
                    Concluida = reader.GetBoolean("concluida"),
                    CriadaEm = reader.GetDateTime("criada_em")
                });
            }
            return lista;
        }

        public void Concluir(int id)
        {
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand(
                "UPDATE tarefas SET concluida = TRUE WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void Editar(int id, string novoTitulo)
        {
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand(
                "UPDATE tarefas SET titulo = @titulo WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@titulo", novoTitulo);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int id)
        {
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand(
                "DELETE FROM tarefas WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public List<Tarefa> FiltrarPorStatus(bool concluida)
        {
            var lista = new List<Tarefa>();
            using var conn = Conexao.Obter();
            conn.Open();
            var cmd = new MySqlCommand(
                "SELECT * FROM tarefas WHERE concluida = @status", conn);
            cmd.Parameters.AddWithValue("@status", concluida);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Tarefa
                {
                    Id = reader.GetInt32("id"),
                    Titulo = reader.GetString("titulo"),
                    Concluida = reader.GetBoolean("concluida"),
                    CriadaEm = reader.GetDateTime("criada_em")
                });
            }
            return lista;
        }
    }
}