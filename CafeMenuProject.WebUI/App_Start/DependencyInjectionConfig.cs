using CafeMenuProject.Business.Abstract;
using CafeMenuProject.Business.Concrete;
using CafeMenuProject.DataAccess.Abstract;
using CafeMenuProject.DataAccess.Concrete;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

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

            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IPropertyService, PropertyService>();
            container.RegisterType<IProductPropertyService, ProductPropertyService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
