using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;

using System;
using System.Collections.Generic;

namespace IdleOfTheAges.Services {
    [Service(typeof(IModLibrary), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    internal class ModLibrary : IModLibrary {
        private readonly Dictionary<string, IModObject> loadedMods = new();

        public Result<IModObject> GetModObject(string @namespace) {
            if (string.IsNullOrWhiteSpace(@namespace)) {
                return (null, "Namespace is empty!", new ArgumentNullException(nameof(@namespace)));
            }

            if (loadedMods.TryGetValue(@namespace, out var result)) {
                return new Result<IModObject>(result);
            }

            return (null, $"No mod registered with namespace {@namespace}", new ArgumentException());
        }

        public Result ModExists(string @namespace) => loadedMods.ContainsKey(@namespace);

        public Result RegisterMod(string @namespace, IModObject modObject) {
            loadedMods.Add(@namespace, modObject);
            return true;
        }
    }
}
