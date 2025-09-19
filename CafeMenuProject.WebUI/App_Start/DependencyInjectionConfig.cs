using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete;
using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.DataAccess.Concrete;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace CafeMenuProject.WebUI.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();

            // Repository Binding
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));

            // Service Binding
            container.RegisterType<ICategoryService, CategoryService>();

            // Controller'larda çözümleme
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
