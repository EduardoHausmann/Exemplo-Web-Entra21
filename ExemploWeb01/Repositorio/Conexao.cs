using System.Data.SqlClient;

namespace Repositorio
{
    public class Conexao
    {
        public SqlCommand Conectar()
        {
            SqlConnection conexao = new
                SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\NossoEstoque.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new
                SqlCommand();
            comando.Connection = conexao;
            return comando;
        }
    }
}
