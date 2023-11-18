using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;

using System.Collections.Generic;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    /// <summary>
    /// The sidebar of the game.
    /// </summary>
    [UIElement]
    public class SidebarElement : Element<ScrollView>, ISidebarElement {

        private readonly List<SkillSidebarElement> skillSidebarElements = new();
        private readonly ISkillService skillService;
        private readonly IElementLibrary elementLibrary;

        /// <summary>
        /// Instantiates the sidebar of the game.
        /// </summary>
        public SidebarElement(ISkillService skillService, IElementLibrary elementLibrary) : base() {
            this.skillService = skillService;
            this.elementLibrary = elementLibrary;
        }

        /// <inheritdoc/>
        protected override ScrollView RebuildInternal() {
            var target = base.RebuildInternal();

            target.style.width = 210;

            target.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            target.verticalScrollerVisibility = ScrollerVisibility.Auto;
            skillSidebarElements.Clear();
            target.style.flexDirection = FlexDirection.Row;
            target.style.minWidth = 100;
            target.style.maxWidth = 500;

            foreach (var skill in skillService.GetSkills().Value) {
                var model = new SkillSidebarModel {
                    SkillID = skill.NamespacedID,
                    SkillLevel = skill.CurrentSkillLevel,
                    SkillMaxLevel = skill.MaxSkillLevel,
                    SkillThumbnail = skill.SkillData.Thumbnail,
                    SkillTranslationKey = skill.SkillData.TranslationKey
                };

                SkillSidebarElement sidebarElement = elementLibrary.Create<SkillSidebarElement>($"SKILL_SIDEBAR_{skill.NamespacedID}");
                sidebarElement.Initialize(model);
                skillSidebarElements.Add(sidebarElement);

                target.Add(sidebarElement.Rebuild());
            }

            return target;
        }
    }
}
