﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ViewEntity
{
    public class SectionBarDto
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string WallThickness { get; set; }
        public decimal TheoryMeter { get; set; }
    }
}
