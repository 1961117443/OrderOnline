using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.Repository.SqlSugar.BASE; 
using SqlSugar;
using PageModel = SqlSugar.PageModel;

namespace Order.Repository.SqlSugar
{
    public class SalesOrderRepository : BaseRepository<SalesOrder>, ISalesOrderRepository
    {
        #region 同步方法 
        public List<SalesOrder> LoadData(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return Db.Queryable<SalesOrder>()
                .Where(whereExpression)
                .Mapper(o => o.Customer, o => o.CustomerID)
                .ToPageList(intPageIndex, intPageSize); 
        }
        #endregion

        #region 异步方法
        public async Task<List<SalesOrder>> LoadDataAsync(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await Db.Queryable<SalesOrder>()
                .Where(whereExpression)
                .Mapper(o => o.Customer, o => o.CustomerID)
                .ToPageListAsync(intPageIndex, intPageSize);
        }
        #endregion
    }
}
