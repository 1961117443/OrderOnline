using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    public class Customer
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
