using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSQL_to_Azure_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            string SelectAllStudent = "SELECT * FROM Student";
            string conn =
                "Server=tcp:hotelserver01.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID=sailor;Password=ZAQ12wsx;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (SqlConnection databasesConnection = new SqlConnection(conn)) 
            {
                SqlCommand command = new SqlCommand(SelectAllStudent, databasesConnection);

                databasesConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader.GetInt32(0)} + {reader.GetString(1)} + {reader.GetString(2)}"); 
                    }
                }
                Console.Read();
                reader.Close();
            }
        }
    }
}
