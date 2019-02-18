using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.Repository.SqlSugar.BASE;
using Order.ViewEntity;
using SqlSugar;

namespace Order.Repository.SqlSugar
{
    public class SalesOrderRepository : BaseRepository<SalesOrder>, ISalesOrderRepository
    {
        #region 同步方法 
        public List<SalesOrderView> LoadData(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            var data = Db.Queryable<SalesOrder, Customer>((t0, t1) => new object[] { JoinType.Left, t0.CustomerID == t1.ID })
                .Where(whereExpression)
                .Select((t0, t1) => new SalesOrderView()
                {
                    ID = t0.ID,
                    BillCode = t0.BillCode,
                    CustomerID = t0.CustomerID,
                    BillDate = t0.BillDate,
                    CustomerIDCode = t1.Code,
                    CustomerIDName = t1.Name,
                    Remark = t0.Remark,
                    Maker = t0.Maker,
                    MakeDate = t0.MakeDate,
                    Audit = t0.Audit,
                    AuditDate = t0.AuditDate
                }).ToList();

            return data;
        }
        #endregion

        #region 异步方法
        public async Task<List<SalesOrderView>> LoadDataAsync(Expression<Func<SalesOrder, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            var q = Db.Queryable<SalesOrder, Customer>((t0, t1) => new object[] { JoinType.Left, t0.CustomerID == t1.ID })
                 .Where(whereExpression)
                 .Select((t0, t1) => new SalesOrderView()
                 {
                     ID = t0.ID,
                     BillCode = t0.BillCode,
                     CustomerID = t0.CustomerID,
                     BillDate = t0.BillDate,
                     CustomerIDCode = t1.Code,
                     CustomerIDName = t1.Name,
                     Remark = t0.Remark,
                     Maker = t0.Maker,
                     MakeDate = t0.MakeDate,
                     Audit = t0.Audit,
                     AuditDate = t0.AuditDate
                 });
            var data = await q.ToListAsync();
            // var data = await Task.Run(() => q.ToList());
            return data;
        }
        #endregion
    }
}
