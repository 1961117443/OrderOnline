using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.IService.BASE
{
    public interface IBillService<TEntity, TView>
    {
        List<TEntity> LoadData(Expression<Func<TEntity, bool>> whereExpression);
        //Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
    }

}
