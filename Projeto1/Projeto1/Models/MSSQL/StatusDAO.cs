using Aprendendo.Models.MSSQL;
using MySql.Data.MySqlClient;
using Projeto1.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projeto1.Models.MSSQL
{
    public class StatusDAO:Erros
    {
        

        internal List<ModPedido> ListarPedidoItemEmpresa(string codigoPedido)
        {
            // Instancia nossos objetos
            List<ModPedido> empresa = new List<ModPedido>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return empresa;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";




                query = "select pe.status,pe.codigopedido " +
                             " from pedido pe "+ 
                             " where pe.codigopedido='" + codigoPedido + "'"; 




                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return empresa;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    empresa.Add(read_ItensPedido3(reader));
                }
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                setMensagemErro(e.Message.ToString());
            }

            // Fecha nossa Conexao
            conexao.CloseConexao();

            // Retorna nossa lista de dados
            return empresa;
        }

        internal string NovoStatus(string status,string codigoPedido)
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
            query = "UPDATE pedido " +
                       " SET status = '" + status + "' " +
                       " WHERE codigopedido = '" + codigoPedido + "' ";



            if (conexao.OpenConexao() == false)
            {

                setMensagemErro(conexao.mErro);
                return "erro";
            }


            MySqlCommand cmd3 = new MySqlCommand(query, conexao.conn);
            cmd3.ExecuteNonQuery();
            cmd3.Dispose();

            conexao.CloseConexao();

            
            return "ok";

            

           
        }

        private ModPedido read_ItensPedido3(MySqlDataReader reader)
        {
            ModPedido pedido = new ModPedido();

            pedido.codigoPedido = ConvertReader.ConverteInt(reader["codigopedido"]);
            
            pedido.status = (string)reader["status"] ?? "";

            return pedido;
        }
    }
}