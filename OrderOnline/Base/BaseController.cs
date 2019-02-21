using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace OrderOnline.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public abstract class BaseController : Controller
    {
        public IMapper Mapper { get; set; }
    }
}