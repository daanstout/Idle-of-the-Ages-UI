using IdleOfTheAges.DependencyInjection;

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.UI;

using System;
using System.Collections.Generic;

namespace IdleOfTheAges.UI {
    public class UIManagerService : IUIManagerService {
        private readonly IUIManagerService parent;
        private readonly ServiceLibrary serviceLibrary;
        private readonly Dictionary<string, IUIManager> managerInstances = new();

        public UIManagerService(IUIManagerService parent, IServiceLibrary serviceLibrary) {
            this.parent = parent;
            this.serviceLibrary = new ServiceLibrary(serviceLibrary);
        }

        public Result<TManager> GetManager<TManager>(string instanceIdentifier, string key = null) where TManager : IUIManager => (TManager)GetManager(typeof(TManager), instanceIdentifier, key);

        public Result<IUIManager> GetManager(Type managerType, string instanceIdentifier, string key = null) {
            if (!managerInstances.TryGetValue(instanceIdentifier, out var manager)) {
                if (!serviceLibrary.ContainsService(managerType, key)) {
                    if (parent != null) {
                        return parent.GetManager(managerType, instanceIdentifier, key);
                    } else {
                        return (null, $"No manager has been registered to solve for elements of type: {managerType.FullName} with key: {key}");
                    }
                }

                manager = (IUIManager)serviceLibrary.Get(managerType, key);
                managerInstances[instanceIdentifier] = manager;
            }

            return new Result<IUIManager>(manager);
        }

        public Result RegisterManager<TManagerInterface, TManagerImplementation>(string key = null) where TManagerInterface : IUIManager where TManagerImplementation : TManagerInterface 
            => RegisterManager(typeof(TManagerInterface), typeof(TManagerImplementation), key);

        public Result RegisterManager(Type managerTypeInterface, Type managerTypeImplementation, string key = null) {
            if (!managerTypeInterface.IsInterface) {
                return (false, $"{managerTypeInterface.FullName} is not an interface!", new ArgumentException(nameof(managerTypeInterface)));
            }

            if (managerTypeImplementation.IsInterface || managerTypeImplementation.IsAbstract) {
                return (false, $"{managerTypeInterface.FullName} is either an interface or an abstract class!", new ArgumentException(nameof(managerTypeInterface)));
            }

            var resolver = serviceLibrary.Bind(managerTypeInterface, key);
            resolver.IsSingleton = false;
            resolver.SetInstanceType(managerTypeImplementation);

            return true;
        }
    }
}
