using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using CRUD_Operation.Models;

namespace CRUD_Operation.Data
{   
    public class DataAccessLayer
    {
        private readonly string _connectionString;

        public DataAccessLayer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void InsertCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertCategory", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@DisplayOrder", category.DisplayOrder);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting category: " + ex.Message);
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoryList = new List<Category>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetAllCategories", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Category category = new Category
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            DisplayOrder = Convert.ToInt32(row["DisplayOrder"])
                        };
                        categoryList.Add(category);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching categories: " + ex.Message);
                }
            }
            return categoryList;
        }

        public Category GetCategoryById(int id)
        {
            Category category = null;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetCategoryById", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        category = new Category
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            DisplayOrder = Convert.ToInt32(row["DisplayOrder"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching category by Id: " + ex.Message);
                }
            }
            return category;
        }

        public void UpdateCategory(Category category)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UpdateCategory", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@DisplayOrder", category.DisplayOrder);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating category: " + ex.Message);
                }
            }
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DeleteCategory", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting category: " + ex.Message);
                }
            }
        }
    }
}