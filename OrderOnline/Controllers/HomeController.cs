using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.IService;
using Order.Repository.SqlSugar;
using OrderOnline.Models;

namespace OrderOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalesOrderService _salesOrderService;

        public HomeController(ISalesOrderService salesOrderService)
        {
            this._salesOrderService = salesOrderService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                SalesOrderRepository salesOrderRepository = new SalesOrderRepository();
            }
            catch (Exception ex)
            {

                throw;
            }
           
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
