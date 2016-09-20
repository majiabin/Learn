using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Data.Context;
using Learn.IData;

namespace Learn.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IDbContext dbContext = ContextFactory.GetContext();

        #region 添加
        public bool Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            return dbContext.SaveChanges() > 0;
        }
        #endregion

        #region 更新
        public bool Edit(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            return this.dbContext.SaveChanges() > 0;
        }
        #endregion

        #region 删除
        public bool Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return this.dbContext.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            T model = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(model);
            return this.dbContext.SaveChanges() > 0;
        }

        public bool Remove(int[] ids)
        {
            foreach (int item in ids)
            {
                T model = dbContext.Set<T>().Find(item);
                dbContext.Set<T>().Remove(model);
            }
            return this.dbContext.SaveChanges() > 0;
        }

        #endregion

        #region 查询
        public IQueryable<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> whereLamada)
        {
            return dbContext.Set<T>().Where(whereLamada);
        }
        public IQueryable<T> GetPage<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLamada, Func<T, S> orderbyLamada, bool isAsc)
        {
            total = dbContext.Set<T>().Where(whereLamada).Count();
            if (isAsc)
            {
                return dbContext.Set<T>().Where(whereLamada).OrderBy(orderbyLamada).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
            else
            {
                return dbContext.Set<T>().Where(whereLamada).OrderByDescending(orderbyLamada).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
        }
        #endregion
    }
}
