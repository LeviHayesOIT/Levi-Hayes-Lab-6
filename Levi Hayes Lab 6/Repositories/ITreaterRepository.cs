using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;

namespace Levi_Hayes_Lab_6.Repositories
{
    public interface ITreaterRepository
    {
        List<Treater> GetList();
        void Insert(Treater treater);
    }
}
