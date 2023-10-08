using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;
using DataConnectivity.Domain;

namespace DataConnectivity.TechService
{
    internal class TestProgram
    {
        #region AddProgram
        public bool AddProgram(string? programCode, string? description)
        {
            if (string.IsNullOrEmpty(programCode))
            {
                programCode = null;
            }
            if (string.IsNullOrEmpty(description))
            {
                description = null;
            }

            using (SqlConnection conn = new SqlConnection(TestStudents.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddProgram", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        command.Parameters.AddWithValue("@ProgramCode", programCode);
                        command.Parameters.AddWithValue("@Description", description);
                        command.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error-Occurreed - {ex.Message}");
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

        #region GetProgram
        public List<ProgramTest> GetProgram(string programCode)
        {
            /*TestStudent students = new TestStudent();*/
            ProgramTest enrollStudents = new ProgramTest();
            TestStudents students = new TestStudents();
            List<ProgramTest> activeProgram = new List<ProgramTest>();

            using (SqlConnection conn = new SqlConnection(TestStudents.connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetProgram", conn))
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

                                string s = "";
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {

                                        enrollStudents.ProgramCode = reader[0].ToString();
                                        enrollStudents.Description = reader[1].ToString();

                                        Console.Write($"{reader[i]}\t\t");
                                        
                                    }

                                }
                                Console.WriteLine();
                                activeProgram = students.GetStudents(enrollStudents.ProgramCode);

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
         


            return activeProgram;

        }

        #endregion
    }
}
