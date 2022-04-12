using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Todo { get; set; }
        public bool IsDone { get; set; }
    }
}
