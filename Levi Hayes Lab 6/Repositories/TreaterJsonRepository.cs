using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public class TreaterJsonRepository : ITreaterRepository
    {
        public string GetConnectionString()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "Treater.json");
        }

        public List<Treater> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Treater treater)
        {
            throw new NotImplementedException();
        }
    }
}
