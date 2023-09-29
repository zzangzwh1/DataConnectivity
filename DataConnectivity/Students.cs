using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataConnectivity
{
    public class Students
    {
        #region AddStudent
        public static bool AddStudent(string? studentId, string? firstName, string? lastName, string? email, string? programCode)
        {
            if (studentId == "")
                studentId = null;
            if (firstName == "")
                firstName = null;
            if (lastName == "")
                lastName = null;
            if (email == "")
                email = null;
            if (programCode == "")
                programCode = null;


            using (SqlConnection connection = new SqlConnection(Programs.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    // AddwithValue not necessary define the valuetype because i will be inserting data through the paramter
                    // however if i decide to you command.parameters.add() then i need to insert value type that matches with the procedure
                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId).Size = 10;
                        command.Parameters.AddWithValue("@FirstName", firstName).Size = 25;
                        command.Parameters.AddWithValue("@LastName", lastName).Size = 25;
                        command.Parameters.AddWithValue("@Email", email).Size = 50;
                        command.Parameters.AddWithValue("@ProgramCode", programCode).Size = 10;

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - {ex.Message}");
                        return false;

                    }
                    finally
                    {
                        connection.Close();
                    }



                }

            }
            return true;
        }
        #endregion

        #region Update Student

        public static bool UpdateStudent(string? studentId, string? firstName, string? lastName, string? email)
        {

            using (SqlConnection conn = new SqlConnection(Programs.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UpdateStudent", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", studentId).Size = 10;
                        command.Parameters.AddWithValue("@FirstName", firstName).Size = 25;
                        command.Parameters.AddWithValue("@LastName", lastName).Size = 25;

                        command.Parameters.AddWithValue("@Email", email).Size = 50;
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
            }
            return true;
        }
        #endregion

        #region DeleteStudent
        public static bool DeleteStudent(string? studentId)
        {
            if (studentId == "")
                studentId = null;

            using (SqlConnection conn = new SqlConnection(Programs.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DeleteStudent", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", studentId).Size = 10;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                        return false;

                    }
                    finally
                    {
                        conn.Close();
                    }



                }
            }
            return true;
        }

        #endregion

        #region FindStudent
        public static string GetStudent(string? studentID)
        {
            if (studentID == "")
                studentID = null;

            StringBuilder strings = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(Programs.connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        command.Parameters.AddWithValue("@StudentID", studentID).Size = 10;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    //if condition added so result output present equally
                                    if (i == reader.FieldCount - 2)
                                    {
                                        Console.Write($"{reader.GetName(i)}\t\t\t");
                                    }
                                    else
                                    {

                                        Console.Write($"{reader.GetName(i)}\t");
                                    }
                                }
                                Console.WriteLine();
                                while (reader.Read())
                                {

                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (string.IsNullOrEmpty(reader[i].ToString()))
                                        {
                                            strings.Append("NULL\t");
                                        }
                                        strings.Append(reader[i].ToString());
                                        strings.Append("\t\t");

                                    }
                                }

                            }
                            else
                            {
                                Console.WriteLine("Students are not exists try other studentID");
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred {ex.Message}");
                    }
                    finally
                    {
                        connection.Close();
                    }



                }
            }
            return strings.ToString();
        }
        #endregion

        #region GetStudentsByProgram
        public static void GetStudentsByProgram(string? programCode)
        {
            if (string.IsNullOrEmpty(programCode))
            {
                programCode = null;
            }
            StringBuilder sBuilder = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(Programs.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetStudentsByProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProgramCode", programCode);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.FieldCount - 2 == i)
                                    {
                                        Console.Write($"{reader.GetName(i)} \t\t\t");
                                    }
                                    else
                                    {

                                        Console.Write($"{reader.GetName(i)} \t");
                                    }


                                }
                                Console.WriteLine("");
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        //list.Add(reader[i].ToString());
                                        if (string.IsNullOrEmpty(reader[i].ToString()))
                                        {
                                            Console.Write($"NULL\t\t\t");
                                        }
                                        else
                                        {
                                            Console.Write($"{reader[i]}\t\t");
                                        }
                                    }

                                    Console.WriteLine();
                                }
                            }

                            else
                            {
                                Console.WriteLine($"GetStudentsByProgram Not Exits!  - No Data Found!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }



                }
            }
        }


    }
}
    #endregion






