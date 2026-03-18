using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheat
{
    internal class Country
    {
        public string Name;
        public Dictionary<string, double> Data = new Dictionary<string, double>();

        public Country(string name, Dictionary<string, double> data)
        {
            Name = name;
            Data = data;
        }
    }
}
