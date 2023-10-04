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
    public class NorthWind
    {
        private static string connectionString = @"Persist Security Info= False;  Server=dev1.baist.ca; Database=Northwind; User ID=wcho2;password=Whdnjsgur1! ";

        #region North Wind GetCustomersByCountry
        public static void GetCustomersByCountry(string? country)
        {
            if (string.IsNullOrEmpty(country))
                country = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetCustomersByCountry", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {

                        command.Parameters.AddWithValue("@Country", country).Size = 30;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Country Columns : ");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)};");
                                }
                                Console.WriteLine("");
                                Console.WriteLine("---------------");
                                Console.WriteLine("Country Value : ");
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        //db null
                                        if (reader[i] == DBNull.Value || reader[i].ToString() == "")
                                        {
                                            Console.Write("N/A;");
                                        }
                                        else
                                        {
                                            Console.Write($"{reader[i]};");

                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Country is not exists! Try another Country  Name! ");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error  Occurred = {ex.Message}");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }
        #endregion

        #region NorthWind GetCategory

        public static void GetCategory(int categoryId)
        {          

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetCategory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Category Columns : ");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)};");
                                }
                                Console.WriteLine("");
                                Console.WriteLine("-");
                                Console.WriteLine("Category Value : ");
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader[i]};");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Data Not Found! Try Other Category ID");
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

        #endregion

        #region NorthWind wcho2.GetProductsByCategory

        public static void GetProductsByCategory(string? categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
                categoryName = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetProductsByCategory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName).Size = 30;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Product Columns : ");
                                Console.WriteLine();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)};");

                                }
                                Console.WriteLine();
                                Console.WriteLine("-");
                                Console.WriteLine("Product Values : ");
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write($"{reader[i]};");
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Data not Exists!! Try another Category Name  !");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Occurred- {ex.Message}");

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
