using Todo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        public static List<T> data = new List<T>();

        public void Add(T item)
        {
            data.Add(item);
        }

        public T Get(Guid id)
        {
            return data.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return data;
        }

        public void Remove(Guid id)
        {
            var item = data.FirstOrDefault(x => x.Id == id);
            if (item != null)
                data.Remove(item);
        }

        public void SaveChanges(T item)
        {
           
        }
    }
}
