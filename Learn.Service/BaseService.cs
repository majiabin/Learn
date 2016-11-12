using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Learn.DataFactory;
using Learn.IData;
using Learn.IService;

namespace Learn.Service
{
    public abstract partial class BaseService<T> : IBaseService<T> where T : class
    {
        public IDBSession dbSession = DBSessionContextFactory.GetSession();

        public IBaseRepository<T> CurrentService;
        public BaseService()
        {
            SetCurrentDal();
        }
        public abstract void SetCurrentDal();


        #region 添加
        public bool Add(T entity)
        {
            return CurrentService.Add(entity);
        }
        #endregion

        #region 编辑

        public bool Edit(T entity)
        {
            return CurrentService.Edit(entity);
        }

        #endregion

        #region 删除
        public bool Remove(T entity)
        {
            return CurrentService.Remove(entity);
        }

        public bool Remove(int id)
        {
            return CurrentService.Remove(id);
        }

        public bool Remove(int[] ids)
        {
            return CurrentService.Remove(ids);
        }
        #endregion

        #region 查找
        public IQueryable<T> Where(Expression<Func<T, bool>> whereLamada)
        {
            return CurrentService.Where(whereLamada);
        }

        public IQueryable<T> Where<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLamada, Func<T, S> orderbyLamada, bool isAsc)
        {
            return CurrentService.Where<S>(pageSize, pageIndex, out total, whereLamada, orderbyLamada, isAsc);
        }
        #endregion

        public int SaveChanges()
        {
            return dbSession.SaveChanges();
        }

    }
}
