using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public class CostumeJsonRepository : ICostumeRepository
    {
        public string GetConnectionString()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Costume.json");
        }

        public void Delete(int CostumeID)
        {
            throw new NotImplementedException();
        }

        public List<Costume> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Costume costume)
        {
            throw new NotImplementedException();
        }
    }
}
