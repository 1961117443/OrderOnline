using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class SysUserRole
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public Guid RoleID { get; set; }
    }
}
