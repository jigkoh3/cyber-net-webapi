using BLL.Service;
//using BLL.Service.Interface;
using DAL.Data;
using DAL.Repository;
using DAL.Repository.Providers.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using PL.WebAPI.Controllers;
using PL.WebAPI.Models;
using System.Web.Http;
using Unity.WebApi;

namespace PL.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType<IBaseService, BaseService>();

            //TODO Dependency Injection Example
            //container.RegisterType<IUserService, UserService>();

            container.RegisterType<IDbContext, DataContext>("DefaultConnection");
            container.RegisterType<IUnitOfWork, UnitOfWork>("UnitOfWork", new HierarchicalLifetimeManager(),
                new InjectionConstructor(new ResolvedParameter<IDbContext>("DefaultConnection")));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}