using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public class CandyJsonRepository : ICandyRepository
    {
        public string GetConnectionString()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Candy.json");
        }

        public void Delete(int CandyID)
        {
            List<Candy> candyList = GetList();
            candyList.RemoveAll(m => m.id == CandyID);
        }

        public List<Candy> GetList()
        {
            List<Candy> candyList = new List<Candy>();

            using (StreamReader r = new StreamReader(GetConnectionString()))
            {
                string json = r.ReadToEnd();
                candyList = JsonConvert.DeserializeObject<List<Candy>>(json);
            }

            return candyList;
        }

        public void Insert(Candy candy)
        {
            List<Candy> candyList = GetList();
            candyList.Add(candy);
            WriteList(candyList);
        }

        private void WriteList(List<Candy> candies)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(GetConnectionString()))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, candies);
            }
        }
    }
}
