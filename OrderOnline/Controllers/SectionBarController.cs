using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Helper;
using Order.IService;
using Order.ViewEntity;
using System.Linq;

namespace OrderOnline.Controllers
{
    public class SectionBarController : BaseController
    {
        protected ISectionBarService sectionBarService;
        public SectionBarController(ISectionBarService sectionBarService)
        {
            this.sectionBarService = sectionBarService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOrModify()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            var data= sectionBarService.LoadData(w => w.Code != "");
            TableDataModel tableDataModel = new TableDataModel()
            {
                data = data
            };
            return Content(JsonHelper.ObjectToJSON(tableDataModel));
        }
    }
}