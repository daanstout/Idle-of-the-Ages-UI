using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    [UIElement]
    public class SkillView : Element<Box> {
        private readonly ISkillService skillService;
        private readonly IUIService uiService;

        public SkillView(ISkillService skillService, IUIService uiService) {
            this.skillService = skillService;
            this.uiService = uiService;
        }

        public override void Initialize() {
            skillService.CurrentlyShowingSkillChangedEvent += OnCurrentlyShowingSkillChangedEvent;
        }

        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            var skillView = uiService.GetElement($"SKILL_VIEW_{skillService.CurrentlyShowingSkill.NamespacedID}").Value;

            target.Add(skillView.Rebuild());

            return target;
        }

        private void OnCurrentlyShowingSkillChangedEvent(SkillImplementation skill) {
            Rebuild();
        }
    }
}
