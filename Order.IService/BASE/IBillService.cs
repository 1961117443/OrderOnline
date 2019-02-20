using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.IService.BASE
{
    public interface IBillService<TEntity,TView>
    {
        List<TView> LoadData(Expression<Func<TView, bool>> whereExpression);
        Task<List<TView>> LoadDataAsync(Expression<Func<TView, bool>> whereExpression);
    }

}
