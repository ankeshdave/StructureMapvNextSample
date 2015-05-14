using Microsoft.Framework.DependencyInjection;

namespace Sample.DN46.StructureMap
{
    public static class StructureMapRegistration
    {
        public static void Populate(this global::StructureMap.IContainer container, IServiceCollection serviceCollection)
        {
            var populator = new StructureMapPopulator(container);
            populator.Populate(serviceCollection);
        }
    }
}