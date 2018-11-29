using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public class CostumeJsonRepository : ICostumeRepository
    {
        public string GetConnectionString()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Costumes.json");
        }

        public void Delete(int CostumeID)
        {
            List<Costume> costumeList = GetList();
            costumeList.RemoveAll(m => m.id == CostumeID);
            WriteList(costumeList);
        }

        public List<Costume> GetList()
        {
            List<Costume> costumeList = new List<Costume>();

            using (StreamReader r = new StreamReader(GetConnectionString()))
            {
                string json = r.ReadToEnd();
                costumeList = JsonConvert.DeserializeObject<List<Costume>>(json);
            }

            return costumeList;
        }

        public void Insert(Costume costume)
        {
            List<Costume> costumeList = GetList();
            costume.id = (costumeList.Count <= 0) ? 0 : costumeList.Select(m => m.id).Max() + 1;

            costumeList.Add(costume);
            WriteList(costumeList);
        }

        private void WriteList(List<Costume> costumes)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(GetConnectionString()))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, costumes);
            }
        }
    }
}
