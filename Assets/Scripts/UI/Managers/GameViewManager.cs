using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

namespace IdleOfTheAges.UI.Managers {
    [UIManager(typeof(IGameViewManager))]
    public class GameViewManager : IGameViewManager {
        private readonly IElementLibrary elementLibrary;
        private readonly IUIManagerService uiManagerService;

        public GameViewManager(IElementLibrary elementLibrary, IUIManagerService uiManagerService) {
            this.elementLibrary = elementLibrary;
            this.uiManagerService = uiManagerService;
        }

        public IGameViewElement GetElement() {
            var gameView = elementLibrary.GetElement<IGameViewElement>().Value;

            gameView.Initialize(new GameViewModel {
                SidebarElement = uiManagerService.GetManager<ISidebarManager>("Sidebar").Value.GetElement()
            });

            return gameView;
        }

        IElement IUIManager.GetElement() => GetElement();
    }
}
