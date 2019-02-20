using Order.DataEntity;
using Order.IService.BASE;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.IService
{
    public interface ISalesOrderService : IBaseService<SalesOrder>
    {
        ///// <summary>
        ///// 加载订单列表的数据
        ///// </summary>
        ///// <param name="requestModel"></param>
        ///// <returns></returns>
        //List<SalesOrderDto> LoadData(SalesOrderRequestModel requestModel);
        /// <summary>
        /// 加载订单列表的数据
        /// 异步方法
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<List<SalesOrder>> LoadDataAsync(Expression<Func<SalesOrder,bool>> where, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
        /// <summary>
        /// 加载订单从表的数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<List<SalesOrderDetail>> LoadItemDataAsync(Guid Id);

    }
}
