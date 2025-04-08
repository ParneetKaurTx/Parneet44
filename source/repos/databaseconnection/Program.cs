using System;

using System.Collections.Generic;
using System.Linq;

using System.Text;

using System.Threading.Tasks;
using databaseconnection.DataModel;
using databaseconnection.Repository;
using Microsoft.Data.SqlClient;

namespace Connection

{

    class Program

    {

        static void Main(string[] args)

        {
            

            string connectionString = "Server=DSCHD-PC-167; Database=QuestionBank; Integrated Security=True; TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {






                Console.WriteLine("press '1.' if you want all records");
                Console.WriteLine("press '2.' if you want records by ID");
              
                Console.WriteLine("press '3.' if you want to delete the records");
                
              
            


                while (true)
                {
                    Console.WriteLine("dddd");
                    Console.WriteLine("Enter your respective choice");
                    Console.WriteLine("Enter your respective choice");
                    int Choice = int.Parse(Console.ReadLine());



                    switch (Choice)
                    {
                        case 1:
                            AdminRepo adminRepo = new AdminRepo();
                            var allAdmins = adminRepo.GetAll();


                            foreach (var admins in allAdmins)
                            {
                                Console.WriteLine($"ID is:{admins.Id}, Name is:{admins.Name}, Email is:{admins.Email}, Password is:{admins.Password}");
                            }
                            break;

                        case 2:
                            
                            AdminRepo adminRepo1 = new AdminRepo();
                            Console.WriteLine("Enter Admin ID:");

                            // Try parsing the input safely
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                // If parsing is successful
                                AdminModel admin = adminRepo1.GetById(id);

                                if (admin != null)
                                {
                                    // If the admin exists, print the details
                                    Console.WriteLine($"Admin ID: {admin.Id}, Name: {admin.Name}, Email: {admin.Email}");
                                }
                                else
                                {
                                    // If no admin found, print a message
                                    Console.WriteLine("No admin found with the given ID.");
                                }
                            }
                            else
                            {
                                // If input is not a valid integer
                                Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
                            }
                            break;
                        case 3:
                            AdminRepo adminRepo2 = new AdminRepo();
                            int ID = int.Parse(Console.ReadLine());
                            var admins = adminRepo2.Delete(ID);

                            foreach (var i in admins)
                            {
                                if (i.Id==ID)
                                {
                                    Console.WriteLine($"This id{ID} is found and successfully deleted");





                                }
                                else
                                {
                                    Console.WriteLine($"This id {ID} is not found");
                                }


                            }

                            break;

                        case 0:
                            Console.WriteLine("Your program is successfully terminated");
                            break;

                        default:
                            Console.WriteLine("invalid choice!");
                            break;

                    }

                }

                

            }



          


        }





    }


}

