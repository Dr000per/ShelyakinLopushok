using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShelyakinLopushok
{
    public class DataBase : IDisposable
    {
        // private string _connectionString = @"Server = db.edu.cchgeu.ru;DataBase = 193_Shelylin;User = 193_Shelylin;Password = 193_Shelylin";
        private string _connectionString = @"Data Source = DESKTOP-BBAJL13\SQLEXPRESS; Initial Catalog = Lopushok; Integrated Security = True";
        public SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        public Boolean OpenConnection()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(sql, _connection);
            table.Load(command.ExecuteReader());

            return table;
        }

        public Boolean ExecuteNonQuery(string sql)
        {
            SqlCommand command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();

            return true;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
