using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemka
{
    public class Group
    {
        //конструктор класса Group
        public Group(string name = "none",string prefix = "none")
        {
            Name = name;
            Prefix = prefix;
        }
        //задаём свойства 
        public string Name { get; set; }
        public string Prefix { get; set; }
    }
}
