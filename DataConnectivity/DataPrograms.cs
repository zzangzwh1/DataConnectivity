using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataConnectivity
{
    public class DataPrograms
    {
        public static string connectionString = @"Persist Security Info=False; Server= dev1.baist.ca; Database=wcho2; User ID=wcho2; Password=Whdnjsgur1!;";

        /*
         Used using Statement
           because using statement implement IDisposable interface
           which it manage database connection and help automatically dispose when its out of scope
           it also helps prevent resource leaking. 
           connection will be automatically dispose so i believe connection.close() is not necessary
           but i added so it looks more clear
        */
        #region Demonstration AddProgram
        public static bool AddProgram(string programCode, string description)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("AddProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ProgramCode", programCode).Size = 10;
                        command.Parameters.AddWithValue("@Description", description).Size = 60;
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred In @AddProgram : {ex.Message}");
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

        public static void GetProgram(string programCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetProgram", conn))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProgramCode", programCode).Size=10;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)}\t");
                                }
                                Console.WriteLine();

                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                      
                                        Console.Write($"{reader[i]}\t\t");
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

        }

        #endregion


    }
}
