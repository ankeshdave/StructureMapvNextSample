using Microsoft.Framework.DependencyInjection;

using StructureMap;

namespace Sample.DN46.StructureMap
{
    internal class StructureMapServiceScopeFactory : IServiceScopeFactory
    {
        private readonly IContainer _container;

        public StructureMapServiceScopeFactory(IContainer container)
        {
            _container = container;
        }
        public IServiceScope CreateScope()
        {
            return new StructureMapServiceScope(_container);
        }
    }
}