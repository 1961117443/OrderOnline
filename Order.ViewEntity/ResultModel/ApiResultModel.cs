using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ViewEntity
{
    public class ApiResultModel
    {
        /// <summary>
        /// 响应代码
        /// </summary>
        public int ResultCode { get; set; } = 0;
        /// <summary>
        /// 响应消息
        /// </summary>
        public string ResultMsg { get; set; } = "操作成功";
    }
}
