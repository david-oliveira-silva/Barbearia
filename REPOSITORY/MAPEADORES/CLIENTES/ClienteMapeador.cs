using System.Data.Common;
using DOMAIN.INTERFACES;
using DOMAIN.MODELS.CLIENTES;
using REPOSITORY.DATA;
using REPOSITORY.UTILS;

namespace REPOSITORY.MAPEADORES.Clientes
{
    public class ClienteMapeador : IClienteMapeador
    {

        public void Cadastrar(ClienteModel cliente)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"INSERT INTO CLIENTES (NOME, CPF, EMAIL, TELEFONE) VALUES (@NOME, @CPF, @EMAIL, @TELEFONE)";
            cmd.Parameters.CreateParameter(cmd, @"NOME", cliente.Nome);
            cmd.Parameters.CreateParameter(cmd, @"CPF", cliente.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"EMAIL", cliente.Email);
            cmd.Parameters.CreateParameter(cmd, @"TELEFONE", cliente.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Atualizar(ClienteModel cliente)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"UPDATE CLIENTES SET NOME = @NOME,CPF = @CPF,EMAIL = @EMAIL,TELEFONE = @TELEFONE WHERE IDCLIENTE = @IDCLIENTE";
            cmd.Parameters.CreateParameter(cmd, @"IDCLIENTE", cliente.IdCliente);
            cmd.Parameters.CreateParameter(cmd, @"NOME", cliente.Nome);
            cmd.Parameters.CreateParameter(cmd, @"CPF", cliente.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"EMAIL", cliente.Email);
            cmd.Parameters.CreateParameter(cmd, @"TELEFONE", cliente.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Excluir(ClienteModel cliente)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "DELETE FROM CLIENTES WHERE IDCLIENTE = @IDCLIENTE";
            cmd.Parameters.CreateParameter(cmd, @"IDCLIENTE", cliente.IdCliente);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public List<ClienteModel> Listar()
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            conexao.Open();

            List<ClienteModel> listaClientes = [];

            cmd.CommandText = "SELECT IDCLIENTE,NOME,CPF,EMAIL,TELEFONE FROM CLIENTES";
            DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ClienteModel cliente = new()
                {
                    IdCliente = reader.GetInt("IDCLIENTE"),
                    Nome = reader.GetString("NOME"),
                    Cpf = reader.GetString("CPF"),
                    Email = reader.GetString("EMAIL"),
                    Telefone = reader.GetString("TELEFONE")
                };
                listaClientes.Add(cliente);
            }
            return listaClientes;
        }

        List<ClienteModel>? IClienteMapeador.BuscarClientePorNome(string nome)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            List<ClienteModel> listaClientes = [];

            cmd.CommandText = "SELECT IDCLIENTE,NOME,CPF,EMAIL,TELEFONE FROM CLIENTES WHERE NOME LIKE @NOME";
            cmd.Parameters.CreateParameter(cmd, @"NOME", $"%{nome}%");
            conexao.Open();
            DbDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                ClienteModel cliente = new()
                {
                    IdCliente = reader.GetInt("IDCLIENTE"),
                    Nome = reader.GetString("NOME"),
                    Cpf = reader.GetString("CPF"),
                    Email = reader.GetString("EMAIL"),
                    Telefone = reader.GetString("TELEFONE")
                };
                listaClientes.Add(cliente);
            }
            return listaClientes;
        }

    }
}
