using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace Learn.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoFac();
        }


        /// <summary>
        /// 使用AutoFac实现依赖注入
        /// </summary>
        private void AutoFac()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);  //注入

            builder.RegisterControllers(Assembly.GetExecutingAssembly());  //注入所有Controller

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())//注入ui层
             .AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            //UI项目只用引用service和repository的接口，不用引用实现的dll。
            //如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
            var IServices = Assembly.Load("Learn.IService");
            var Services = Assembly.Load("Learn.Service");
            var IRepository = Assembly.Load("Learn.IData");
            var Repository = Assembly.Load("Learn.Data");

            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IServices, Services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();

            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();
        }

    }




}
