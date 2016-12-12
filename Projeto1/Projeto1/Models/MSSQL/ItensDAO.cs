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
    public class ItensDAO : Erros
    {

        internal List<ModOfereceProduto> ListarPrato(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.valor, o.codigooferece, o.oferece, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +

                    "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
             
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 5 ";




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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModOfereceProduto> ListarPrincipal(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.codigooferece, o.valor, o.oferece, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +

                    "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
                    
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 6 ";




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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModOfereceProduto> ListarMistura(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.codigooferece, o.valor, o.oferece, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +

                  "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
                    
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 3 ";




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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModOfereceProduto> ListarGuarnicao(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.codigooferece,o.valor, o.oferece, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +
                    "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
                    
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 2 ";




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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModOfereceProduto> ListarBebida(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.codigooferece, o.valor, o.oferece,o.valor, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +

                    "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
                    
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 4 ";

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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModOfereceProduto> ListarSobremesa(string codigoEmpresa)
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
                // Nosso comando SQL
                query = "select p.codigoproduto, p.nomeproduto, o.codigooferece, o.oferece, o.valor, e.codigoempresa,ti.codigotipo, ti.descricao from produto p " +

                    "INNER JOIN ofereceproduto o ON " +
                    "p.codigoProduto = o.codProduto " +
                    "INNER JOIN empresa e ON " +
                    "o.codempresa = e.codigoempresa " +
                    "INNER JOIN tipoproduto ti ON " +
                    "p.codTipoProduto = ti.codigotipo " +
                    "WHERE o.oferece = 2 and " +
                   
                    " o.dia = DATE_FORMAT(now(), '%w') and " +
                    "e.codigoempresa = '" + codigoEmpresa + "' and " +
                    "ti.codigoTipo = 1 ";
                



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

                    oferece.Add(read_OfereceProduto(reader));
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

        internal List<ModCliente> LoginCliente(string email,string senha)
        {
            // Instancia nossos objetos
            List<ModCliente> resultado = new List<ModCliente>();
            // Instancia nossa Conexao
            Conexao conexao = new Conexao(TipoConexao.Conexao.WebConfig);

            // Se existe erro na conexao move o erro para a classe de acesso 
            if (conexao.ExisteErro())
            {
                setMensagemErro(conexao.mErro);
                return resultado;
            }

            try
            {
                MySqlDataReader reader;
                String query = "";
                // Nosso comando SQL
                query = "select codigocliente from cliente " +
                        "where email ='" + email + "' and senha='" + senha + "' ";




                MySqlCommand cmd = new MySqlCommand(query, conexao.conn);

                // define que o comando é um texto
                cmd.CommandType = System.Data.CommandType.Text;

                // Abre nossa Conexao
                if (conexao.OpenConexao() == false)
                {

                    setMensagemErro(conexao.mErro);
                    return resultado;
                }

                reader = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (reader.Read())
                {

                    resultado.Add(read_Cliente(reader));
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
            return resultado;
        }

        private ModCliente read_Cliente(MySqlDataReader reader)
        {
            ModCliente cliente = new ModCliente();
            cliente.codigoCliente = ConvertReader.ConverteInt(reader["codigocliente"]);
            


            return cliente;
        }
        private ModEmpresa read_Empresa(MySqlDataReader reader)
        {
            ModEmpresa empresa = new ModEmpresa();
            empresa.codigoEmpresa = ConvertReader.ConverteInt(reader["codigoempresa"]);


            return empresa;
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
        private ModOfereceProduto read_OfereceProduto(MySqlDataReader reader)
        {
            ModOfereceProduto oferece = new ModOfereceProduto();
            oferece.codigoOferece = ConvertReader.ConverteInt(reader["codigooferece"]);
            oferece.valor = ConvertReader.ConverteDouble(reader["valor"]);
            oferece.oferece = ConvertReader.ConverteInt(reader["oferece"]);


            oferece.empresa = read_Empresa(reader);
            oferece.produto = read_Produto(reader);


            return oferece;
        }
    }

}
