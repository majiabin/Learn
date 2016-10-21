using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learn.IData
{
    public interface IBaseRepository<T>
    {
        #region 添加
        bool Add(T entity);
        #endregion

        #region 更新
        bool Edit(T entity);
        #endregion

        #region 删除
        bool Remove(T entity);
        bool Remove(int id);
        bool Remove(int[] ids);

        #endregion

        #region 查询

   
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLamada);

        IQueryable<T> GetPage<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLamada,
            Func<T, S> orderbyLamada, bool isAsc);
        #endregion
    }
}
