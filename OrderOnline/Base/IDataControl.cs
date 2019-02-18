using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOnline.Controllers
{
    /// <summary>
    /// 模块接口，拥有基本的单据操作
    /// </summary>
    public interface IDataControl
    {
        /// <summary>
        /// 返回首页
        /// </summary>
        /// <returns></returns>
        IActionResult Index();
        /// <summary>
        /// 返回编辑页面
        /// </summary>
        /// <returns></returns>
        IActionResult AddOrModify();

        /// <summary>
        /// 数据列表
        /// </summary>
        /// <returns></returns>
        IActionResult LoadData();
    }
}
