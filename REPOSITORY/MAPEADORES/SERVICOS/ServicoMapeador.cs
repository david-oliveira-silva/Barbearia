using System.Data.Common;
using DOMAIN.MODELS.SERVICOS;
using REPOSITORY.DATA;
using REPOSITORY.UTILS;

namespace REPOSITORY.MAPEADORES.SERVICOS
{
    public class ServicoMapeador : IServicoMapeador
    {
        public void Cadastrar(ServicoModel servico)
        {
            DbConnection conexao = DBHelper.Instancia.CrieConexao();
            DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "INSERT INTO SERVICOS(NOME,VALOR,TEMPOMEDIO) VALUES (@NOME,@VALOR,@TEMPOMEDIO)";
            cmd.Parameters.CreateParameter(cmd, @"NOME", servico.Nome);
            cmd.Parameters.CreateParameter(cmd, @"VALOR", servico.Valor);
            cmd.Parameters.CreateParameter(cmd, @"TEMPOMEDIO", servico.TempoMedio);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Atualizar(ServicoModel servico)
        {
            DbConnection conexao = DBHelper.Instancia.CrieConexao();
            DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "UPDATE SERVICOS SET NOME = @NOME,VALOR = @VALOR,TEMPOMEDIO = @TEMPOMEDIO WHERE IDSERVICO = @IDSERVICO";
            cmd.Parameters.CreateParameter(cmd, @"IDSERVICO", servico.IdServico);
            cmd.Parameters.CreateParameter(cmd, @"NOME", servico.Nome);
            cmd.Parameters.CreateParameter(cmd, @"VALOR", servico.Valor);
            cmd.Parameters.CreateParameter(cmd, @"TEMPOMEDIO", servico.TempoMedio);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Excluir(ServicoModel servico)
        {
            DbConnection conexao = DBHelper.Instancia.CrieConexao();
            DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = "DELETE FROM SERVICOS WHERE IDSERVICO = @IDSERVICO";
            cmd.Parameters.CreateParameter(cmd, @"IDSERVICO", servico.IdServico);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public List<ServicoModel> Listar()
        {
            DbConnection conexao = DBHelper.Instancia.CrieConexao();
            DbCommand cmd = conexao.CreateCommand();
            conexao.Open();

            List<ServicoModel> listaServicos = [];

            DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ServicoModel servico = new()
                {
                    IdServico = reader.GetInt("IDSERVICO"),
                    Nome = reader.GetString("NOME"),
                    Valor = reader.GetDecimal("VALOR"),
                    TempoMedio = reader.GetInt("TEMPOMEDIO")
                };
                listaServicos.Add(servico);
            }
            return listaServicos;
        }

        public List<ServicoModel> BuscarServicoPorNome(string nome)
        {
            DbConnection conexao = DBHelper.Instancia.CrieConexao();
            DbCommand cmd = conexao.CreateCommand();

            conexao.Open();

            List<ServicoModel> listaServicos = [];

            DbDataReader reader = cmd.ExecuteReader();

            cmd.CommandText = "SELECT IDSERVICO,NOME,VALOR,TEMPOMEDIO FROM SERVICOS WHERE NOME = @NOME";
            cmd.Parameters.CreateParameter(cmd, @"NOME", $"%{nome}%");

            while (reader.Read())
            {
                ServicoModel servico = new()
                {
                    IdServico = reader.GetInt("IDSERVICO"),
                    Nome = reader.GetString("NOME"),
                    Valor = reader.GetDecimal("VALOR"),
                    TempoMedio = reader.GetInt("TEMPOMEDIO")
                };
                listaServicos.Add(servico);
            }
            return listaServicos;
        }
    }
}
