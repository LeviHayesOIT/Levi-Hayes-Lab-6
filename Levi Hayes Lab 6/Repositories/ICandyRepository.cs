using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public interface ICandyRepository
    {
        List<Candy> GetList();
        void Insert(Candy candy);
        void Delete(int CandyID);
    }
}
