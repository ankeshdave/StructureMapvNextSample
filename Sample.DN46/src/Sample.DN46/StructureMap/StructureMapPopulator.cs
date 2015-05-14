using System;

using Microsoft.Framework.DependencyInjection;

using StructureMap;
using StructureMap.Configuration.DSL.Expressions;

namespace Sample.DN46.StructureMap
{
    internal class StructureMapPopulator
    {
        private readonly IContainer _container;

        public StructureMapPopulator(IContainer container)
        {
            _container = container;
        }

        public void Populate(IServiceCollection serviceCollection)
        {
            _container.Configure(c =>
            {
                c.For<IServiceProvider>().Use(new StructureMapServiceProvider(_container));
                c.For<IServiceScopeFactory>().Use<StructureMapServiceScopeFactory>();

                foreach (var serviceDescriptor in serviceCollection)
                {
                    switch (serviceDescriptor.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            Use(c.For(serviceDescriptor.ServiceType).Singleton(), serviceDescriptor);
                            break;
                        case ServiceLifetime.Transient:
                            Use(c.For(serviceDescriptor.ServiceType), serviceDescriptor);
                            break;
                        case ServiceLifetime.Scoped:
                            Use(c.For(serviceDescriptor.ServiceType), serviceDescriptor);
                            break;
                    }
                }
            });
        }
        private void Use(GenericFamilyExpression expression, ServiceDescriptor serviceDescriptor)
        {
            if (serviceDescriptor.ImplementationFactory != null)
            {
                expression.Use(Guid.NewGuid().ToString(), context => serviceDescriptor.ImplementationFactory(context.GetInstance<IServiceProvider>()));
            }
            else if (serviceDescriptor.ImplementationInstance != null)
            {
                expression.Use(serviceDescriptor.ImplementationInstance);
            }
            else if (serviceDescriptor.ImplementationType != null)
            {
                expression.Use(serviceDescriptor.ImplementationType);
            }
            else
            {
                throw new InvalidOperationException("the ServiceDescriptor isnt valid");
            }
        }

    }
}