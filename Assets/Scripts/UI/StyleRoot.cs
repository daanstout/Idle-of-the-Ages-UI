using IdleOfTheAgesLib.Services.UI;

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    public class StyleRoot : MonoBehaviour
    {
        private IElementLibrary elementLibrary;

        [SerializeField] private UIDocument panelSettings;

        public void InjectDependencies(IElementLibrary elementLibrary) {
            this.elementLibrary = elementLibrary;
        }

        private void Start() {
            panelSettings.rootVisualElement.Add(elementLibrary.Create<GameView>("Game View").Value.Rebuild());
        }
    }
}
