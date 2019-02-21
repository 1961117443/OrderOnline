using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.Repository.SqlSugar.BASE;
using SqlSugar;

namespace Order.Repository.SqlSugar
{
    public class SalesOrderDetailRepository : BaseRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        protected override ISugarQueryable<SalesOrderDetail> GetSugarQuery()
        {
            return Db.Queryable<SalesOrderDetail>()
                .Mapper(w => w.SectionBar, w => w.SectionBarID)
                .Mapper(w => w.Surface, w => w.SurfaceID)
                .Mapper(w => w.Packing, w => w.PackingID);
        }
        public async Task<List<SalesOrderDetail>> LoadDataAsync(Expression<Func<SalesOrderDetail, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds = "")
        {
            var q = Db.Queryable<SalesOrderDetail>()
                .WhereIF(whereExpression != null, whereExpression)
                .OrderByIF(!string.IsNullOrEmpty(strOrderByFileds),strOrderByFileds)
                .Mapper(w => w.SectionBar, w => w.SectionBarID)
                .Mapper(w => w.Surface, w => w.SurfaceID)
                .Mapper(w => w.Packing, w => w.PackingID);

            if (intPageIndex>0 && intPageSize>0)
            {
                return await Task.Run(() => q.ToPageList(intPageIndex, intPageSize));
            }
            else
            {
                return await Task.Run(() => q.ToList());
            }
        }

        public async Task<List<SalesOrderDetail>> LoadItemDataByIdAsync(Guid Id)
        {
            var q = Db.Queryable<SalesOrderDetail, SectionBar, Packing, Surface>(
                (t0, t1, t2, t3) =>
              new object[] {
                JoinType.Left, t0.SectionBarID == t1.ID,
               JoinType.Left, t0.PackingID ==t2.ID,
               JoinType.Left, t0.SurfaceID ==t3.ID
              }).Where((t0) => t0.MainID == Id)
            .Select((t0, t1, t2, t3) => new SalesOrderDetail()
            {
                ID = t0.ID,
                SurfaceID = t0.SurfaceID,
                PackingID = t0.PackingID,
                SectionBarID = t0.SectionBarID,
                MainID = t0.MainID,
                OrderLength = t0.OrderLength,
                //PackingIDName = t2.Name,
                //SectionBarIDCode = t1.Code,
                //SectionBarIDName = t1.Name,
                //SurfaceIDName = t3.Name,
                TheoryMeter = t0.TheoryMeter,
                TheoryWeight = t0.TheoryWeight,
                TotalQuantity = t0.TotalQuantity,
                TraceCode = t0.TraceCode
            });
            var data = await q.ToListAsync(); 
            return data;
        }
    }
}
