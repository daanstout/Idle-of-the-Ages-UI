using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Managers;

using UnityEngine;
using UnityEngine.UIElements;

namespace IdleOfTheAges {
    public class StyleRoot : MonoBehaviour {
        private IUIManagerService uiManagerService;

        [SerializeField] private UIDocument panelSettings;

        public void InjectDependencies(IUIManagerService uiManagerService) {
            this.uiManagerService = uiManagerService;
        }

        private void Start() {
            panelSettings.rootVisualElement.Add(uiManagerService.GetManager<IGameViewManager>("Game View").Value.GetElement().GetVisualElement());
        }
    }
}
