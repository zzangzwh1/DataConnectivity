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
        public static void GetCustomersByCountry(string country)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetCustomersByCountry", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Country", country);

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
                                    if (reader[i].ToString() == null || reader[i].ToString() == "")
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
                            Console.WriteLine("Country is not exists!");
                        }
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

            }
        }

        #endregion

        #region NorthWind wcho2.GetProductsByCategory

        public static void GetProductsByCategory(string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("wcho2.GetProductsByCategory", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

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
                    }
                }
            }
        }

        #endregion
    }
}
