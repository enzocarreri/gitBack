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
    public class EmpresaDAO : Erros
    {
        internal List<ModEmpresa> ListarRestaurante(string nomeCidade)
        {
            // Instancia nossos objetos
            List<ModEmpresa> empresa = new List<ModEmpresa>();

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
                // Nosso comando SQL
                if(!String.IsNullOrEmpty(nomeCidade))
                {

                     query = "  and c.nomecidade = '" + nomeCidade.ToString() + "' ";
                }
                
                
                 query = "select e.codigoEmpresa, e.nomeApresentado, e.endereco, c.idcidade, c.nomecidade " +
                              "from empresa e INNER JOIN cidade c ON e.codcidade = c.idcidade " +
                              "where  e.ativada = 1 " + query +" ";
                
               
                

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

                    empresa.Add(read_Empresa(reader));
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

        private ModCidade read_Cidade(MySqlDataReader reader)
        {
            ModCidade cidade = new ModCidade();
            cidade.id = ConvertReader.ConverteInt(reader["idcidade"]);
            cidade.nome = (string)reader["nomecidade"] ?? "";

            return cidade;
        }
        
        private ModEmpresa read_Empresa(MySqlDataReader reader)
        {
            ModEmpresa empresa = new ModEmpresa();
            empresa.codigoEmpresa = ConvertReader.ConverteInt(reader["codigoempresa"]);
            empresa.nomeApresentacao = (string)reader["nomeapresentado"] ?? "";
            empresa.endereco = (string)reader["endereco"] ?? "";

            empresa.cidade = read_Cidade(reader);



            return empresa;
        }

        internal List<ModEmpresa> ListarEmpresaNome(string nomeEmpresa)
        {
            // Instancia nossos objetos
            List<ModEmpresa> empresa = new List<ModEmpresa>();

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
                nomeEmpresa = nomeEmpresa + "%";
                // Nosso comando SQL
                if (!String.IsNullOrEmpty(nomeEmpresa))
                {

                    query = "  and e.nomeApresentado like '" + nomeEmpresa.ToString() + "' ";
                }


                query = "select e.codigoEmpresa, e.nomeApresentado, e.endereco, c.idcidade, c.nomecidade " +
                             "from empresa e INNER JOIN cidade c ON e.codcidade = c.idcidade " +
                             "where  e.ativada = 1 " + query + " ";




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

                    empresa.Add(read_Empresa(reader));
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
    }
}
