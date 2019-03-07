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
    public class SurfaceController : BaseController
    {
        private readonly ISurfaceService surfaceService;

        public SurfaceController(ISurfaceService surfaceService, IMapper mapper)
        {
            this.Mapper = mapper;
            this.surfaceService = surfaceService;
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
        public async Task<string> AddOrModify(SurfaceDto requestModel)
        {

            var model = Mapper.Map<Surface>(requestModel);
            var sucess = false;
            if (model.ID.Equals(Guid.Empty))
            {
                sucess = await surfaceService.Add(model);
            }
            else
            {
                sucess = await surfaceService.Update(model);
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
            Expression<Func<Surface, bool>> where = w => w.Code != "";
            var data = await surfaceService.LoadDataAsync(where, requestModel.Page, requestModel.Limit, w => w.AutoID, false);
            var count = await surfaceService.CountAsync(where);
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
                var b = await this.surfaceService.DeleteByIds(Ids);
                return JsonHelper.ObjectToJSON(b ? ApiResultModel.Success : ApiResultModel.Fail);
            }
            return JsonHelper.ObjectToJSON(ApiResultModel.Success);
        }
    }
}