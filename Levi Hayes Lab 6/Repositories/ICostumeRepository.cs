using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public interface ICostumeRepository
    {
        List<Costume> GetList();
        void Insert(Costume costume);
        void Delete(int CostumeID);
    }
}
