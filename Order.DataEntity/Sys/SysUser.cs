using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class SysUser
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
