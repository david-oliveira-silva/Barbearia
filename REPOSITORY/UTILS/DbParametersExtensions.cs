using System.Data.Common;

namespace REPOSITORY.UTILS
{
    public static class DbParametersExtensions
    {
        public static void CreateParameter(this DbParameterCollection parameters, DbCommand comamnd, string nome, object? valor)
        {
            if (comamnd != null)
            {
                DbParameter parametro = comamnd.CreateParameter();
                parametro.ParameterName = nome;
                parametro.Value = valor ?? DBNull.Value;
                parameters.Add(parametro);
            }
        }
    }
}
