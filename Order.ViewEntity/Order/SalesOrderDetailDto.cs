using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ViewEntity
{
    /// <summary>
    /// 订单从表
    /// </summary>
    public class SalesOrderDetailDto
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 关联主表id
        /// </summary>
        public Guid MainID { get; set; }
        /// <summary>
        /// 订单跟踪号
        /// </summary>
        public string TraceCode { get; set; }
        /// <summary>
        /// 型材型号id
        /// </summary>
        public Guid SectionBarID { get; set; }

        /// <summary>
        /// 型材型号
        /// </summary>
        public string SectionBarCode { get; set; }

        /// <summary>
        /// 型材名称
        /// </summary>
        public string SectionBarName { get; set; }
        /// <summary>
        /// 表面id
        /// </summary>
        public Guid SurfaceID { get; set; }

        /// <summary>
        /// 表面方式
        /// </summary>
        public string SurfaceName { get; set; }

        /// <summary>
        /// 包装id
        /// </summary>
        public Guid PackingID { get; set; }
        /// <summary>
        /// 包装方式
        /// </summary>
        public string PackingName { get; set; }
        /// <summary>
        /// 订单数
        /// </summary>
        public int TotalQuantity { get; set; }
        /// <summary>
        /// 理论米重
        /// </summary>
        public decimal TheoryMeter { get; set; }
        /// <summary>
        /// 订单长度
        /// </summary>
        public string OrderLength { get; set; }
        /// <summary>
        /// 订单理重
        /// </summary>
        public decimal TheoryWeight { get; set; }

    }
}
