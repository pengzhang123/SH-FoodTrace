using FoodTrace.DBManage.Contexts;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IService;
using FoodTrace.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace FoodTrace.WebSite
{
    public class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //container.RegisterControllers();
            container.RegisterType<IEntityContext, EntityContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IAreaService, AreaService>();
            container.RegisterType<IAreaPlatService, AreaPlatService>();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<ICodeMaxService, CodeMaxService>();
            container.RegisterType<ICodeObjectService, CodeObjectService>();
            container.RegisterType<ICodeOrderService, CodeOrderService>();
            container.RegisterType<ICodeObjectService, CodeObjectService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<IUserLoginService, UserLoginService>();
            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<IDeptService, DeptService>();
            container.RegisterType<ILandBaseService, LandBaseService>();
            container.RegisterType<IMenuService, MenuService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserBaseService, UserBaseService>();
            container.RegisterType<IUserDetailService, UserDetailService>();
            container.RegisterType<IProductSpecService, ProductSpecService>();
            container.RegisterType<IProductTypeService, ProductTypeService>();
            container.RegisterType<IProductBaseService, ProductBaseService>();

            container.RegisterType<ICodeMaxService, CodeMaxService>();
            container.RegisterType<ICodeObjectService, CodeObjectService>();
            container.RegisterType<ICodeOrderService, CodeOrderService>();
            return container;
        }

        public static T Resolve<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }
    }
}