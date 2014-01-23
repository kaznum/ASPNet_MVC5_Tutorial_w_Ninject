[assembly: WebActivator.PreApplicationStartMethod(typeof(MvcMovie.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MvcMovie.App_Start.NinjectWebCommon), "Stop")]

namespace MvcMovie.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using MvcMovie.Services;
    using AddressBookManagerDomain.Contexts;
    using AddressBookManagerDomain.Repositories;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IMessageService>().To<MessageService>();
            // InRequestScope may not be needed
            // See https://github.com/ninject/Ninject.Web.Common/wiki/InRequestScope
            // InRequestScopeを使用した場合は、1リクエスト中でのKernel#Getは常に同じインスタンスを返す。
            // この場合、常に使いまわしするのであればよいが、別コネクションが必要になった場合等に対応できない。（常に同じインスタンスが返されてしまう）
            kernel.Bind<IAddressBookManagerEntities>().To<AddressBookManagerEntities>(); //.InRequestScope();
            kernel.Bind<IContextRepositories>().To<ContextRepositories>();
        }        
    }
}
