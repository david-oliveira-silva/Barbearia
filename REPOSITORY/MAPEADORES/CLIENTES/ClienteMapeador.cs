using System.Data.Common;
using DOMAIN.MODELS;
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
            cmd.Parameters.CreateParameter(cmd, @"Nome", cliente.Nome);
            cmd.Parameters.CreateParameter(cmd, @"Cpf", cliente.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"Email", cliente.Email);
            cmd.Parameters.CreateParameter(cmd, @"Telefone", cliente.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Atualizar(ClienteModel cliente)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"UPDATE CLIENTES SET NOME = @Nome,CPF = @Cpf,EMAIL = @Email,TELEFONE = @Telefone WHERE IDCLIENTE = @IdCliente";
            cmd.Parameters.CreateParameter(cmd, @"IdCliente", cliente.IdCliente);
            cmd.Parameters.CreateParameter(cmd, @"Nome", cliente.Nome);
            cmd.Parameters.CreateParameter(cmd, @"Cpf", cliente.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"Email", cliente.Email);
            cmd.Parameters.CreateParameter(cmd, @"Telefone", cliente.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Excluir(ClienteModel cliente)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "DELETE FROM CLIENTES WHERE IDCLIENTE = @IdCliente";
            cmd.Parameters.CreateParameter(cmd, @"IdCliente", cliente.IdCliente);
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
            var reader = cmd.ExecuteReader();

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

    
    }
}
