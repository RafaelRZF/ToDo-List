using MySql.Data.MySqlClient;

namespace lista_de_tarefas.Database
{
    public class Conexao
    {
        private static string _connectionString =
        "Server=localhost;Database=todolist;Uid=root;Pwd=;";

        public static MySqlConnection Obter()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}