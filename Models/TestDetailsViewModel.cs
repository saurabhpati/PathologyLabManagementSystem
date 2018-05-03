using System.Collections.Generic;

namespace Models
{
    public class TestDetailsViewModel
    {
        public int TestId { get; set; }

        public string TestName { get; set; }

        public string TestType { get; set; }

        public List<TestAttribute> LstTestAttr { get; set; }

        public string Comment { get; set; }
    }
}