using IdleOfTheAges.Prefabs;

using IdleOfTheAgesLib.Translation;

using IdleOfTheAgesRuntime;

using System.IO;
using System.Reflection;

using UnityEngine;

namespace IdleOfTheAges {
    /// <summary>
    /// Main application class of the runtime.
    /// </summary>
    public class Application : MonoBehaviour {
        private App app;

        private void Awake() {
            app = new App();
        }

        private void Start() {
            app.Initialize(Assembly.GetExecutingAssembly());
            app.LoadMods(Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods"));
            app.GameLoaded();

            app.ServiceLibrary.Get<ITranslationService>().ChangeLanguage(Language.EN_US);
            app.ServiceLibrary.Get<IPrefabSpawner>().SpawnPrefab("UIRoot");
        }
    }
}
