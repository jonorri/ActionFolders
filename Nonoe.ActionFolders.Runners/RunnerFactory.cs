namespace Nonoe.ActionFolders.Runners
{
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;

    public static class RunnerFactory
    {
        /// <summary>
        /// Contains the catalog of MEF exports for the assembly.
        /// </summary>
        private static readonly AssemblyCatalog Catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());

        /// <summary>
        /// The composition container used to create MEF exports from.
        /// </summary>
        private static readonly CompositionContainer Container = new CompositionContainer(Catalog, true);

        /// <summary>
        /// GetHandler returns a reward handler for the appropriate reward name
        /// </summary>
        /// <param name="name">The reward handler name to get.</param>
        /// <returns>The reward handler for the requested reward name.</returns>
        public static IScriptRunner GetHandler(string name)
        {
            return Container.GetExportedValueOrDefault<IScriptRunner>(name);
        }
    }
}


