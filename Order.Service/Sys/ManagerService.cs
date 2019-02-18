using Order.IService;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Service
{
    public class ManagerService : IManagerService
    {
        public List<MenuNavView> GetMenuByUserId(int userId)
        {
            List<MenuNavView> menus = new List<MenuNavView>();
            #region 系统设置
            menus.Add(new MenuNavView()
            {
                Id = 100,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "系统设置",
                ParentId = 0
            });
            //menus.Add(new MenuNavView()
            //{
            //    Id = 101,
            //    Name = Guid.NewGuid().ToString(),
            //    DisplayName = "用户管理",
            //    ParentId = 100,
            //    LinkUrl = "/Manager/Index"
            //});
            //menus.Add(new MenuNavView()
            //{
            //    Id = 102,
            //    Name = Guid.NewGuid().ToString(),
            //    DisplayName = "角色管理",
            //    ParentId = 100
            //});
            //menus.Add(new MenuNavView()
            //{
            //    Id = 103,
            //    Name = Guid.NewGuid().ToString(),
            //    DisplayName = "权限分配",
            //    ParentId = 100
            //}); 
            #endregion
            #region 基础资料
            menus.Add(new MenuNavView()
            {
                Id = 200,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "基础资料",
                ParentId = 0
            });
            menus.Add(new MenuNavView()
            {
                Id = 201,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "客户档案",
                ParentId = 200,
                LinkUrl = "/Customer/Index"
            });
            menus.Add(new MenuNavView()
            {
                Id = 202,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "型材档案",
                ParentId = 200,
                LinkUrl = "/SectionBar/Index"
            });
            menus.Add(new MenuNavView()
            {
                Id = 203,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "表面档案",
                ParentId = 200,
                LinkUrl = "/Surface/Index"
            });
            #endregion
            #region 订单管理
            menus.Add(new MenuNavView()
            {
                Id = 300,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "订单管理",
                ParentId = 0,
                Spread = true
            });
            menus.Add(new MenuNavView()
            {
                Id = 301,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "在线下单",
                ParentId = 300,
                LinkUrl = "/Order/AddOrModify"
            });
            menus.Add(new MenuNavView()
            {
                Id = 302,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "销售订单",
                ParentId = 300,
                LinkUrl = "/Order/Index"
            });
            #endregion
            #region 报表管理
            menus.Add(new MenuNavView()
            {
                Id = 400,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "报表管理",
                ParentId = 0
            });
            menus.Add(new MenuNavView()
            {
                Id = 401,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "成品库存",
                ParentId = 400
            });
            menus.Add(new MenuNavView()
            {
                Id = 402,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "订单进度",
                ParentId = 400
            });
            #endregion
            #region 权限管理
            menus.Add(new MenuNavView()
            {
                Id = 500,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "权限管理",
                ParentId = 0
            });
            menus.Add(new MenuNavView()
            {
                Id = 501,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "用户管理",
                ParentId = 500,
                LinkUrl = "/Manager/Index"
            });
            menus.Add(new MenuNavView()
            {
                Id = 502,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "角色管理",
                ParentId = 500
            });
            menus.Add(new MenuNavView()
            {
                Id = 503,
                Name = Guid.NewGuid().ToString(),
                DisplayName = "权限分配",
                ParentId = 500
            }); 
            #endregion
            return menus;
        }
    }
}
