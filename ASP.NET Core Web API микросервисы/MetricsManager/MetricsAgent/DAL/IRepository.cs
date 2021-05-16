using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{ 
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();

        T GetById(int id);

        IList<T> GetByTimeSpan(DateTimeOffset fromTime, DateTimeOffset toTime);
        
        void Create(T item);
    }
}
