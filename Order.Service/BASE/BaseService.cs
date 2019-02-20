using Order.IRepository.BASE;
using Order.IService.BASE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Service.BASE
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        protected IBaseRepository<TEntity> dal;

        public async Task<int> Add(TEntity model)
        {
            return await dal.Add(model);
        }

        public async Task<int> CountAsync()
        {
            return await dal.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await dal.CountAsync(whereExpression);
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await dal.Delete(model);
        }

        public async Task<bool> DeleteById(object id)
        {
            return await dal.DeleteById(id);
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await dal.DeleteByIds(ids);
        }

        public async Task<List<TEntity>> Query()
        {
            return await dal.Query();
        }

        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await dal.Query(strWhere);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await dal.Query(whereExpression);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await dal.Query(whereExpression, strOrderByFileds);
        }
         
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await dal.Query(whereExpression, orderByExpression, isAsc);
        }

        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            return await dal.Query(strWhere, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return await dal.Query(whereExpression, intTop, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            return await dal.Query(strWhere, intTop, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await dal.Query(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await dal.Query(strWhere, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            return await dal.QueryByID(objId);
        }

        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            return await dal.QueryByID(objId, blnUseCache);
        }

        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await dal.QueryByIDs(lstIds);
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await dal.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<bool> Update(TEntity model)
        {
            return await dal.Update(model);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await dal.Update(entity, strWhere);
        }

        public async Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            return await dal.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }
    }
}
