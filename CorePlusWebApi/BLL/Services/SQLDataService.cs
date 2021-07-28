using CWExercise.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CWExerciseApi.BLL.Services
{
    internal class SQLDataService : IDataReadService
    {
        private readonly string _connectionString = "Server=sqlconnectortest.database.windows.net;Database=sqlconnectortest;User Id=sqladmin;Password=password123#;Encrypt=true;TrustServerCertificate=True;";
        public async Task<int> Create(Product product)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "INSERT INTO [dbo].[Product] (Name,Price,Type,Active) VALUES (@name,@price,@type, @active)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@type", (int)product.Type);
                    command.Parameters.AddWithValue("@active", product.Active);

                    connection.Open();
                    int result = await command.ExecuteNonQueryAsync();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");

                    return result;
                }
            }
        }

        public async Task<int> Update(int productID, Product product)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "UPDATE [dbo].[Product] SET Name = @name,  Price = @price,  Type = @type,  Active = @active WHERE ProductID = @productID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@type", (int)product.Type);
                    command.Parameters.AddWithValue("@active", product.Active);
                    command.Parameters.AddWithValue("@productID", productID);

                    connection.Open();
                    int result = await command.ExecuteNonQueryAsync();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error updating into Database!");

                    return result;
                }
            }
        }

        public async Task<int> Delete(int productID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "DELETE FROM [dbo].[Product] WHERE ProductID = @productID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productID", productID);

                    connection.Open();
                    int result = await command.ExecuteNonQueryAsync();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error deleting product from Database!");

                    return result;
                }
            }
        }

        public async Task<List<Product>> GetAll()
        {
            var products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "Select * FROM [dbo].[Product]";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var product = new Product();
                            product.Name = reader["name"].ToString();
                            product.Price = (decimal)reader["price"];
                            product.Type = (ProductTypeEnum)reader["type"];
                            product.Active = (bool)reader["active"];
                            products.Add(product);

                        }
                    }
                }
            }

            return products;
        }

        public async Task<Product> Get(int productID)
        {
            var product = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                String query = "Select * FROM [dbo].[Product]  WHERE ProductID = @productID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productID", productID);
                    connection.Open();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            product.Name = reader["name"].ToString();
                            product.Price = (decimal)reader["price"];
                            product.Type = (ProductTypeEnum)reader["type"];
                            product.Active = (bool)reader["active"];

                        }
                    }
                }
            }

            return product;
        }
    }
}
