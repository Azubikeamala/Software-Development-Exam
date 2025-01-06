using System;
using System.Data;
using System.Data.SqlClient; 

namespace AAzubikeExam
{
    internal class EmployeeDataHelper
    {
     
        private readonly string connectionString;

        public EmployeeDataHelper()
        {
            connectionString = GetConnectionString();
        }

        private string GetConnectionString()
        {
           
            return "Server=localhost;Database=Northwind;Trusted_Connection=True;";
        }

        
        public DataTable GetAllEmployees()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT EmployeeID, FirstName, LastName, Title, City FROM Employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employees: " + ex.Message);
            }
            return dataTable;
        }

     
        public DataTable SearchEmployees(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT EmployeeID, FirstName, LastName, Title, City 
                                     FROM Employee 
                                     WHERE FirstName LIKE @Name OR LastName LIKE @Name";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Name", $"%{name}%");
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error with searching employees: " + ex.Message);
            }
            return dataTable;
        }
    }
}
