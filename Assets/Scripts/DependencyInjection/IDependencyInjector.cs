using UnityEngine;

namespace IdleOfTheAges.DependencyInjection {
    public interface IDependencyInjector {
        void InjectDependencies(object target);
        void InjectDependencies(GameObject gameObject);
    }
}