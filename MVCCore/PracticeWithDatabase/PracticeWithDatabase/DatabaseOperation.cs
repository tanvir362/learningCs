using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWithDatabase
{
    class DatabaseOperation
    {
        private string conn = null;
        public DatabaseOperation(string conn)
        {
            this.conn = conn;
        }

        public void ExecuteDDLQuery(string sql)
        {
            using(var connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection?.Close();
                }

            }
        }
        public List<Dictionary<string, object>> GetData(string sql)
        {
            var dataTable = new List<Dictionary<string, object>>();
            using (var connection = new SqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i< reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader[i];
                                }
                                dataTable.Add(row);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection?.Close();
                }

            }
            return dataTable;
        }
    }
}
