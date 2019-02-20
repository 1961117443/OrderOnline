using Order.DataEntity;
using Order.IRepository.BASE; 
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.IRepository
{
    public interface ISalesOrderDetailRepository : IBaseRepository<SalesOrderDetail>
    {
        Task<List<SalesOrderDetail>> LoadItemDataByIdAsync(Guid Id);

        Task<List<SalesOrderDetail>> LoadDataAsync(Expression<Func<SalesOrderDetail, bool>> whereExpression, int intPageIndex=0, int intPageSize = 0, string strOrderByFileds = "");
    }
}
