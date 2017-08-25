using Microsoft.Practices.Unity;
using PrimerIndividual.Repository;
using PrimerIndividual.Service;
using System.Web.Http;
using Unity.WebApi;

namespace PrimerIndividual
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<PeliculaRepository, PeliculaRepository>();
            //Añadimos Metiendole el Interception
            container.RegisterType<IPeliculaService, PeliculaService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IEntradaRepository, EntradaRepository>();
            container.RegisterType<IEntradaService, EntradaService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<ICuentaBancariaRepository, CuentaBancariaRepository>();
            container.RegisterType<ICuentaBancariaService, CuentaBancariaService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}