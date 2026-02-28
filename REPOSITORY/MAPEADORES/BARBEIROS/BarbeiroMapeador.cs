using System.Data.Common;
using DOMAIN.MODELS.BARBEIROS;
using REPOSITORY.DATA;
using REPOSITORY.UTILS;

namespace REPOSITORY.MAPEADORES.BARBEIROS
{
    public class BarbeiroMapeador : IBarbeiroMapeador
    {
        public void Cadastrar(BarbeiroModel barbeiro)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"INSERT INTO CLIENTES (NOME, CPF, EMAIL, TELEFONE) VALUES (@NOME, @CPF, @EMAIL, @TELEFONE)";
            cmd.Parameters.CreateParameter(cmd, @"NOME", barbeiro.Nome);
            cmd.Parameters.CreateParameter(cmd, @"CPF", barbeiro.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"EMAIL", barbeiro.Email);
            cmd.Parameters.CreateParameter(cmd, @"TELEFONE", barbeiro.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Atualizar(BarbeiroModel barbeiro)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"UPDATE BARBEIROS SET NOME = @NOME, CPF = @CPF, EMAIL = @EMAIL, TELEFONE = @TELEFONE WHERE IDBARBEIRO = @IDBARBEIRO";
            cmd.Parameters.CreateParameter(cmd, @"IDBARBEIRO", barbeiro.IdBarbeiro);
            cmd.Parameters.CreateParameter(cmd, @"NOME", barbeiro.Nome);
            cmd.Parameters.CreateParameter(cmd, @"CPF", barbeiro.Cpf);
            cmd.Parameters.CreateParameter(cmd, @"EMAIL", barbeiro.Email);
            cmd.Parameters.CreateParameter(cmd, @"TELEFONE", barbeiro.Telefone);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Excluir(BarbeiroModel barbeiro)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "DELETE FROM CLIENTES WHERE IDCLIENTE = @IDCLIENTE";
            cmd.Parameters.CreateParameter(cmd, @"IDBARBEIRO", barbeiro.IdBarbeiro);
            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public List<BarbeiroModel> Listar()
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            conexao.Open();

            List<BarbeiroModel> ListaBarbeiros = [];

            cmd.CommandText = "SELECT IDCLIENTE,NOME,CPF,EMAIL,TELEFONE FROM BARBEIROS";            

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BarbeiroModel barbeiros = new()
                {
                    IdBarbeiro = reader.GetInt("BARBEIRO"),
                    Nome = reader.GetString("NOME"),
                    Cpf = reader.GetString("CPF"),
                    Email = reader.GetString("EMAIL"),
                    Telefone = reader.GetString("TELEFONE")
                };
                ListaBarbeiros.Add(barbeiros);
            }
            return ListaBarbeiros;
        }

        public List<BarbeiroModel> BuscarBarbeiroPorNome(string nome)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            conexao.Open();

            List<BarbeiroModel> ListaBarbeiros = [];

            cmd.CommandText = "SELECT IDCLIENTE,NOME,CPF,EMAIL,TELEFONE FROM BARBEIROS WHERE NOME LIKE @NOME";
            cmd.Parameters.CreateParameter(cmd, @"NOME",$"%{nome}%");

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                BarbeiroModel barbeiros = new()
                {
                    IdBarbeiro = reader.GetInt("BARBEIRO"),
                    Nome = reader.GetString("NOME"),
                    Cpf = reader.GetString("CPF"),
                    Email = reader.GetString("EMAIL"),
                    Telefone = reader.GetString("TELEFONE")
                };
                ListaBarbeiros.Add(barbeiros);
            }
            return ListaBarbeiros;
        }
    }
}
