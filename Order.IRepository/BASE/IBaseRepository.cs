using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.IRepository.BASE
{
    public interface IBaseRepository<TEntity> where TEntity : class
    { 
        /// <summary>
        /// 获取第一条
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        Task<TEntity> First(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression = null, bool isAsc = true);

        #region 添加
        Task<int> Add(TEntity model);
        #endregion

        #region 删除
        Task<bool> DeleteById(object id);

        Task<bool> Delete(TEntity model);

        Task<bool> DeleteByIds(object[] ids);
        #endregion

        #region 修改
        Task<bool> Update(TEntity model);
        Task<bool> Update(TEntity entity, string strWhere);
        Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "");
        #endregion


        #region 记录数
        int Count();
        int Count(Expression<Func<TEntity, bool>> whereExpression);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression); 
        #endregion

        #region 查询
        Task<List<TEntity>> Query();
        Task<List<TEntity>> Query(string strWhere);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);
        Task<TEntity> QueryByID(object objId);
        Task<TEntity> QueryByID(object objId, bool blnUseCache = false);
        Task<List<TEntity>> QueryByIDs(object[] lstIds);
        Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
        #endregion

        #region 加载数据

        //Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20);
        Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression = null, bool isAsc = true, int intPageIndex = 0, int intPageSize = 20);
       // Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, Expression<Func<TEntity, object>> orderByExpression = null, bool isAsc = true);
        #endregion
    }
}
