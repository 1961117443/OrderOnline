using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.Service.BASE;
using Order.ViewEntity;

namespace Order.Service
{
    public class SalesOrderService : BaseService<SalesOrder>, ISalesOrderService
    {
        protected readonly ISalesOrderRepository salesOrderRepository;
        protected readonly ISalesOrderDetailRepository salesOrderDetailRepository;
        protected readonly ICustomerRepository customerRepository;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository,
            ISalesOrderDetailRepository salesOrderDetailRepository,
            ICustomerRepository customerRepository)
        {
            this.dal = salesOrderRepository;
            this.salesOrderRepository = salesOrderRepository;
            this.salesOrderDetailRepository = salesOrderDetailRepository;
            this.customerRepository = customerRepository;
        }

        public TableDataModel LoadData(SalesOrderRequestModel requestModel)
        {
            var count =  salesOrderRepository.GetRecordCount(t0 => t0.BillCode != "");
            var orders =  salesOrderRepository.LoadData(t0 => t0.BillCode != "", requestModel.Page, requestModel.Limit);

            TableDataModel data = new TableDataModel()
            { 
                count = count,
                data = orders
            };
            return data;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<TableDataModel> LoadDataAsync(SalesOrderRequestModel requestModel)
        {  
            var count = await salesOrderRepository.GetRecordCountAsync(t0 => t0.BillCode != "");
            var orders = await salesOrderRepository.LoadDataAsync(t0 => t0.BillCode != "", requestModel.Page, requestModel.Limit);

            TableDataModel data = new TableDataModel()
            { 
                count = count,
                data = orders
            };
            return data;
        }
        /// <summary>
        /// 加载订单从表的数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<TableDataModel> LoadItemDataAsync(Guid Id)
        {
            var detail = await salesOrderDetailRepository.LoadItemDataByIdAsync(Id);
            TableDataModel data = new TableDataModel
            {
                data = detail
            };
            return data;
        }
    }
}
