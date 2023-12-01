using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Elements {
    [UIElement(typeof(ISkillView))]
    public class SkillView : Element<Box, object>, ISkillView {
        private readonly ISkillService skillService;
        private readonly IUIService uiService;

        public SkillView(ISkillService skillService, IUIService uiService) {
            this.skillService = skillService;
            this.uiService = uiService;
        }

        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            var skillView = uiService.GetElement($"SKILL_VIEW_{skillService.CurrentlyShowingSkill.NamespacedID}").Value;

            target.Add(skillView.GetVisualElement());

            return target;
        }

        private void OnCurrentlyShowingSkillChangedEvent(SkillImplementation skill) {
            RebuildInternal();
        }
    }
}
