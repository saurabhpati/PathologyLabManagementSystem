﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class TestAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TestId { get; set; }
        public string Unit  { get; set; }
        public string ReferenceValue { get; set; }
    }
}