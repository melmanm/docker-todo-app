using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain;
using Todo.Infrastructure.Commands;

namespace Todo.Infrastructure.Services
{
    public class TodoService : ITodoService
    {

        private readonly IRepository<TodoItem> _todoRepository;

        public TodoService(IRepository<TodoItem> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public void Add(AddTodoCommand command)
        {
            _todoRepository.Add(new TodoItem() { Todo = command.Todo, IsDone = false, Id = Guid.NewGuid() });
        }

        public void Remove(Guid id)
        {
            _todoRepository.Remove(id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todoRepository.GetAll().OrderByDescending(x => x.AddedTime);
        }

        public void UpdateDone(Guid id, bool isDone)
        {
            var item = _todoRepository.Get(id);
            item.IsDone = isDone;
            _todoRepository.SaveChanges(item);
        }
    }
}
