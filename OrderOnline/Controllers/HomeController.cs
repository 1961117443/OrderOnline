using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Extensions;
using Order.Core.Common.Helper;
using Order.Core.Common.Models;
using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.ViewEntity;
using OrderOnline.Models;

namespace OrderOnline.Controllers
{
    public class HomeController : BaseController
    {
        protected readonly ISalesOrderService salesOrderService;
        protected readonly IManagerService managerService;


        public HomeController(ISalesOrderService salesOrderService,IManagerService managerService)
        {
            this.salesOrderService = salesOrderService;
            this.managerService = managerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Main()
        {
            ViewData["LoginCount"] = "LoginCount";// User.Claims.FirstOrDefault(x => x.Type == "LoginCount")?.Value;
            ViewData["LoginLastIp"] = "LoginLastIp";// User.Claims.FirstOrDefault(x => x.Type == "LoginLastIp")?.Value;
            ViewData["LoginLastTime"] = "LoginLastTime";// User.Claims.FirstOrDefault(x => x.Type == "LoginLastTime")?.Value;
            return View();
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public string GetMenu()
        {
            List<MenuNavView> menus = managerService.GetMenuByUserId(0);
            var data = menus.GenerateTree(x => x.Id, x => x.ParentId);
            return JsonHelper.ObjectToJSON(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
