using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        T Get(Guid id);

        void Remove(Guid id);

        void SaveChanges(T item);

    }
}
