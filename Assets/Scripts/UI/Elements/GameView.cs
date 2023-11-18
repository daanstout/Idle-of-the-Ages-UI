using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    [UIElement]
    public class GameView : Element<Box> {
        private readonly TwoPaneSplitView splitView = new(0, 200, TwoPaneSplitViewOrientation.Horizontal);
        private SidebarElement sidebarElement;
        private SkillView skillView;

        private readonly IElementLibrary elementLibrary;

        public GameView(IElementLibrary elementLibrary) {
            this.elementLibrary = elementLibrary;
        }

        public override void Initialize() {
            sidebarElement = elementLibrary.Create<SidebarElement>("Side Bar");
            skillView = elementLibrary.Create<SkillView>("Skill View");
        }

        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.StretchToParentSize();

            splitView.Clear();
            splitView.Add(sidebarElement.Rebuild());
            splitView.Add(skillView.Rebuild());

            target.Add(splitView);

            splitView.StretchToParentSize();

            return target;
        }
    }
}
