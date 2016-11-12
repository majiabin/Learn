using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Data;
using Learn.Data.Context;
using Learn.IData;

namespace Learn.DataFactory
{
    public partial class DBSession : IDBSession
    {
        # region 此处由T4自动生成

                //public IDepartmentRepository DepartmentRepository
                //{
                //    get
                //    {
                //        return new DepartmentRepository();
                //    }
                //}

                //public IRoleRepository RoleRepository
                //{
                //    get
                //    {
                //        return new RoleRepository();
                //    }
                //}

                //public IEmployeeRepository EmployeeRepository {
                //    get
                //    {
                //        return new EmployeeRepository();
                //    }
                //}

                //public IPermissionRepository PermissionRepository {
                //    get
                //    {
                //        return new PermissionRepository();

                //    }
                //}

        # endregion

        public int SaveChanges()
        {
            IDbContext dbContext = ContextFactory.GetContext();
            return dbContext.SaveChanges();
        }
    }
}
