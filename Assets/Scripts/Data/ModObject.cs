using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;

namespace IdleOfTheAges.Data {
    /// <summary>
    /// Contains all relevant mod data.
    /// </summary>
    internal class ModObject : IModObject {
        /// <inheritdoc/>
        public string Namespace { get; set; } = string.Empty;

        /// <inheritdoc/>
        public IMod Mod { get; set; } = null!;

        /// <inheritdoc/>
        public ILogger Logger { get; set; } = null!;

        /// <inheritdoc/>
        public IServiceLibrary ServiceLibrary { get; set; } = null!;

        public IServiceRegistry ServiceRegistry { get; set; } = null!;

        public void Init() {
            ServiceLibrary.Bind<IModObject>().ToInstance(this);
            ServiceLibrary.Bind<ILogger>().ToInstance(Logger);
        }
    }
}
