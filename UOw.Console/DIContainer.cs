using Autofac;
using UOW;
using UOW.Repository;

namespace UOw.Console
{
    public static class DIContainer
    {
        public static IContainer Build()
        {
            var container = new ContainerBuilder();
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            container.RegisterType<Repository>().As<IRepository>();
            container.RegisterType<BankAccountService>().As<IBankAccountService>();

            return container.Build();
        }
    }
}
