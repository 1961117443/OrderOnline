using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ViewEntity
{ 
    public class ShortDateTimeConverter: IsoDateTimeConverter
    {
        public ShortDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
   public  class SalesOrderView
    {
        public Guid ID { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string BillCode { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary> 
        [JsonConverter(typeof(ShortDateTimeConverter))]
        public DateTime BillDate { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public Guid CustomerID { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerIDCode { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerIDName { get; set; }
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
