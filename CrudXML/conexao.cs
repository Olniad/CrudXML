using MySql.Data.MySqlClient;
using System.Data;

namespace CrudXML
{
    class conexao
    {
        private MySqlConnection Conexao;
        public void ConectarBD()
        {

            Conexao = new MySqlConnection("persist security info = false;" +
                                          "server=localhost;" +
                                          "database=BDCADASTRO" +
                                          "uid=root;pwd=;SslMode=none");
            Conexao.Open();
        }
    }
}
