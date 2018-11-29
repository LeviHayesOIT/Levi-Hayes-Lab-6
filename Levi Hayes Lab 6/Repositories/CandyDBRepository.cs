using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Levi_Hayes_Lab_6.Repositories
{
    
    public class CandyDBRepository : ICandyRepository
    {
        private CandySettings _Settings;
        public CandyDBRepository(IOptions<CandySettings> candyConfig)
        {
            _Settings = candyConfig.Value;
        }
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_Settings.DatabaseConfigFile, optional: false, reloadOnChange: true);


            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");

        }

        public List<Candy> GetList()
        {
            List<Candy> candyList = new List<Candy>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Candy candy = new Candy();
                            candy.id = (int) reader["Id"];
                            candy.productName = reader["ProductName"].ToString();
                            candyList.Add(candy);
                        }
                    }
                }

            }
            return candyList;
        }

        public void Insert(Candy candy)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    
                    command.Parameters.AddWithValue("@ProductName", candy.productName);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int candyID)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Candy_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", candyID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
