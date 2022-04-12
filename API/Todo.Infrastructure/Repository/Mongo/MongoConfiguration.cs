using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Infrastructure.Repository.Mongo
{
    public class MongoConfiguration
    {
        public string MONGO_URL { get; set; }
        public string DATABSE_NAME { get; set; }
        public string MONGO_LOGIN {get;set;}
        public string MONGO_PASSWORD { get; set; }
    }
}
