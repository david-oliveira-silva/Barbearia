using System.Data.Common;
using FirebirdSql.Data.FirebirdClient;

namespace REPOSITORY.DATA
{
    public class DBHelper
    {
        private static DBHelper? _instancia;
        private readonly string _connectionString;

        private DBHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public static void Inicializar(string connectionString)
        {
            if (_instancia == null)
                _instancia = new DBHelper(connectionString);
        }
        public static DBHelper Instancia
        {
            get
            {
                if (_instancia == null)
                    throw new Exception("DBHelper não inicializado!");
                return _instancia;
            }
        }

        public DbConnection CrieConexao()
        {
            return new FbConnection(_connectionString);
        }
    }
}
