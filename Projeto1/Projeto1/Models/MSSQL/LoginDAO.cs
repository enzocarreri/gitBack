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
    public class LoginDAO : Erros
    {
        internal List<ModItensPedidos> ListarPedidosEmpresa(string login, string senha)
        {
            // Instancia nossos objetos
            List<ModItensPedidos> empresa = new List<ModItensPedidos>();

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
                
                


                query = "select c.codigocliente,c.nomecliente,e.codigoEmpresa, e.nomeapresentado, pe.codigopedido, pe.datavenda, pe.status, p.codigoproduto, p.nomeproduto,i.codigoitens " +
                             " from cliente c INNER JOIN pedido pe ON pe.codclientepedido=c.codigocliente " +
                             "INNER JOIN empresa e ON pe.codempresapedido = e.codigoempresa " +
                             " INNER JOIN  itenspedido i ON pe.codigopedido = i.coditenspedido " +
                             " INNER JOIN produto p ON p.codigoproduto=i.codprodutopedido " +
                             " where e.senha='" + senha + "' and  e.login='" + login + "' " +
                             " ORDER BY pe.DATAVENDA desc";




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

                    empresa.Add(read_ItensPedido(reader));
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

        internal List<ModItensPedidos> ListarPedidosCliente(string login, string senha)
        {
            // Instancia nossos objetos
            List<ModItensPedidos> cliente = new List<ModItensPedidos>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return cliente;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";




                query = "select c.codigocliente,c.nomecliente,e.codigoEmpresa, e.nomeapresentado, pe.codigopedido, pe.datavenda, pe.status, p.codigoproduto, p.nomeproduto,i.codigoitens " +
                             " from cliente c INNER JOIN pedido pe ON pe.codclientepedido=c.codigocliente " +
                             "INNER JOIN empresa e ON pe.codempresapedido = e.codigoempresa " +
                             " INNER JOIN  itenspedido i ON pe.codigopedido = i.coditenspedido " +
                             " INNER JOIN produto p ON p.codigoproduto=i.codprodutopedido " +
                             " where c.senha='" + senha + "' and  c.login='" + login + "' " +
                             " ORDER BY pe.DATAVENDA desc";




                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return cliente;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    cliente.Add(read_ItensPedido(reader));
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
            return cliente;
        }
        private ModCliente read_Cliente(MySqlDataReader reader)
        {
            ModCliente cliente = new ModCliente();
            cliente.codigoCliente = ConvertReader.ConverteInt(reader["codigocliente"]);
            cliente.nomeCliente = (string)reader["nomecliente"] ?? "";




            return cliente;
        }
        private ModEmpresa read_Empresa(MySqlDataReader reader)
        {
            ModEmpresa empresa = new ModEmpresa();
            empresa.codigoEmpresa = ConvertReader.ConverteInt(reader["codigoempresa"]);
            empresa.nomeApresentacao = (string)reader["nomeapresentado"] ?? "";
            


            
            return empresa;
        }
        private ModPedido read_Pedido(MySqlDataReader reader)
        {
            ModPedido pedido = new ModPedido();
            pedido.codigoPedido = ConvertReader.ConverteInt(reader["codigopedido"]);
            pedido.dataVenda = ConvertReader.ConverteDateTime(reader["datavenda"]);
            pedido.status = ConvertReader.ConverteInt(reader["status"]);
            pedido.empresa = read_Empresa(reader);
            pedido.cliente = read_Cliente(reader);
            return pedido;
        }
        private ModItensPedidos read_ItensPedido(MySqlDataReader reader)
        {
            ModItensPedidos itens = new ModItensPedidos();
            itens.codigoItens = ConvertReader.ConverteInt(reader["codigoitens"]);
            itens.produto = read_Produto(reader);

            itens.pedido = read_Pedido(reader);

            return itens;
        }
        private ModProduto read_Produto(MySqlDataReader reader)
        {
            ModProduto produto = new ModProduto();
           
            produto.nomeProduto = (string)reader["nomeproduto"];

            return produto;
        }
    }
}