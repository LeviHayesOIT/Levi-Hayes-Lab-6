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
    public class TreaterDBRepository : ITreaterRepository
    {
        private TreaterSettings _Settings;
        public TreaterDBRepository(IOptions<TreaterSettings> treaterConfig)
        {
            _Settings = treaterConfig.Value;
        }
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_Settings.DatabaseConfigFile, optional: false, reloadOnChange: true);


            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");

        }

        public List<Treater> GetList()
        {
            List<Treater> treaterList = new List<Treater>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Candy candy = new Candy();
                            candy.id = (int)reader["CandyID"];
                            candy.productName = reader["CandyName"].ToString();
                            Costume costume = new Costume();
                            costume.id = (int)reader["CostumeID"];
                            costume.costume = reader["CostumeName"].ToString();

                            Treater treater = new Treater();
                            treater.id = (int)reader["TreaterID"];
                            treater.name = reader["TreaterName"].ToString();
                            treater.favoriteCandy = candy;
                            treater.costume = costume;
                            treaterList.Add(treater);
                        }
                    }
                }

            }
            return treaterList;
        }

        public void Insert(Treater treater)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Treaters_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Name", treater.name);
                    command.Parameters.AddWithValue("@CandyID", treater.favoriteCandy.id);
                    command.Parameters.AddWithValue("@CostumeID", treater.costume.id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
