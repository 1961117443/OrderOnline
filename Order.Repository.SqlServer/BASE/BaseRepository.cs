﻿using Order.IRepository.BASE;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Repository.SqlSugar.BASE
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<TEntity> entityDB;

        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }

        public SqlSugarClient Db { get => db; set => db = value; }
        public SimpleClient<TEntity> EntityDB { get => entityDB; set => entityDB = value; }

        public BaseRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<TEntity>();
        }

        public async Task<int> Add(TEntity model)
        {
            //   Task.Run(()=>db.Insertable(model).executer)
            var i = await db.Insertable(model).ExecuteReturnBigIdentityAsync();
            return (int)i;
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await Task.Run(() => entityDB.Delete(model));
        }

        public async Task<bool> DeleteById(object id)
        {
            return await Task.Run(() => entityDB.DeleteById(id));
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await Task.Run(() => entityDB.DeleteByIds(ids));
        }

        public async Task<List<TEntity>> Query()
        {
            return await Task.Run(() => entityDB.GetList());
        }

        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await Task.Run(() => db.Queryable<TEntity>().WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
        }

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            var entity = await Task.Run(() => db.Queryable<TEntity>()
             .WhereIF(whereExpression != null, whereExpression)
             .OrderByIF(orderByExpression != null, orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc)
             .First());
            return entity;
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {

            var list = await Task.Run(() => entityDB.GetList(whereExpression));
            return list;
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {

            var list = await Task.Run(() => db.Queryable<TEntity>().Where(whereExpression).OrderBy(orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).ToList());
            return list;
        }

        public Task<List<TEntity>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryByID(object objId)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await Task.Run(() => db.Queryable<TEntity>().Where(whereExpression).OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).ToPageList(intPageIndex, intPageSize));
        }

        public async Task<bool> Update(TEntity model)
        {
            return await Task.Run(() => db.Updateable<TEntity>(model).ExecuteCommand() > 0);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await Task.Run(() => db.Updateable<TEntity>(entity).Where(strWhere).ExecuteCommand() > 0);
        }

        public async Task<bool> Update(TEntity entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            IUpdateable<TEntity> up = await Task.Run(() => db.Updateable<TEntity>(entity));
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = await Task.Run(() => up.IgnoreColumns(w => lstIgnoreColumns.Contains(w)));
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = await Task.Run(() => up.UpdateColumns(w => lstColumns.Contains(w)));
            }
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                up = await Task.Run(() => up.Where(strWhere));
            }
            // var t=await StartAsync(() => up.ExecuteCommand() > 0);
            return await Task.Run(() => up.ExecuteCommand() > 0);
        }

        protected Task<T> StartAsync<T>(Func<T> func)
        {
            return Task.Run(() => func());
        }

        public int Count()
        {
            return entityDB.Count(w => 1 == 1);
        }

        public int Count(Expression<Func<TEntity, bool>> whereExpression)
        {
            return entityDB.Count(whereExpression);
        }

        public async Task<int> CountAsync()
        {
            return await Task.Run(() => entityDB.Count(w => 1 == 1));
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Task.Run(() => entityDB.Count(whereExpression));
        }
    }
}