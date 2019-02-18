using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Common.Helper;
using Order.ViewEntity;

namespace OrderOnline.Controllers
{
    public class SectionBarController : BaseController
    {
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
            TableDataModel tableDataModel = new TableDataModel()
            {
                data = new List<SectionBarView>()
            };
            return Content(JsonHelper.ObjectToJSON(tableDataModel));
        }
    }
}