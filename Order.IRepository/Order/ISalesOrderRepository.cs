using Order.DataEntity;
using Order.IRepository.BASE;
using Order.ViewEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.IRepository
{
    public interface ISalesOrderRepository : IBaseRepository<SalesOrder>
    {
        List<SalesOrderView> LoadData(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds="");
        Task<List<SalesOrderView>> LoadDataAsync(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds = ""); 
       
    }
}
