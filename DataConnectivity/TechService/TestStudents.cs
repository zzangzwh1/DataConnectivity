using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using DataConnectivity.Domain;

namespace DataConnectivity.TechService
{
    internal class TestStudents
    {
        public static string connectionString = @"Persist Security Info=False; Server=dev1.baist.ca; Database=wcho2; User Id=wcho2; password=Whdnjsgur1!; ";
        #region AddStudent
        public bool AddStudent(Domain.TestStudent acceptedStudent, string programCode)
        {
            bool isSucces = true;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddStudent", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", acceptedStudent.StudentId).Size = 10;
                        command.Parameters.AddWithValue("@FirstName", acceptedStudent.FirstName).Size = 25;
                        command.Parameters.AddWithValue("@LastName", acceptedStudent.lastName).Size = 25;
                        command.Parameters.AddWithValue("@Email", acceptedStudent.Email).Size = 50;
                        command.Parameters.AddWithValue("@ProgramCode", programCode).Size = 10;

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error - Occurred - {ex.Message}");
                        isSucces = false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
            return isSucces;
        }
        #endregion

        #region GetStudent
        public string GetStudent(string? studentId)
        {
            if (studentId == string.Empty)
                studentId = null;

            StringBuilder enrolledStudent = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetStudent", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {


                        command.Parameters.AddWithValue("@StudentID", studentId).Size = 10;

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
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (reader[i] == DBNull.Value || reader[i].ToString() == string.Empty)
                                        {
                                            enrolledStudent.Append("NULL\t");
                                        }
                                        enrolledStudent.Append(reader[i].ToString());
                                        enrolledStudent.Append("\t\t");

                                    }
                                }
                            }
                            else
                            {
                                enrolledStudent.Append($"There are No Student exists with that student ID try other Student ID");
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
            return enrolledStudent.ToString();
        }

        #endregion

        #region UpdateStudent
        public bool UpdateStudent(TestStudent student)
        {
            if (student.StudentId == "")
                student.StudentId = null;
            if (student.FirstName == "")
                student.FirstName = null;
            if (student.lastName == "")
                student.lastName = null;
            if (student.Email == "")
                student.Email = null;


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UpdateStudent", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@StudentID", student.StudentId).Size = 10;
                        command.Parameters.AddWithValue("@FirstName", student.FirstName).Size = 25;
                        command.Parameters.AddWithValue("@LastName", student.lastName).Size = 25;

                        command.Parameters.AddWithValue("@Email", student.Email).Size = 50;
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

        public bool DeleteStudent(string? studentId)
        {
            if (studentId == "")
                studentId = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
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

        #region GetStudents

        public List<ProgramTest> GetStudents(string programCode)
        {
            //   StringBuilder students = new StringBuilder();
          
            List<ProgramTest> activeProgramAndStudents = new List<ProgramTest>();
            TestStudent student = new TestStudent();
            student.StudentId = "";
            //activeProgramAndStudents.Add(student);

            TestStudent studentsInfo = new TestStudent();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetStudentsByProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProgramCode", programCode).Size = 10;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)}\t");
                                }
                                Console.WriteLine();

                                string s2 = "";

                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        ProgramTest enrollStudent = new ProgramTest();
                                        // Initialize the EnrollStudents property
                                     
                                        string result = reader[0].ToString();
                                        enrollStudent.EnrollStudents.StudentId = result;
                                        enrollStudent.EnrollStudents.FirstName = reader[1].ToString();
                                        enrollStudent.EnrollStudents.lastName = reader[2].ToString();

                                        enrollStudent.EnrollStudents.Email = reader[3].ToString();
                                        enrollStudent.ProgramCode = reader[4].ToString();
                                        activeProgramAndStudents.Add(enrollStudent);
                                    }

                                }

                            }
                            else
                            {
                                Console.WriteLine("No data Found.");

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred - GetProgram : {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            string s = "";
            return activeProgramAndStudents;



        }

        #endregion

    }




}
