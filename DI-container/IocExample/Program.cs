using IocExample.Classes;
using System;
using Ninject;

namespace IocExample
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var logger = new ConsoleLogger();
        //    var sqlConnectionFactory = new SqlConnectionFactory("SQL Connection", logger);
        //    var createUserHandler = new CreateUserHandler(new UserService(new QueryExecutor(sqlConnectionFactory),
        //                                                                    new CommandExecutor(sqlConnectionFactory),
        //                                                                    new CacheService(logger,
        //                                                                    new RestClient("API KEY"))), logger);

        //    createUserHandler.Handle();
        //    Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{
        //    IKernel kernel = new StandardKernel();
        //    kernel.Bind<CreateUserHandler>().To<CreateUserHandler>();

        //    kernel.Bind<IConnectionFactory>()
        //        .ToConstructor(k => new SqlConnectionFactory("SQL Connection", k.Inject<ILogger>()))
        //        .InSingletonScope();
        //    kernel.Bind<ILogger>().To<ConsoleLogger>()
        //        .InSingletonScope();
        //    kernel.Bind<QueryExecutor>().To<QueryExecutor>();
        //    kernel.Bind<CommandExecutor>().To<CommandExecutor>();
        //    kernel.Bind<RestClient>()
        //        .ToConstructor(k => new RestClient("API KEY"));
        //    kernel.Bind<CacheService>().To<CacheService>();


        //    var createUserHandler = kernel.Get<CreateUserHandler>();

        //    createUserHandler.Handle();
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<CreateUserHandler>().To<CreateUserHandler>();

            //kernel.Bind<IConnectionFactory>()
            //    .ToConstructor(k => new SqlConnectionFactory("SQL Connection", k.Inject<ILogger>()))
            //    .InSingletonScope();
            //kernel.Bind<ILogger>().To<ConsoleLogger>()
            //    .InSingletonScope();
            //kernel.Bind<QueryExecutor>().To<QueryExecutor>();
            //kernel.Bind<CommandExecutor>().To<CommandExecutor>();
            //kernel.Bind<RestClient>()
            //    .ToConstructor(k => new RestClient("API KEY"));
            //kernel.Bind<CacheService>().To<CacheService>();


            var myKernel = new MyKernel();
            myKernel.Bind<CreateUserHandler,CreateUserHandler>();
            myKernel.Bind<UserService, UserService>();
            myKernel.BindToConstructor<IConnectionFactory>(() => new SqlConnectionFactory("SQL Connection", myKernel.Get<ILogger>()));
            myKernel.Bind<ILogger, ConsoleLogger>();
            myKernel.Bind<QueryExecutor, QueryExecutor>();
            myKernel.Bind<CommandExecutor, CommandExecutor>();
            myKernel.BindToConstructor<RestClient>(() => new RestClient("API KEY"));
            myKernel.Bind<CacheService, CacheService>();


            var createUserHandler = myKernel.Get<CreateUserHandler>();

            createUserHandler.Handle();
            Console.ReadKey();


        }

    }
}
