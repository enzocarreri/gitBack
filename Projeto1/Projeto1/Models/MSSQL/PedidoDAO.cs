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
    public class PedidoDAO : Erros
    {
        internal List<ModOfereceProduto> ListarPedido(string pedido,string empresa)
        {
            // Instancia nossos objetos
            List<ModOfereceProduto> oferece = new List<ModOfereceProduto>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return oferece;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";
                
                int i = 2;

                while (i < pedido.Length)
                {
                    if (i == 2)
                    {
                        query =  " p.codigoproduto ='" + pedido.Substring(i, 2) + "'";
                        i = i + 2;
                    }
                    else
                    {
                        query = query + " or p.codigoproduto='" + pedido.Substring(i, 2) + "'";
                        i = i + 2;
                    }
                    
                }
                
                             
                
                query = "select  p.codigoproduto,o.valor,o.codigooferece, p.nomeproduto, t.descricao, t.codigotipo, o.codigooferece from produto p " +
                    "INNER JOIN tipoproduto t ON p.codtipoproduto = t.codigotipo " +
                    "INNER JOIN ofereceproduto o ON o.codproduto=p.codigoproduto " +
                //"WHERE (" + query + ") and ( o.dia=3 and o.codempresa='"+Convert.ToInt32(empresa)+"') ORDER BY t.descricao";
                "WHERE (" + query + ") and ( o.dia=3 and o.codempresa='"+Convert.ToInt32(empresa)+"') ORDER BY field (t.descricao " +
                " , '"+"prato"+ "','" + "principal" + "','" + "mistura" + "','" + "guarnicao" + "','" + "bebida" + "','" + "sobremesa" + "')";


                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return oferece;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    oferece.Add(read_Oferece(reader));
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
            return oferece;
        }



        internal List<ModItensPedidos> SugestaoBebida(string mistura)
        {
            // Instancia nossos objetos
            List<ModItensPedidos> sugestao = new List<ModItensPedidos>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return sugestao;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";



                query = "select p.codigoproduto, p.nomeproduto, t.descricao, t.codigotipo, count(i.codigoItens) as 'contagem', o.valor, o.codigooferece  " +
                          " from produto p, empresa e, tipoproduto t, itenspedido i, pedido pe, ofereceproduto o " +
                          " WHERE p.codtipoproduto = t.codigotipo and p.codigoproduto = i.codProdutopedido " +
                          " and i.coditenspedido = pe.codigopedido and o.codproduto = p.codigoproduto " +
                          " and e.codigoempresa = o.codempresa and pe.codigopedido " +
                          " in (select pe.codigopedido from produto p, empresa e, tipoproduto t, itenspedido i, pedido pe, ofereceproduto o " +
                          " WHERE p.codtipoproduto = t.codigotipo and p.codigoproduto = i.codProdutopedido " +
                          " and i.coditenspedido = pe.codigopedido and o.codproduto = p.codigoproduto " +
                          " and e.codigoempresa = o.codempresa and p.codigoProduto = '" + mistura + "' ) " +
                          " and p.codigoProduto != '" + mistura + "' and t.codigoTipo = 4 " +
                          " group by p.codigoProduto " +
                          " order by contagem desc limit 1 ";





                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return sugestao;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    sugestao.Add(read_ItensPedido(reader));
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
            return sugestao;
        }
    

        internal List<ModItensPedidos> SugestaoSobre(string mistura)
        {
            // Instancia nossos objetos
            List<ModItensPedidos> sugestao = new List<ModItensPedidos>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return sugestao;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";



               query = "select p.codigoproduto, p.nomeproduto, t.descricao, t.codigotipo, count(i.codigoItens) as 'contagem', o.valor, o.codigooferece  " +
                         " from produto p, empresa e, tipoproduto t, itenspedido i, pedido pe, ofereceproduto o " +
                         " WHERE p.codtipoproduto = t.codigotipo and p.codigoproduto = i.codProdutopedido " +
                         " and i.coditenspedido = pe.codigopedido and o.codproduto = p.codigoproduto " +
                         " and e.codigoempresa = o.codempresa and pe.codigopedido " +
                         " in (select pe.codigopedido from produto p, empresa e, tipoproduto t, itenspedido i, pedido pe, ofereceproduto o " +
                         " WHERE p.codtipoproduto = t.codigotipo and p.codigoproduto = i.codProdutopedido " +
                         " and i.coditenspedido = pe.codigopedido and o.codproduto = p.codigoproduto " +
                         " and e.codigoempresa = o.codempresa and p.codigoProduto = '" + mistura +"' ) " +
                         " and p.codigoProduto != '"+mistura+"' and t.codigoTipo = 1 " +
                         " group by p.codigoProduto " +
                         " order by contagem desc limit 1 ";





                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return sugestao;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    sugestao.Add(read_ItensPedido(reader));
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
            return sugestao;
        }

        private ModItensPedidos read_ItensPedido(MySqlDataReader reader)
        {
            ModItensPedidos item = new ModItensPedidos();
            item.contagemVenda = ConvertReader.ConverteInt(reader["contagem"]);
            

            item.produto = read_Produto(reader);
            item.oferece = read_Oferece(reader);
            return item;
        }

        internal List<ModCliente> LocalEntrega(string cliente)
        {
            // Instancia nossos objetos
            List<ModCliente> cli = new List<ModCliente>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return cli;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";
                // Nosso comando SQL
                query = "select endereco, numero from cliente " +

                    "WHERE codigocliente = '" + cliente + "'";




                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return cli;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    cli.Add(read_Cliente(reader));
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
            return cli;
        }

        private ModCliente read_Cliente(MySqlDataReader reader)
        {
            ModCliente cliente = new ModCliente();
            
            cliente.endereco = (string)reader["endereco"] ?? "";
            cliente.numero = (string)reader["numero"] ?? "";

            

            return cliente;
        }

        internal string FinalizarPedido(string pedido, string cliente, string endereco, string numero, string valor, string codBeb1, string valorBeb1, string codSobre1, string valorSobre1)
        {
            // Instancia nossos objetos
            List<ModPedido> itensPedido = new List<ModPedido>();

            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return "erro";
            }
            pedido = pedido + codBeb1 + codSobre1;
            
            
            try
            {
                double valorfinal = 0;
                int i;
                valorfinal = Convert.ToDouble(valor.Substring(1, 2));
                for (i = 2; i < valor.Length; i++)
                {
                    valorfinal = valorfinal + Convert.ToDouble(valor.Substring(i, 1));
                }
               
                if(!String.IsNullOrEmpty(codSobre1))
                {
                    if(!String.IsNullOrEmpty(codBeb1))
                    {
                        double val1 = Convert.ToDouble(valorBeb1);
                        double val2 = Convert.ToDouble(valorSobre1);
                        valorfinal = valorfinal + val1 + val2;
                    }
                    else
                    {
                        double val2 = Convert.ToDouble(valorSobre1);
                        valorfinal = valorfinal + val2;
                    }

                }
                else
                {
                    if (!String.IsNullOrEmpty(codSobre1))
                    {
                        double val2 = Convert.ToDouble(valorSobre1);
                        valorfinal = valorfinal + val2;
                    }
                    if (!String.IsNullOrEmpty(codBeb1))
                    {
                        double val1 = Convert.ToDouble(valorBeb1);
                        valorfinal = valorfinal + val1;
                    }

                   
                    
                }

                MySqlDataReader reader;
                string query1 = "", query2 = "", query3 = "";
                string empresa = "";


                DateTime saveNow = DateTime.Now;

                empresa = pedido.Substring(0, 2);
                query1 = "insert into pedido(codclientepedido,codempresapedido,datavenda, enderecoentrega,numeroentrega,valor) values (  '" + Convert.ToInt32(cliente) + "', '" + Convert.ToInt32(empresa) + "', now(), '" + endereco + "', '" + numero + "', '" + valorfinal + "')";


                query2 = "select codigopedido from pedido order by codigopedido desc limit 1";








                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return "erro";
                }
                MySqlCommand cmd1 = new MySqlCommand(query1, conexao.conn);
                cmd1.ExecuteNonQuery();
                cmd1.Dispose();

                MySqlCommand cmd2 = new MySqlCommand(query2, conexao.conn);
                cmd2.CommandType = System.Data.CommandType.Text;
                reader = cmd2.ExecuteReader();

                string codigo = "";
                while (reader.Read())
                {

                    itensPedido.Add(read_Pedido(reader));
                    codigo = reader["codigopedido"].ToString();
                }




                i = 2;
                reader.Dispose();

                while (i < pedido.Length)
                {
                    query3 = "INSERT INTO itenspedido (codprodutopedido,coditenspedido) values ( '" + Convert.ToInt32(pedido.Substring(i, 2)) + "', '" + Convert.ToInt32(codigo) + "' )";
                    i = i + 2;
                    MySqlCommand cmd3 = new MySqlCommand(query3, conexao.conn);
                    try
                    {
                        cmd3.ExecuteNonQuery();


                    }
                    catch (SystemException ex)
                    {
                        return "falha";
                    }
                    finally
                    {
                        cmd3.Dispose();
                    }
                }

            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                setMensagemErro(e.Message.ToString());
            }
           
            // Fecha nossa Conexao
            conexao.CloseConexao();

            return "Pedido realizado";
        }

        private ModPedido read_Pedido(MySqlDataReader reader)
        {
            ModPedido pedido = new ModPedido();
            
            pedido.codigoPedido = ConvertReader.ConverteInt(reader["codigopedido"]);
     

            return pedido;
        }

        private ModOfereceProduto read_Oferece(MySqlDataReader reader)
        {
            ModOfereceProduto o = new ModOfereceProduto();
            o.codigoOferece = ConvertReader.ConverteInt(reader["codigooferece"]);
            o.valor = ConvertReader.ConverteDouble(reader["valor"]);

            o.produto = read_Produto(reader);

            return o;
        }

        private ModProduto read_Produto(MySqlDataReader reader)
        {
            ModProduto produto = new ModProduto();
            produto.codigoProduto = ConvertReader.ConverteInt(reader["codigoproduto"]);
            produto.nomeProduto = (string)reader["nomeproduto"] ?? "";

            produto.tipoProduto = read_TipoProduto(reader);

            return produto;
        }
        private ModTipoProduto read_TipoProduto(MySqlDataReader reader)
        {
            ModTipoProduto tipo = new ModTipoProduto();
            tipo.codigoTipo = ConvertReader.ConverteInt(reader["codigoTipo"]);
            tipo.descricao = (string)reader["descricao"] ?? "";


            return tipo;
        }
    }
}