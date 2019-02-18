using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Helper;
using Order.IService;
using Order.ViewEntity;

namespace OrderOnline.Controllers
{
    public class OrderController : BaseController
    {
        protected readonly ISalesOrderService salesOrderService;
        public OrderController(ISalesOrderService salesOrderService)
        {
            this.salesOrderService = salesOrderService;
        }

        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddOrModify()
        {
            List<ManagerRole> managerRoles = new List<ManagerRole>();
            return View(managerRoles);
        }

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddOrModify([FromForm]SalesOrderView model)
        {
            return Json("");
        }

        /// <summary>
        /// 订单列表数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<string> LoadData([FromQuery]SalesOrderRequestModel requestModel)
        {
            var data = await  salesOrderService.LoadDataAsync(requestModel);
            return JsonHelper.ObjectToJSON(data);
        }

        /// <summary>
        /// 订单从表数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> LoadItemData([FromQuery]SalesOrderView requestModel)
        { 
            var data = await salesOrderService.LoadItemDataAsync(requestModel.ID);
            return JsonHelper.ObjectToJSON(data);
        }
    }
}