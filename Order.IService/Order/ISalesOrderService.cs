using Order.DataEntity;
using Order.IService.BASE;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.IService
{
    public interface ISalesOrderService : IBaseService<SalesOrder>
    {
        /// <summary>
        /// 加载订单列表的数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        TableDataModel LoadData(SalesOrderRequestModel requestModel);
        /// <summary>
        /// 加载订单列表的数据
        /// 异步方法
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<TableDataModel> LoadDataAsync(SalesOrderRequestModel requestModel);
        /// <summary>
        /// 加载订单从表的数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<TableDataModel> LoadItemDataAsync(Guid Id);
    }
}
