using Todo.Domain;
using Todo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Infrastructure.Services;
using Todo.Infrastructure.Commands;

namespace Todo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoContoller : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoContoller(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IEnumerable<TodoModel> Get()
        {
            return _todoService.GetAll().OrderByDescending(x=>x.AddedTime).Select(x => new TodoModel { Todo = x.Todo, IsDone = x.IsDone, Id = x.Id });
        }

        [HttpPost("add")]
        public IEnumerable<TodoModel> Add(AddTodoCommand command)
        {
            _todoService.Add(new AddTodoCommand() {Todo= command.Todo});
            return _todoService.GetAll().Select(x => new TodoModel { Todo = x.Todo, IsDone = x.IsDone, Id = x.Id });
        }

        [HttpPost("update")]
        public IEnumerable<TodoModel> UpdateIsDone(UpdateIsDoneCommand command)
        {
            _todoService.UpdateDone(command.Id  , command.IsDone);
            return _todoService.GetAll().Select(x => new TodoModel { Todo = x.Todo, IsDone = x.IsDone, Id = x.Id });
        }

        [HttpDelete("remove")]
        public IEnumerable<TodoModel> Remove(Guid id)
        {
            _todoService.Remove(id);
            return _todoService.GetAll().Select(x => new TodoModel { Todo = x.Todo, IsDone = x.IsDone, Id = x.Id });
        }

    }
}
