﻿using System;
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
        public bool AddStudent(TestStudent acceptedStudent, string? programCode)
        {
            if (string.IsNullOrEmpty(acceptedStudent.StudentId))
                acceptedStudent.StudentId = null;
            if (string.IsNullOrEmpty(acceptedStudent.FirstName))
                acceptedStudent.FirstName = null;
            if (string.IsNullOrEmpty(acceptedStudent.lastName))
                acceptedStudent.lastName = null;
            if (string.IsNullOrEmpty(acceptedStudent.Email))
                acceptedStudent.Email = null;
            if (string.IsNullOrEmpty(programCode))
                programCode = null;

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

        #region GetStudent
        public ProgramTest GetStudent(string? studentId)
        {
            if (studentId == string.Empty)
                studentId = null;

        //    StringBuilder enrolledStudent = new StringBuilder();
            ProgramTest enrollStudent = new ProgramTest();
            TestStudent student = new TestStudent();
            string columnValue = "";

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
                                    string? programCodes = "";
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        columnValue = reader[i].ToString();
                                        if (reader[i] == DBNull.Value || reader[i].ToString() == string.Empty)
                                        {
                                       
                                            columnValue = "NULL";
                                        }
                                      
                                        switch (i)
                                        {
                                            case 0:
                                                student.StudentId = columnValue;
                                                break;
                                            case 1:
                                                student.FirstName = columnValue;
                                                break;
                                            case 2:
                                                student.lastName = columnValue;
                                                break;
                                            case 3:
                                                student.Email = columnValue;
                                                break;
                                            case 4:
                                                programCodes = columnValue;
                                                break;

                                        }

                                    }
                                    string s = "";
                                    enrollStudent = new ProgramTest(student);
                                    enrollStudent.ProgramCode = programCodes;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"There are No Student exists with that student ID try other Student ID");
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
            return enrollStudent;
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
            TestStudent studentsInfo = new TestStudent();
            ProgramTest enrollStudent = new ProgramTest();

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
                                    if (reader.FieldCount-2 == i)
                                        Console.Write($"{reader.GetName(i)}\t\t\t\t");
                                    else
                                    Console.Write($"{reader.GetName(i)}\t\t");
                                }
                                Console.WriteLine();

                                while (reader.Read())
                                {
                                    studentsInfo = new TestStudent(); // Create a new object for each row
                                    string programCodes = string.Empty;
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {

                                        string columnValue = reader[i].ToString();
                                        //string result =

                                        // Check if the value is DBNull.Value or an empty string, and replace it with "NULL"
                                        if (DBNull.Value.Equals(reader[i]) || string.IsNullOrEmpty(columnValue))
                                        {
                                            columnValue = "NULL\t";
                                        }

                                        // Depending on the column index, assign the values to the properties of studentsInfo
                                        switch (i)
                                        {
                                            case 0:
                                                studentsInfo.StudentId = columnValue;
                                                break;
                                            case 1:
                                                studentsInfo.FirstName = columnValue;
                                                break;
                                            case 2:
                                                studentsInfo.lastName = columnValue;
                                                break;
                                            case 3:
                                                studentsInfo.Email = columnValue;
                                                break;
                                            case 4:
                                                programCodes = columnValue;
                                                break;

                                        }

                                    }
                                    enrollStudent = new ProgramTest(studentsInfo);
                                    enrollStudent.ProgramCode = programCodes;
                                    activeProgramAndStudents.Add(enrollStudent);


                                    //  activeProgramAndStudents.Add


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

            return activeProgramAndStudents;



        }

        #endregion


    }





}
