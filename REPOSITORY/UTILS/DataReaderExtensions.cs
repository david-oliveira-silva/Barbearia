using System.Data.Common;
using DOMAIN.Enuns.Horario;

namespace REPOSITORY.UTILS
{
    public static class DataReaderExtensions
    {
        public static int GetInt(this DbDataReader reader,string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? 0 : reader.GetInt32(ordinal);
        }
        public static string GetString(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
        }

        public static decimal GetDecimal(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? 0 : reader.GetDecimal(ordinal);
        }
        public static double GetDouble(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? 0.0 : reader.GetDouble(ordinal);
        }

        public static bool GetBool(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) || reader.GetBoolean(ordinal);
        }

        public static DiaSemana GetDiaSemana(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? DiaSemana.SEGUNDA : (DiaSemana)reader.GetInt32(ordinal);
        }

        public static TimeSpan GetTimeSpan(this DbDataReader reader, string nomeColuna)
        {
            int ordinal = reader.GetOrdinal(nomeColuna);
            return reader.IsDBNull(ordinal) ? TimeSpan.Zero : reader.GetFieldValue<TimeSpan>(ordinal);
        }
    }
}
