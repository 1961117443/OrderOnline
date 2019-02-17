using System;
using System.Collections.Generic;
using System.Text;

namespace Order.ViewEntity
{
    /// <summary>
    /// 查询数据基类
    /// </summary>
    public class PageModel
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int Limit { get; set; }

        public string Key { get; set; }

        public PageModel()
        {
            Page = 1;
            Limit = 10;
        }
    }
}
