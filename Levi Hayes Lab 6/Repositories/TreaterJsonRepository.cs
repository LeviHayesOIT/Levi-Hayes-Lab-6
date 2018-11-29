using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public class TreaterJsonRepository : ITreaterRepository
    {
        public string GetConnectionString()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Treaters.json");
        }

        public void Delete(int TreaterID)
        {
            List<Treater> treaterList = GetList();
            treaterList.RemoveAll(m => m.id == TreaterID);
        }

        public List<Treater> GetList()
        {
            List<Treater> treaterList = new List<Treater>();
            
            using (StreamReader r = new StreamReader(GetConnectionString()))
            {
                string json = r.ReadToEnd();
                treaterList = JsonConvert.DeserializeObject<List<Treater>>(json);
            }

            return treaterList;
        }

        public void Insert(Treater treater)
        {
            List<Treater> treaterList = GetList();
            treaterList.Add(treater);
            WriteList(treaterList);
        }

        private void WriteList(List<Treater> treaters)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(GetConnectionString()))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, treaters);
            }
        }
    }
}
