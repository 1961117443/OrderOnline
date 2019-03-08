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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.Mapper = mapper;
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddOrModify()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> AddOrModify(CustomerDto requestModel)
        {

            var model = Mapper.Map<Customer>(requestModel);
            var sucess = false;
            if (model.ID.Equals(Guid.Empty))
            {
                sucess = await customerService.Add(model);
            }
            else
            {
                sucess = await customerService.Update(model);
            }
            ApiResultModel res = new ApiResultModel();
            return JsonHelper.ObjectToJSON(res);
        }

        /// <summary>
        /// 加载客户列表数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> LoadData(PageModel requestModel)
        {
            Expression<Func<Customer, bool>> where = w => w.Code != "";
            if (!string.IsNullOrEmpty(requestModel.Key))
            {
                where = w => w.Code.Contains(requestModel.Key) || w.Name.Contains(requestModel.Key);
            }
            var data = await customerService.LoadDataAsync(where, requestModel.Page, requestModel.Limit, w => w.AutoID, false);
            var count = await customerService.CountAsync(where);
            TableDataModel tableDataModel = new TableDataModel()
            {
                count = count,
                data = Mapper.Map<List<CustomerDto>>(data)
            };
            return Content(JsonHelper.ObjectToJSON(tableDataModel));
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="sectionBarId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Delete(string[] Ids)
        {
            if (Ids != null && Ids.Length > 0)
            {
                var b = await this.customerService.DeleteByIds(Ids);
                return JsonHelper.ObjectToJSON(b ? ApiResultModel.Success : ApiResultModel.Fail);
            }
            return JsonHelper.ObjectToJSON(ApiResultModel.Success);
        }
    }
}