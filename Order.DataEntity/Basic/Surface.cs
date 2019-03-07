using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    using SqlSugar;
    public class Surface
    {
        public Guid ID { get; set; }
        [SugarColumn(ColumnName = "SurfaceCode")]
        public string Code { get; set; }

        [SugarColumn(ColumnName = "SurfaceName")]
        public string Name { get; set; }

        public int RowNo { get; set; }
        public int AutoID { get; set; }
    }
}
