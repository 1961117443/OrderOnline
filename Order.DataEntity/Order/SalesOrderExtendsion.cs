using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    public partial class SalesOrder
    {
        [SugarColumn(IsIgnore =true)]
        public virtual Customer Customer { get; set; }
    }
}
