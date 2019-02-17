using Order.DataEntity;
using Order.IRepository;
using Order.IService;
using Order.Service.BASE;

namespace Order.Service
{
    public class SalesOrderService : BaseService<SalesOrder>, ISalesOrderService
    {
        protected readonly ISalesOrderDetailRepository salesOrderDetailRepository;
        public SalesOrderService(ISalesOrderRepository salesOrderRepository,ISalesOrderDetailRepository salesOrderDetailRepository)
        {
            this.dal = salesOrderRepository;
            this.salesOrderDetailRepository = salesOrderDetailRepository;
        }
 
    }
}
