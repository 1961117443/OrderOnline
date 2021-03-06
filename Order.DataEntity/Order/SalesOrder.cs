﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    /// <summary>
    /// 订单主表
    /// </summary>
    public partial class SalesOrder
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
        public DateTime BillDate { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public Guid CustomerID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public string Maker { get; set; }
        public DateTime MakeDate { get; set; }
        public string Audit { get; set; }
        public DateTime? AuditDate { get; set; }
    }
}
