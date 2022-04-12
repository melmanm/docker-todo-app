using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain;
using Todo.Infrastructure.Commands;

namespace Todo.Infrastructure.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetAll();

        void Add(AddTodoCommand todo);

        void Remove(Guid id);

        void UpdateDone(Guid id, bool isDone);
    }
}
