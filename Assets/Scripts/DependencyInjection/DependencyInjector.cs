using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;

using UnityEngine;

namespace IdleOfTheAges.DependencyInjection {
    [Service(typeof(IDependencyInjector), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class DependencyInjector : IDependencyInjector {
        private readonly IServiceLibrary serviceLibrary;

        public DependencyInjector(IServiceLibrary serviceLibrary) {
            this.serviceLibrary = serviceLibrary;
        }

        public void InjectDependencies(object target) {
            var type = target.GetType();

            var method = type.GetMethod("InjectDependencies");

            if (method == null) {
                return;
            }

            var parameters = serviceLibrary.GetInstances(method.GetParameters());

            method.Invoke(target, parameters);
        }

        public void InjectDependencies(GameObject gameObject) {
            foreach(var behaviour in gameObject.GetComponentsInChildren<MonoBehaviour>()) {
                InjectDependencies(behaviour);
            }
        }
    }
}
