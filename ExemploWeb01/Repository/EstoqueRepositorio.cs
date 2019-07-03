using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EstoqueRepositorio
    {
        //Através do objeto da conexão
        //poderá ter acesso ao SqlCommand
        //de uma form mais facil
        Conexao conexao = new Conexao();

        public int Inserir(Estoque estoque)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO estoques (nome, valor, quantidade) VALUES (@NOME,@VALOR,@QUANTIDADE)";
            //Substituí as Variáveis do comando acima
            comando.Parameters.AddWithValue("@NOME", estoque.Nome);
            comando.Parameters.AddWithValue("@VALOR", estoque.Valor);
            comando.Parameters.AddWithValue("@QUANTIDADE", estoque.Quantidade);
            //Executa o comando no BD e obtém o id que foi gerado automaticamente pela tabela.
            //ExecuteScalar: executa um comando no BD e obtém uma informação
            int id = Convert.ToInt32(comando.ExecuteScalar());
            //Fecha a conexão com o BD
            comando.Connection.Close();
            //Retorna o Id que foi gerado no BD
            return id;
        }

        public List<Estoque> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM estoques WHERE nome LIKE @BUSCA";
            busca = $"% {busca} %";
            comando.Parameters.AddWithValue("@BUSCA", busca);

            List<Estoque> estoques = new List<Estoque>();
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Estoque estoque = new Estoque();

                estoque.Id = Convert.ToInt32(linha["id"]);
                estoque.Nome = linha["nome"].ToString();
                estoque.Valor = Convert.ToDecimal(linha["valor"]);
                estoque.Quantidade = Convert.ToInt32(linha["quantidade"]);
                estoques.Add(estoque);
            }

            return estoques;
        }
    }
}
