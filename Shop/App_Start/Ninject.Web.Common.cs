[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Shop.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Shop.App_Start.NinjectWebCommon), "Stop")]

namespace Shop.App_Start
{
    using System;
    using System.Web;
    using Shop.DataLayer;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Shop.BuisnessLayer.ProductHandler;
    using Shop.Identity;
    using Shop.BusinessLayer.Accounts.Handlers;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                var config = StartupConfig.Config;

                // Install our Ninject-based IDependencyResolver into the Web API config
                config.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<dbcont>().To<dbcont>().InRequestScope();
            kernel.Bind<UnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IIdentityService>().To<AspNetIdentityService>().InRequestScope();
            kernel.Bind<IIdentityStorage>().To<AspNetIdentityStorage>().InRequestScope();

        }
    }
}