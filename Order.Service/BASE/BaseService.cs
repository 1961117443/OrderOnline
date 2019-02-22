using Order.IRepository.BASE;
using Order.IService.BASE;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Order.Service.BASE
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        #region 数据访问层对象
        private IBaseRepository<TEntity> dal;
        /// <summary>
        /// 数据访问层
        /// </summary>
        protected IBaseRepository<TEntity> Dal
        {
            get
            {
                if (dal == null)
                {
                    var field = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                        .FirstOrDefault(w => typeof(IBaseRepository<TEntity>).IsAssignableFrom(w.FieldType));
                    if (field != null)
                    {
                        dal = (IBaseRepository<TEntity>)field.GetValue(this);
                    }
                    else
                    {
                        var property = GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                        .FirstOrDefault(w => typeof(IBaseRepository<TEntity>).IsAssignableFrom(w.DeclaringType));
                        if (property != null)
                        {
                            dal = (IBaseRepository<TEntity>)property.GetValue(this);
                        }
                    }

                    if (dal == null)
                    {
                        throw new ArgumentNullException("请创建数据访问层对象:Dal");
                    }

                }
                return dal;
            }
            set
            {
                if (!ReferenceEquals(dal, value))
                {
                    dal = value;
                }
            }
        } 
        #endregion

        public virtual async Task<bool> Add(TEntity model)
        {
            return await Dal.Add(model);
        }

        public async Task<int> CountAsync()
        {
            return await Dal.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Dal.CountAsync(whereExpression);
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await Dal.Delete(model);
        }

        public async Task<bool> DeleteById(object id)
        {
            return await Dal.DeleteById(id);
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await Dal.DeleteByIds(ids);
        }

        public async Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20)
        {
            return await Dal.LoadDataAsync(whereExpression, null, true, intPageIndex, intPageSize);
        }

        public async Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression = null, bool isAsc = true, int intPageIndex = 0, int intPageSize = 20)
        {
            return await Dal.LoadDataAsync(whereExpression, orderByExpression, isAsc, intPageIndex, intPageSize);
        }

        public async Task<List<TEntity>> LoadDataAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, Expression<Func<TEntity, object>> orderByExpression = null, bool isAsc = true)
        {
            return await Dal.LoadDataAsync(whereExpression, orderByExpression, isAsc, intPageIndex, intPageSize);
        }

        public async Task<List<TEntity>> Query()
        {
            return await Dal.Query();
        }

        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await Dal.Query(strWhere);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Dal.Query(whereExpression);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            return await Dal.Query(whereExpression, strOrderByFileds);
        }
         
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Dal.Query(whereExpression, orderByExpression, isAsc);
        }

        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            return await Dal.Query(strWhere, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return await Dal.Query(whereExpression, intTop, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            return await Dal.Query(strWhere, intTop, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await Dal.Query(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await Dal.Query(strWhere, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            return await Dal.QueryByID(objId);
        }

        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            return await Dal.QueryByID(objId, blnUseCache);
        }

        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await Dal.QueryByIDs(lstIds);
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await Dal.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<bool> Update(TEntity model)
        {
            return await Dal.Update(model);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await Dal.Update(entity, strWhere);
        }

        public async Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            return await Dal.Update(entity, lstColumns, lstIgnoreColumns, strWhere);
        }
    }
}
