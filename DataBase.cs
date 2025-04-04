using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Database
    {
        private MySqlConnection conexao;

        public Database()
        {
            conexao = new MySqlConnection("Server=localhost;Database=bdestacao;Uid=root;Pwd=root;");
        }

        public MySqlConnection Connection => conexao; // Propriedade para acessar a conexão

        public bool TestarConexao()
        {
            try
            {
                conexao.Open();
                conexao.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ExecutarComando(string query, MySqlParameter[] parametros = null, IWin32Window owner = null)
        {
            try
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, "Erro: " + ex.Message);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool InserirDados(string tabela, MySqlParameter[] parametros, IWin32Window owner = null)
        {
            // Cria a string de consulta SQL para inserção
            string colunas = string.Join(", ", Array.ConvertAll(parametros, p => p.ParameterName.TrimStart('@')));
            string valores = string.Join(", ", Array.ConvertAll(parametros, p => "?")); // Adiciona o símbolo de interrogação para parâmetros

            string query = $"INSERT INTO {tabela} ({colunas}) VALUES ({valores})";

            return ExecutarComando(query, parametros, owner); // Usa o método ExecutarComando para executar a inserção
        }

        public DataTable BuscarDados(string query, MySqlParameter[] parametros = null, IWin32Window owner = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conexao.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                {
                    if (parametros != null)
                    {
                        cmd.Parameters.AddRange(parametros);
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, "Erro ao buscar dados: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            return dataTable;
        }
    }
}
