using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace Connection

{

    class Program

    {

        static void Main(string[] args)

        {

            string connectionString = "Server=DSCHD-PC-167;tabase=QuestionBank; Integrated Security=True; TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                try

                {

                    string query = "INSERT INTO Admin (Name, Email, Password) VALUES (@Name, @Email, @Password);";

                    using (SqlCommand command = new SqlCommand(query, connection))

                    {

                        command.Parameters.AddWithValue("@Name", "rishab sharma");

                        command.Parameters.AddWithValue("@Email", "rishab23@gmail.com");

                        command.Parameters.AddWithValue("@Password", "1234");

                        connection.Open();

                        int rows = command.ExecuteNonQuery();

                        connection.Close();

                        Console.WriteLine($"{rows} row's Effected");

                    }

                    //string procedureName = "InsertProcedure";

                    //using (SqlCommand command = new SqlCommand(procedureName, connection))

                    //{

                    //    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //    command.Parameters.AddWithValue("@Name", "pankaj sharma");

                    //    command.Parameters.AddWithValue("@Email", "pankaj1157@gmail.com");

                    //    command.Parameters.AddWithValue("@Password", "1234");

                    //    int rows = command.ExecuteNonQuery();

                    //    Console.WriteLine($"{rows} row's Effected");

                    //}

                    //Console.WriteLine("Connection Done");

                    //string procedureName = "UpdateProcedure";

                    //using (SqlCommand command = new SqlCommand(procedureName, connection))

                    //{

                    //    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //    command.Parameters.AddWithValue("@AdminID", "18");

                    //    command.Parameters.AddWithValue("@Name", "pankaj kumar");

                    //    command.Parameters.AddWithValue("@Email", "pankajKumar@gmail.com");

                    //    command.Parameters.AddWithValue("@Password", "1234");

                    //    int rows = command.ExecuteNonQuery();

                    //    Console.WriteLine($"{rows} row's Effected");

                    //}

                    //string procedureName = "DeleteProcedure";

                    //using (SqlCommand command = new SqlCommand(procedureName, connection))

                    //{

                    //    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //    command.Parameters.AddWithValue("@AdminID", "18");

                    //    int rows = command.ExecuteNonQuery();

                    //    Console.WriteLine($"{rows} row's Effected");

                    //}

                    //Console.WriteLine("Connection Done");

                    //string procedureName = "getAdminByID";

                    //using (SqlCommand command = new SqlCommand(procedureName, connection))

                    //{

                    //    command.CommandType = System.Data.CommandType.StoredProcedure;

                    //    command.Parameters.AddWithValue("@AdminID", "13");

                    //    connection.Open();

                    //    SqlDataReader reader = command.ExecuteReader();

                    //    if (reader.HasRows)

                    //    {

                    //        while (reader.Read())

                    //        {

                    //            Console.WriteLine($"AdminID: {reader["AdminID"]}, Name: {reader["Name"]}");

                    //        }

                    //    }

                        //connection.Close();

                    //}

                }

                catch (Exception e)

                {

                    Console.WriteLine("Error " + e.Message);

                }

            }

        }

    }

}

