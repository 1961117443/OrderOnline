using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    using SqlSugar;
    public partial class SalesOrderDetail
    {
        [SugarColumn(IsIgnore = true)]
        public virtual SectionBar SectionBar { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Surface Surface { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Packing Packing { get; set; }
    }
}
