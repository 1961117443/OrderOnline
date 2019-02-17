using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.IService
{
    public interface IManagerService
    {
        /// <summary>
        /// 根据用户ID 获取用户的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<MenuNavView> GetMenuByUserId(int userId);
    }
}
