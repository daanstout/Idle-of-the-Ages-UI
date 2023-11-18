using UnityEngine;

namespace IdleOfTheAges.Services {
    public interface IPrefabSpawner {
        GameObject SpawnPrefab(string prefabPath);
    }
}
