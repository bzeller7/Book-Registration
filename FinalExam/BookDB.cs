using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    static class BookDB
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
        public static List<Book> GetAllBooks()
        {
            //Step 1: Get connection to DB
            SqlConnection con = GetConnection();

            //Step 2: Prepare query
            SqlCommand selCmd = new SqlCommand();

            selCmd.Connection = con;
            selCmd.CommandText = "SELECT ISBN" +
                              " , Price" +
                             " ,Title" +
                             " FROM Book";



            //Step 3: Open Connection
            con.Open();

            //Step 4: Execute query
            SqlDataReader rdr = selCmd.ExecuteReader();

            //Step 5: Do something with result
            List<Book> books = new List<Book>();
            while (rdr.Read())
            {
                Book temp = new Book
                {
                    ISBN = (string)rdr["ISBN"],
                    Title = (string)rdr["Title"]
                };
                books.Add(temp);
            }




            //Step 6: Close connection
            //con.Close();
            con.Dispose(); //will also close connection

            return books;

        }
        public static void AddBook(Book book)
        {
            SqlConnection con = GetConnection();

            SqlCommand insertCmd = new SqlCommand();
            insertCmd.Connection = con;
            insertCmd.CommandText =
                "INSERT INTO Book(ISBN, Price, Title)" +
                " VALUES(@ISBN, @Price, @Title)";
            insertCmd.Parameters.AddWithValue("@ISBN", book.ISBN);
            insertCmd.Parameters.AddWithValue("@Price", book.Price);
            insertCmd.Parameters.AddWithValue("@Title", book.Title);
            
            //open connection
            con.Open();

            int rows = insertCmd.ExecuteNonQuery();

            if (rows == 1)
            {
                //row was inserted successfully
            }
        }

        public static bool DeleteBook(string Title)
        {
            SqlConnection con = GetConnection();

            SqlCommand delCmd = new SqlCommand();
            delCmd.Connection = con;
            delCmd.CommandText = "DELETE FROM Book" +
                " WHERE Title = @Title";
            delCmd.Parameters.AddWithValue("@Title", Title);
            try
            {
                con.Open();
                int rows = delCmd.ExecuteNonQuery();
                if (rows == 1) //one book was deleted
                {
                    return true;
                }
                else //no book was deleted
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
