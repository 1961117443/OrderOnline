using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Helper;
using Order.IService;
using Order.ViewEntity; 
using AutoMapper;
using System.Linq.Expressions;
using Order.DataEntity;

namespace OrderOnline.Controllers
{
    public class SectionBarController : BaseController
    {
        protected ISectionBarService sectionBarService;
        public SectionBarController(ISectionBarService sectionBarService,IMapper mapper)
        {
            this.sectionBarService = sectionBarService;
            this.Mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOrModify()
        {
            return View();
        }

        public async Task<IActionResult> LoadData(PageModel requestModel)
        {
            Expression<Func<SectionBar, bool>> where = w => w.Code != "";
            var data = await sectionBarService.LoadDataAsync(where, requestModel.Page, requestModel.Limit);
            var count = await sectionBarService.CountAsync(where);
            TableDataModel tableDataModel = new TableDataModel()
            {
                count = count,
                data = Mapper.Map<List<SectionBarDto>>(data)
            };
            return Content(JsonHelper.ObjectToJSON(tableDataModel));
        }
    }
}