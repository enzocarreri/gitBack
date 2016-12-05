using Aprendendo.Models.MSSQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models.MSSQL
{
    public class CadastroDAO:Erros
    {
        internal string Cadastrar(string nome, string email, string endereco, string numero, string telefone, string senha)
        {



            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return "erro";
            }



            string query;
            // Nosso comando SQL
            query = "INSERT INTO cliente (nomecliente,email,endereco,numero,telefone1,senha) values ( '" + nome + "', '" + email + "' , '" + endereco + "'," +
                    " '" + numero + "','" + telefone + "','" + senha + "' )";


            if (conexao.OpenConexao() == false)
            {

                setMensagemErro(conexao.mErro);
                return "erro";
            }


            MySqlCommand cmd3 = new MySqlCommand(query, conexao.conn);
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();

            

            conexao.CloseConexao();

            // Retorna nossa lista de dados
            return "ok";






        }
    }
}