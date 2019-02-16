using System;
using System.Collections.Generic;
using System.Text;

namespace Order.DataEntity
{
    /// <summary>
    /// 角色菜单表
    /// </summary>
    public class SysRoleMenu
    {
        public int ID { get; set; }
        public Guid RoleID { get; set; }
        public Guid MenuID { get; set; }
    }
}
