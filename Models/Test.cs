using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<TestAttribute> Attributes { get; set; }
        public TestComment Comment { get; set; }
    }
}