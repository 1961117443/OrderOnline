using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    /// <summary>
    /// 订单主表
    /// </summary>
    public class SalesOrder
    {
        public Guid ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        [SugarColumn(ColumnName ="OrderDate")]
        public string BillDate { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public Guid CustomerID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
