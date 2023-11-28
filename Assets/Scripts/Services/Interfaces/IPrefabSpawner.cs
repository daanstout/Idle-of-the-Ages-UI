using UnityEngine;

namespace IdleOfTheAges.Prefabs {
    public interface IPrefabSpawner {
        GameObject SpawnPrefab(string prefabPath);
    }
}
