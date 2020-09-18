using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Phonebook.Data.Services;

namespace Phonebook.API
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SqlContactData>().As<IContactData>().InstancePerRequest();
            builder.RegisterType<PhonebookDbContext>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}