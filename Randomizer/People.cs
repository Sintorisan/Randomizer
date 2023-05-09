using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    internal class People
    {
        public int Counter { get; set; }

        public string Name { get; set; }

        public List<string> ToDoList { get; set; }

        public People(string name) 
        {
            this.Name = name;
            this.ToDoList = new List<string>();
            this.Counter = 0;
        }
    }
}
