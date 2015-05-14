using System;

using Microsoft.Framework.DependencyInjection;

using StructureMap;

namespace Sample.DN46.StructureMap
{
    internal class StructureMapServiceScope : IServiceScope
    {
        private readonly IContainer _container;
        private readonly IContainer _childContainer;
        private IServiceProvider _provider;
        private IServiceScope _fallbackScope;

        public StructureMapServiceScope(IContainer container)
        {
            _container = container;
            _childContainer = _container.GetNestedContainer();
            _provider = new StructureMapServiceProvider(_childContainer, true);
        }

        public IServiceProvider ServiceProvider => _provider;

        public void Dispose()
        {
            _provider = null;
            _childContainer?.Dispose();
        }
    }
}