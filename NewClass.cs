using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class NewClass
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private void SetName(string name)
        {
            Name = name;
        }
    }
}