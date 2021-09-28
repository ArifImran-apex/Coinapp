using Autofac;
using CoinApp.Services;
using CoinApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinApp.Helper
{
    public class AppContainer
    {
        private static IContainer container;

        public AppContainer()
        {
            // services
            var builder = new ContainerBuilder();
            builder.RegisterType<CoinService>().As<ICoinService>().SingleInstance();
            builder.RegisterType<CoinListingsPageViewModel>().SingleInstance();
            container = builder.Build();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);
    }
}
