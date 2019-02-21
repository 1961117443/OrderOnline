using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    using SqlSugar;
    public class SectionBar
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string WallThickness { get; set; }
        [SugarColumn(ColumnName = "Theoreticalweight")]
        public decimal TheoryMeter { get; set; }
    }
}
