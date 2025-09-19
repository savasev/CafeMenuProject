using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete;
using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.DataAccess.Concrete;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace CafeMenuProject.WebUI.App_Start
{
    /// <summary>
    /// Dependency injection config
    /// </summary>
    public static class DependencyInjectionConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();

            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>), new HierarchicalLifetimeManager());

            container.RegisterType<ICategoryService, CategoryService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPropertyService, PropertyService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductPropertyService, ProductPropertyService>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
