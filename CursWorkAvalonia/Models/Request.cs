using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursWorkAvalonia.Models
{
    public class Request
    {
        public string Name { get; set; }    
        public string TableName { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Operation { get; set; }

        public string? Additions { get; set; }
       /* public Request(string name,string tableName, string field)
        {
            Name = name;
            Field = field;
            TableName = tableName;
        }*/
        public Request(string name)
        {
            Name = name;
        }
    }
}
