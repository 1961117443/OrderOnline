using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.DataEntity;
using Order.IRepository;
using Order.IService; 
using OrderOnline.Models;

namespace OrderOnline.Controllers
{
    public class HomeController : Controller
    {
        protected readonly ISalesOrderService _salesOrderService;


        public HomeController(ISalesOrderService salesOrderService)
        {
            this._salesOrderService = salesOrderService;
        }
        public async Task<IActionResult> Index()
        { 
            var  list= await this._salesOrderService.Query();
            return View();
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
