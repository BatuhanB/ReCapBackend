using Autofac;
using Autofac.Extras.DynamicProxy;
using Businness.Abstract;
using Businness.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();//car Ioc 
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();//brand Ioc
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();//color Ioc
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();//customer Ioc
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();//user Ioc
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();//rental Ioc
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();//carImage Ioc
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<EfCartItemDal>().As<ICartItemDal>().SingleInstance();
            builder.RegisterType<CartItemManager>().As<ICartItemService>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
