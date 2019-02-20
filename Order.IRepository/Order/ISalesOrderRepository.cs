using Order.DataEntity;
using Order.IRepository.BASE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Order.IRepository
{
    public interface ISalesOrderRepository : IBaseRepository<SalesOrder>
    {
        List<SalesOrder> LoadData(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds="");
        Task<List<SalesOrder>> LoadDataAsync(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds = ""); 
       
    }
}
