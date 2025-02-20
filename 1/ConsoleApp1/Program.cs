using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        static void PrintAllContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts"; 
            SqlCommand cmd = new SqlCommand(query,connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                int contactID = (int)reader["ContactID"];
                string firstName = (string)reader["FirstName"];
                string lastName = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];

                Console.WriteLine($"Contact ID: {contactID}");
                Console.WriteLine($"Name: {firstName} {lastName}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Country ID: {countryID}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();


                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
       public static void Main()
        {
        PrintAllContacts();
        Console.ReadKey();
        }
    }

