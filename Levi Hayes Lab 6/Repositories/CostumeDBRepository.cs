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
    public class CostumeDBRepository : ICostumeRepository
    {
        private CostumeSettings _Settings;
        public CostumeDBRepository(IOptions<CostumeSettings> costumeConfig)
        {
            _Settings = costumeConfig.Value;
        }
        public string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(_Settings.DatabaseConfigFile, optional: false, reloadOnChange: true);


            var configuration = builder.Build();

            return configuration.GetConnectionString("DB_Halloween");

        }

        public List<Costume> GetList()
        {
            List<Costume> costumeList = new List<Costume>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_GetList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Costume costume = new Costume();
                            costume.id = (int)reader["Id"];
                            costume.costume = reader["Costume"].ToString();
                            costumeList.Add(costume);
                        }
                    }
                }

            }
            return costumeList;
        }

        public void Insert(Costume costume)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Costume", costume.costume);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int costumeID)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("Costumes_Delete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    command.Parameters.AddWithValue("@Id", costumeID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
