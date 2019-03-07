using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.ViewEntity;

namespace OrderOnline.Controllers
{
    public class ManagerController : BaseController
    {
        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 加载列表数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public IActionResult LoadData([FromQuery]ManagerRequestModel requestModel)
        {
            var table = new TableDataModel();
            return Json(table);
        }
        
        /// <summary>
        /// 编辑用户页面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddOrModify()
        {
            return View();
        }

    }
}