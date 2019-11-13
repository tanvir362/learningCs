using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWithDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn = "Server = DESKTOP-1MF09JL; Database = Marketing; User Id = C#Aplication; Password = abc;";
            DatabaseOperation databaseOperation = new DatabaseOperation(conn);
            string insertQurey = "Insert into Subscription([Name]) values('Post notification');";
            string selectQuery = "select * from Subscription;";
            //databaseOperation.ExecuteDDLQuery(insertQurey);
            var data = databaseOperation.GetData(selectQuery);
            int flg = 0;
            foreach (var row in data)
            {
                string rw = "";
                string ky = "";
                foreach(var item in row)
                {
                    rw += item.Value.ToString() + "    ";
                    if(flg == 0) ky += item.Key.ToString() + "    ";
                }
                if (flg == 0)
                {
                    Console.WriteLine(ky);
                    flg = 1;
                }
                Console.WriteLine(rw);
            }


            Console.ReadKey();
        }
    }
}
