using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Elements {
    [UIElement(typeof(IGameViewElement))]
    public class GameView : Element<Box, GameViewModel>, IGameViewElement {
        private readonly TwoPaneSplitView splitView = new(0, 200, TwoPaneSplitViewOrientation.Horizontal);
        private SidebarElement sidebarElement;
        private SkillView skillView;
        private GameViewModel gameViewModel;


        public override void Initialize() {
            //sidebarElement = elementLibrary.Create<SidebarElement>("Side Bar");
            //skillView = elementLibrary.Create<SkillView>("Skill View");
        }

        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            target.StretchToParentSize();

            splitView.Clear();
            splitView.Add(Data.SidebarElement.GetVisualElement());
            splitView.Add(new Box());
            //splitView.Add(sidebarElement.g);
            //splitView.Add(skillView.Rebuild());

            target.Add(splitView);

            splitView.StretchToParentSize();

            return target;
        }
    }
}
