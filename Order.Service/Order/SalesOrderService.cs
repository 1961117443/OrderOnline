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
            this.Dal = salesOrderRepository;
            this.salesOrderRepository = salesOrderRepository;
            this.salesOrderDetailRepository = salesOrderDetailRepository;
            this.customerRepository = customerRepository;
        }

        public Task<SalesOrder> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<SalesOrder> LoadData(SalesOrderRequestModel requestModel)
        {
            var count =  salesOrderRepository.Count(w => w.BillCode != "");
            var orders =  salesOrderRepository.LoadData(t0 => t0.BillCode != "", requestModel.Page, requestModel.Limit);

            TableDataModel data = new TableDataModel()
            { 
                count = count,
                data = orders
            };
            return null;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<List<SalesOrder>> LoadDataAsync(Expression<Func<SalesOrder,bool>> where, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {   
            var orders = await salesOrderRepository.LoadDataAsync(t0 => t0.BillCode != "", intPageIndex, intPageSize, strOrderByFileds);
             
            return orders;
        }
        /// <summary>
        /// 加载订单从表的数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<List<SalesOrderDetail>> LoadItemDataAsync(Guid Id)
        {
            var detail = await salesOrderDetailRepository.LoadDataAsync(w=>w.MainID==Id,0,0,"RowNo"); 
            return detail;
        }
    }
}
