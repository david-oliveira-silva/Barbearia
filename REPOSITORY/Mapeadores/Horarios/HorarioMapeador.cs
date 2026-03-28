using System.Data.Common;
using DOMAIN.Enuns.Horario;
using DOMAIN.Models.Horarios;
using DOMAIN.MODELS.BARBEIROS;
using DOMAIN.MODELS.SERVICOS;
using REPOSITORY.DATA;
using REPOSITORY.UTILS;

namespace REPOSITORY.Mapeadores.Horarios
{
    public class HorarioMapeador : IHorarioMapeador
    {
        public void Cadastrar(HorarioModel horario)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"INSERT INTO HORARIOS(IDBARBEIRO,DIASEMANA,HORARIOINICIO,HORARIOFIM,ATIVO) VALUES (@IDBARBEIRO,@DIASEMANA,@HORARIOINICIO,@HORARIOFIM,@ATIVO)";

            cmd.Parameters.CreateParameter(cmd, @"IDBARBEIRO", horario.IdBarbeiro);
            cmd.Parameters.CreateParameter(cmd, @"DIASEMANA", horario.DiaSemana);
            cmd.Parameters.CreateParameter(cmd, "@HORARIOINICIO", horario.HorarioInicio);
            cmd.Parameters.CreateParameter(cmd, "@HORARIOFIM", horario.HorarioFim);
            cmd.Parameters.CreateParameter(cmd, @"ATIVO", horario.Ativo);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Atualizar(HorarioModel horario)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"UPDATE HORARIOS SET IDBARBEIRO = @IDBARBEIRO, DIASEMANA = @DIASEMANA, HORARIOINICIO = @HORARIOINICIO, HORARIOFIM = @HORARIOFIM, ATIVO = @ATIVO WHERE IDHORARIO = @IDHORARIO";

            cmd.Parameters.CreateParameter(cmd, @"IDHORARIO", horario.IdHorario);
            cmd.Parameters.CreateParameter(cmd, @"IDBARBEIRO", horario.IdBarbeiro);
            cmd.Parameters.CreateParameter(cmd, @"DIASEMANA", horario.DiaSemana);
            cmd.Parameters.CreateParameter(cmd, @"HORARIOINICIO", horario.HorarioInicio);
            cmd.Parameters.CreateParameter(cmd, @"HORARIOFIM", horario.HorarioFim);
            cmd.Parameters.CreateParameter(cmd, @"ATIVO", horario.Ativo);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public void Excluir(HorarioModel horario)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"DELETE FROM HORARIOS WHERE IDHORARIO = @IDHORARIO ";

            cmd.Parameters.CreateParameter(cmd, @"IDHORARIO", horario.IdHorario);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public List<HorarioModel> Listar()
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            List<HorarioModel> horarios = [];

            cmd.CommandText = @"
            SELECT B.NOME,B.IDBARBEIRO,H.IDHORARIO,H.DIASEMANA,H.HORARIOINICIO,H.HORARIOFIM,H.ATIVO 
            FROM HORARIOS H 
            INNER JOIN BARBEIROS B
            ON H.IDBARBEIRO  = B.IDBARBEIRO ";

            conexao.Open();
            DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                HorarioModel horario = new()
                {
                    IdHorario = reader.GetInt("IDHORARIO"),
                    IdBarbeiro = reader.GetInt("IDBARBEIRO"),
                    DiaSemana = reader.GetDiaSemana("DIASEMANA"),
                    HorarioInicio = reader.GetTimeSpan("HORARIOINICIO"),
                    HorarioFim = reader.GetTimeSpan("HORARIOFIM"),
                    Ativo = (Ativo)reader.GetInt("ATIVO"),
                    Barbeiros = new BarbeiroModel
                    {
                        IdBarbeiro = reader.GetInt("IDBARBEIRO"),
                        Nome = reader.GetString("NOME")
                    }
                };
                horarios.Add(horario);
            }
            return horarios;
        }
    }
}
