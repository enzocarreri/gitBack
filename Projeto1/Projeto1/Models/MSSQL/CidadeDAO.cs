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
    public class CidadeDAO : Erros
    {
        internal List<ModCidade> ListarCidade()
        {
            // Instancia nossos objetos
            List<ModCidade> cidade = new List<ModCidade>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return cidade;
            }

            try
            {
                MySqlDataReader reader;

                // Nosso comando SQL
                string query = "select c.idcidade,c.nomecidade from cidade c "+
                                " INNER JOIN empresa e ON e.codcidade = c.idcidade "+
                                " where estado = 26 "+
                                 "group by nomecidade";




                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return cidade;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    cidade.Add(read_Cidade(reader));
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
            return cidade;
        }
        private ModCidade read_Cidade(MySqlDataReader reader)
        {
            ModCidade cidade = new ModCidade();
            cidade.id = ConvertReader.ConverteInt(reader["idcidade"]);
            cidade.nome = (string)reader["nomecidade"] ?? "";

            

            return cidade;
        }

       
    }


}