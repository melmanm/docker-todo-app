using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Commands
{
    public class UpdateIsDoneCommand
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
    }
}
