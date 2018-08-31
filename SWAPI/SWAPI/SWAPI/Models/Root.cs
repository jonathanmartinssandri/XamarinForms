using System;
using System.Collections.Generic;
using System.Text;

namespace SWAPI.Models
{
    public class Root
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Information> results { get; set; }
    }
}
