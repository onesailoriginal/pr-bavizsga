using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Airplanes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int capacity { get; set; }
        public int range { get; set; }
        public int owner_id { get; set; }
        public Airplanes(string name, string type, int capacity, int range)
        {
            this.name = name;
            this.type = type;
            this.capacity = capacity;
            this.range = range;
        }
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Type:{type} capacity: {capacity}, range: {range}";
        }
    }

}
