using Order.DataEntity;
using Order.IRepository.BASE;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Order.IRepository
{
    public interface ISalesOrderDetailRepository : IBaseRepository<SalesOrderDetail>
    {
        Task<List<SalesOrderDetailView>> LoadItemDataByIdAsync(Guid Id);
    }
}
