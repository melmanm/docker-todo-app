using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain
{
    public class TodoItem : BaseEntity
    {
        public TodoItem()
        {
            AddedTime = DateTime.Now;
        }

        public string Todo { get; set; }
        public bool IsDone { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
