using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Helper;
using Order.DataEntity;
using Order.IService;
using Order.ViewEntity;

namespace OrderOnline.Controllers
{
    public class OrderController : BaseController
    {
        protected readonly ISalesOrderService salesOrderService;
        protected readonly IMapper mapper;
        public OrderController(ISalesOrderService salesOrderService,IMapper mapper)
        {
            this.salesOrderService = salesOrderService;
            this.mapper = mapper;
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
        public IActionResult AddOrModify([FromForm]SalesOrderDto model)
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
            Expression<Func<SalesOrder, bool>> exp = w => w.BillCode != "";
            var count = await salesOrderService.CountAsync(exp);
            var orders = await salesOrderService.LoadDataAsync(exp, requestModel.Page, requestModel.Limit); 
            var data = mapper.Map<List<SalesOrderDto>>(orders);
            TableDataModel tableData = new TableDataModel()
            {
                count = count,
                data = mapper.Map<List<SalesOrderDto>>(orders)
            };
            return JsonHelper.ObjectToJSON(tableData);
        }

        /// <summary>
        /// 订单从表数据
        /// </summary>
        /// <returns></returns>
        public async Task<string> LoadItemData([FromQuery]SalesOrderDto requestModel)
        { 
            var detail = await salesOrderService.LoadItemDataAsync(requestModel.ID); 
            TableDataModel tableData = new TableDataModel()
            {
                count = detail.Count(),
                data = mapper.Map<List<SalesOrderDetailDto>>(detail)
            };
            return JsonHelper.ObjectToJSON(tableData);
        }
    }
}