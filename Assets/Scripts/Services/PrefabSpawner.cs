using IdleOfTheAges.DependencyInjection;

using IdleOfTheAgesLib;

using UnityEngine;

namespace IdleOfTheAges.Prefabs {
    [Service(typeof(IPrefabSpawner), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class PrefabSpawner : IPrefabSpawner {
        private readonly IDependencyInjector dependencyInjector;

        public PrefabSpawner(IDependencyInjector dependencyInjector) {
            this.dependencyInjector = dependencyInjector;
        }

        public GameObject SpawnPrefab(string prefabPath) {
            var prefab = Resources.Load<GameObject>(prefabPath);

            prefab.SetActive(false);

            var instance = Object.Instantiate(prefab);
            dependencyInjector.InjectDependencies(instance);
            prefab.SetActive(true);
            instance.SetActive(true);

            return instance;
        }
    }
}
