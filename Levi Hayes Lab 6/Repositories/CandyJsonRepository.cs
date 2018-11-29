using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public List<Candy> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Candy candy)
        {
            throw new NotImplementedException();
        }
    }
}
