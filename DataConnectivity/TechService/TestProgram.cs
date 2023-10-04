using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;

namespace DataConnectivity.TechService
{
    internal class TestProgram
    {
        public bool AddProgram(string programCode, string description)
        {
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
                    catch(Exception ex)
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
    }
}
