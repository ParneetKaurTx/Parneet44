using databaseconnection.DataModel;
using databaseconnection.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace databaseconnection.Repository
{
    public class AdminRepo : IAdminRepo
    {
        string connectionString = "Server=DSCHD-PC-167; Database=QuestionBank; Integrated Security=True; TrustServerCertificate=True;";

        public int Delete(int id)
        {
            int rows = 0;
            string procedureName = "DeleteProcedure";
            using (SqlConnection connection = new SqlConnection(connectionString))



            {
                SqlCommand command = new SqlCommand(procedureName, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", "16");



                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
                rows = command.ExecuteNonQuery();
                connection.Close();


            }

            return rows;

        }

        public List<AdminModel> GetAll()
        {
            string procedureName = "getAll";
            List<AdminModel> adminModelList = new List<AdminModel>();
            using( SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }


                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)

                {

                    while (reader.Read())

                    {

                    adminModelList.Add(new AdminModel
                    {
                        Email = (string)reader["Email"],
                        Id = (int)reader["AdminID"],
                        Name = (string)reader["Name"],
                        Password = (string)reader["Password"]

                    });

                    }

                }
                connection.Close();
            }
            return adminModelList;
        }

        public AdminModel GetById(int id)
        {
            string procedureName = "getitByID";
            AdminModel adminModel = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);


                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();

                }


                connection.Open();

                SqlDataReader reader = command.ExecuteReader();



                if (reader.HasRows)

                {

                    while (reader.Read())

                    {

                        adminModel = new AdminModel
                        {
                            Email = (string)reader["Email"],
                            Id = (int)reader["AdminID"],
                            Name = (string)reader["Name"],
                            Password = (string)reader["Password"]

                        };

                    }


                }
                connection.Close();

            }
            return adminModel;

        }

        public int InsertUser(AdminModel user)
        {
            int rows = 0;
            string procedureName = "InsertProcedure";

                using (SqlConnection connection = new SqlConnection(connectionString))

                {
                SqlCommand command = new SqlCommand(procedureName, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", "pankaj sharma");

                command.Parameters.AddWithValue("@Email", "pankaj17157@gmail.com");

                command.Parameters.AddWithValue("@Password", "1234");


                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }


                connection.Open();
                rows = command.ExecuteNonQuery();
                connection.Close();



            }

            return rows;
        }

        int IAdminRepo.UpdateUser(AdminModel user)
        {
            int rows = 0;

            string procedureName = "UpdateProcedure";
            using (SqlConnection connection = new SqlConnection(connectionString))


            {
                SqlCommand command = new SqlCommand(procedureName, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AdminID", 13);

                command.Parameters.AddWithValue("@Name", "pankaj kumar");

                command.Parameters.AddWithValue("@Email", "pankajKumar@gmail.com");

                command.Parameters.AddWithValue("@Password", "1234");

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

                connection.Open();

                rows = command.ExecuteNonQuery();
                connection.Close();



            }
            return rows;
        }
    }
}







