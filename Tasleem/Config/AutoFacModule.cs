using Autofac;
using Autofac.Core;
using System.Reflection;
using TasleemDelivery.Data;
using TasleemDelivery.Repository.Interfaces;
using TasleemDelivery.Repository.Repositories;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;
using TasleemDelivery.SharedValidation.CustomValidations;
using Module = Autofac.Module;

namespace TasleemDelivery.Config
{
    public class AutoFacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(Context)).InstancePerLifetimeScope();
            builder.RegisterType<UniqueAttribute>().SingleInstance();
            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(AccountRepository)).As(typeof(IAccountRepository)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AccountService).Assembly).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(DeliveryService).Assembly).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(EducationLevelService).Assembly).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(SkillService).Assembly).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(LanguageService).Assembly).InstancePerLifetimeScope();

        }
    }
}
