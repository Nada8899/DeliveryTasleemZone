using Autofac;
using Autofac.Core;
using System.Reflection;
using TasleemDelivery.Data;
using TasleemDelivery.Repository.Interfaces;
using TasleemDelivery.Repository.Repositories;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;
using Module = Autofac.Module;

namespace TasleemDelivery.Config
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Context)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AccountRepository)).As(typeof(IAccountRepository)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly).InstancePerLifetimeScope();
        }
    }
}
