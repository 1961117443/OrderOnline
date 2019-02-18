using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Order.DataEntity;
using Order.IRepository;
using Order.Repository.SqlSugar.BASE;
using Order.ViewEntity;
using SqlSugar;

namespace Order.Repository.SqlSugar
{
    public class SalesOrderDetailRepository : BaseRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public async Task<List<SalesOrderDetailView>> LoadItemDataByIdAsync(Guid Id)
        {
            var q = Db.Queryable<SalesOrderDetail, SectionBar, Packing, Surface>(
                (t0, t1, t2, t3) =>
              new object[] {
                JoinType.Left, t0.SectionBarID == t1.ID,
               JoinType.Left, t0.PackingID ==t2.ID,
               JoinType.Left, t0.SurfaceID ==t3.ID
              }).Where((t0) => t0.MainID == Id)
            .Select((t0, t1, t2, t3) => new SalesOrderDetailView()
            {
                ID = t0.ID,
                SurfaceID = t0.SurfaceID,
                PackingID = t0.PackingID,
                SectionBarID = t0.SectionBarID,
                MainID = t0.MainID,
                OrderLength = t0.OrderLength,
                PackingIDName = t2.Name,
                SectionBarIDCode = t1.Code,
                SectionBarIDName = t1.Name,
                SurfaceIDName = t3.Name,
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
