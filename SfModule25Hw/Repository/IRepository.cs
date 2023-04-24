using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfModule25Hw.Repository
{
    public interface IRepository<T>
    {
        T GetById(int id);
        List<T> GetAll();
        void CreateNewRecord(T record);
        void DeleteById(int id);
    }
}

