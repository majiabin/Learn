using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IData;

namespace Learn.Data.Context
{
    public class LearnContext : DbContext, IDbContext
    {
        static LearnContext()
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<LearnContext>());
        }
        public LearnContext() : base("carDatabase")
        {

        }

        public int ExcuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        IDbSet<T> IDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////Role表和Employee表是多对多关系
            //modelBuilder.Entity<Role>().HasMany(c => c.Employees).WithMany(a => a.Roles).Map(m =>
            //{
            //    m.ToTable("EmpRoleRelation");
            //    m.MapLeftKey("RoleId");
            //    m.MapRightKey("EmpId");
            //});
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
