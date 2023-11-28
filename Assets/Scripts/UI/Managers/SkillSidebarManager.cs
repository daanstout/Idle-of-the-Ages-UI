using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;

namespace IdleOfTheAges.UI.Managers {
    [UIManager(typeof(ISkillSidebarManager))]
    public class SkillSidebarManager : ISkillSidebarManager {
        private readonly IElementLibrary elementLibrary;

        public SkillSidebarManager(IElementLibrary elementLibrary) {
            this.elementLibrary = elementLibrary;
        }

        IElement IUIManager.GetElement() => GetElement();

        public ISkillSidebarElement GetElement() {
            return elementLibrary.GetElement<ISkillSidebarElement>().Value;
        }
    }
}
