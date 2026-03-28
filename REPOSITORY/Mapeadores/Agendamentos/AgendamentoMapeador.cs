using System.Data.Common;
using DOMAIN.Models.Agendamentos;
using DOMAIN.Models.Horarios;
using DOMAIN.MODELS.BARBEIROS;
using DOMAIN.MODELS.CLIENTES;
using DOMAIN.MODELS.SERVICOS;
using REPOSITORY.DATA;
using REPOSITORY.UTILS;

namespace REPOSITORY.Mapeadores.Agendamentos
{
    public class AgendamentoMapeador : IAgendamentoMapeador
    {
        public void Cadastrar(AgendamentoModel agendamento)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"INSERT INTO Agendamento (IdBarbeiro, IdCliente, IdServico, IdHorario, DataAgendamento, AgendamentoRealizado)
                                VALUES (@IdBarbeiro, @IdCliente, @IdServico, @IdHorario, @DataAgendamento, @AgendamentoRealizado)";

            cmd.Parameters.CreateParameter(cmd, @"IdBarbeiro", agendamento.IdBarbeiro);
            cmd.Parameters.CreateParameter(cmd, @"IdCliente", agendamento.IdCliente);
            cmd.Parameters.CreateParameter(cmd, @"IdServico", agendamento.IdServico);
            cmd.Parameters.CreateParameter(cmd, @"IdHorario", agendamento.IdHorario);
            cmd.Parameters.CreateParameter(cmd, @"DataAgendamento", agendamento.DataAgendamento);
            cmd.Parameters.CreateParameter(cmd, @"AgendamentoRealizado", agendamento.AgendamentoRealizado);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Atualizar(AgendamentoModel item)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"UPDATE Agendamento
                                SET IdBarbeiro = @IdBarbeiro,
                                    IdCliente = @IdCliente,
                                    IdServico = @IdServico,
                                    IdHorario = @IdHorario,
                                    DataAgendamento = @DataAgendamento,
                                    AgendamentoRealizado = @AgendamentoRealizado
                                WHERE IdAgendamento = @IdAgendamento";

            cmd.Parameters.CreateParameter(cmd, @"IdBarbeiro", item.IdBarbeiro);
            cmd.Parameters.CreateParameter(cmd, @"IdCliente", item.IdCliente);
            cmd.Parameters.CreateParameter(cmd, @"IdServico", item.IdServico);
            cmd.Parameters.CreateParameter(cmd, @"IdHorario", item.IdHorario);
            cmd.Parameters.CreateParameter(cmd, @"DataAgendamento", item.DataAgendamento);
            cmd.Parameters.CreateParameter(cmd, @"AgendamentoRealizado", item.AgendamentoRealizado);
            cmd.Parameters.CreateParameter(cmd, @"IdAgendamento", item.IdAgendamento);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }
        public void Excluir(AgendamentoModel item)
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            cmd.CommandText = @"DELETE FROM Agendamento WHERE IdAgendamento = @IdAgendamento";
            cmd.Parameters.CreateParameter(cmd, @"IdAgendamento", item.IdAgendamento);

            conexao.Open();
            cmd.ExecuteNonQuery();
        }

        public List<AgendamentoModel> Listar()
        {
            using DbConnection conexao = DBHelper.Instancia.CrieConexao();
            using DbCommand cmd = conexao.CreateCommand();

            List<AgendamentoModel> agendamentos = new List<AgendamentoModel>();
            conexao.Open();

            cmd.CommandText = @"
    SELECT 
        A.IDAGENDAMENTO,
        A.DATAAGENDAMENTO,
        B.NOME AS NOME_BARBEIRO, 
        C.NOME AS NOME_CLIENTE, 
        C.CPF, 
        S.NOME AS NOME_SERVICO,
        S.VALOR AS VALOR_SERVICO,
        H.HORARIOINICIO, 
        H.HORARIOFIM 
    FROM AGENDAMENTOS A
    INNER JOIN BARBEIROS B ON A.IDBARBEIRO = B.IDBARBEIRO 
    INNER JOIN CLIENTES C ON A.IDCLIENTE = C.IDCLIENTE 
    INNER JOIN SERVICOS S ON A.IDSERVICO = S.IDSERVICO 
    INNER JOIN HORARIOS H ON A.IDHORARIO = H.IDHORARIO";

            DbDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                AgendamentoModel agendamento = new()
                {
                    IdAgendamento = reader.GetInt("IDAGENDAMENTO"),
                    DataAgendamento = reader.GetDateOnly("DATAAGENDAMENTO"),
                    Barbeiros = new BarbeiroModel
                    {
                        Nome = reader.GetString("NOME_BARBEIRO")
                    },
                    Clientes = new ClienteModel
                    {
                        Nome = reader.GetString("NOME_CLIENTE"),
                        Cpf = reader.GetString("CPF")
                    },
                    Servicos = new ServicoModel
                    {
                        Nome = reader.GetString("NOME_SERVICO"),
                        Valor = reader.GetDecimal("VALOR_SERVICO")

                    },
                    Horarios = new HorarioModel
                    {
                        HorarioInicio = reader.GetTimeSpan("HORARIOINICIO"),
                        HorarioFim = reader.GetTimeSpan("HORARIOFIM")
                    }
                };
                agendamentos.Add(agendamento);
            }
            return agendamentos;
        }
    }
}
