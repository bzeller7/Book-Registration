using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    static class CustomerDB
    {
        public static SqlConnection GetConnection()
        {
            
            string dbCon = "Data Source=localhost;Initial Catalog=BookRegistration;Integrated Security=True;";
            SqlConnection con = new SqlConnection
            {
                ConnectionString = dbCon
            };
            return con;
        }
        public static List<Customer> GetAllCustomers()
        {
            //Step 1: Get connection to DB
            SqlConnection con = GetConnection();

            //Step 2: Prepare query
            SqlCommand selCmd = new SqlCommand();
            
                selCmd.Connection = con;
            selCmd.CommandText = "SELECT customerID" +
                              " ,Title" +
                              " ,FirstName" +
                             " ,LastName" +
                             " ,DateOfBirth" +
                             " FROM Customer";
            


            //Step 3: Open Connection
            con.Open();

            //Step 4: Execute query
            SqlDataReader rdr = selCmd.ExecuteReader();

            //Step 5: Do something with result
            List<Customer> customers = new List<Customer>();
            while (rdr.Read())
            {
                Customer temp = new Customer();
                temp.CustomerID = (int)rdr["CustomerID"];
                temp.Title = (string)rdr["Title"];
                temp.FirstName = (string)rdr["FirstName"];
                temp.LastName = (string)rdr["LastName"];
                temp.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                customers.Add(temp);
            }

                
            

            //Step 6: Close connection
            //con.Close();
            con.Dispose(); //will also close connection

            return customers;
        }
        public static void AddCustomer(Customer cust)
        {
            SqlConnection con = GetConnection();

            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            insertCmd.CommandText =
                "INSERT INTO Customer(Title, FirstName, LastName, DateOfBirth)" +
                " VALUES(@Title, @FirstName, @LastName, @DateOfBirth)";
            insertCmd.Parameters.AddWithValue("@Title", cust.Title);
            insertCmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
            insertCmd.Parameters.AddWithValue("@LastName", cust.LastName);
            insertCmd.Parameters.AddWithValue("@DateOfBirth", cust.DateOfBirth);

            //open connection
            con.Open();

            int rows = insertCmd.ExecuteNonQuery();

            if (rows == 1)
            {
                //row was inserted successfully
            }

            //This void method will work fine because
            //the insert will work successfully OR
            //some kind of exception will be thrown
        }

        
    }
}
