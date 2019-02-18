using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    public class Packing
    {
        public Guid ID { get; set; }

        [SugarColumn(ColumnName = "PackingCode")]
        public string Code { get; set; }

        [SugarColumn(ColumnName = "PackingName")]
        public string Name { get; set; }
    }
}
