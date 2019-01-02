using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    class BookRegistrationDB
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
        public static List<BookRegistration> GetRegistration()
        {
            //Step 1: Get connection to DB
            SqlConnection con = GetConnection();

            //Step 2: Prepare query
            SqlCommand selCmd = new SqlCommand();

            selCmd.Connection = con;
            selCmd.CommandText = "SELECT CustomerID" +
                             ", ISBN"+
                             " ,RegDate" +
                             " FROM Registration";



            //Step 3: Open Connection
            con.Open();

            //Step 4: Execute query
            SqlDataReader rdr = selCmd.ExecuteReader();

            //Step 5: Do something with result
            List<BookRegistration> registrations = new List<BookRegistration>();
            while (rdr.Read())
            {
                BookRegistration temp = new BookRegistration
                {
                    CustomerID = (int)rdr["CustomerID"],
                    ISBN = (string)rdr["ISBN"],
                    RegDate = (DateTime)rdr["RegDate"]
                };
                registrations.Add(temp);
                
            }




            //Step 6: Close connection
            //con.Close();
            con.Dispose(); //will also close connection

            return registrations;
        }

        public static bool Registration(BookRegistration Reg)
        {
            SqlConnection con = GetConnection();

            
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            insertCmd.CommandText =
                "INSERT INTO Registration(CustomerID, ISBN, RegDate)" +
                " VALUES(@CustomerID, @ISBN, @RegDate)";
            insertCmd.Parameters.AddWithValue("@CustomerID", Reg.CustomerID);
            insertCmd.Parameters.AddWithValue("@ISBN", Reg.ISBN);
            insertCmd.Parameters.AddWithValue("@RegDate", Reg.RegDate);

            try
            {
                con.Open();
                int rows = insertCmd.ExecuteNonQuery();
                if (rows == 1) 
                {
                    return true;
                }
                else 
                {

                    return false;
                }
            }
            catch (SqlException)
            {

                //SqlExpection will be thrown if
                //DB is not available or DB is too busy
                return false;
            }
            finally //Finally ALWAYS executes
            {
                //close connection
                con.Dispose();
            }
        }

    }
}
