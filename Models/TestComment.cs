﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class TestComment
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Text { get; set; }
    }
}