using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Managers;
using IdleOfTheAgesLib.UI.Models;

using System.Collections.Generic;

using UnityEngine;

namespace IdleOfTheAges.UI.Managers {
    [UIManager(typeof(ISidebarManager))]
    public class SidebarManager : ISidebarManager {
        private readonly IElementLibrary elementLibrary;
        private readonly ISkillService skillService;
        private readonly IUIManagerService uiManagerService;
        private readonly ITextureLibrary textureLibrary;
        private readonly ITranslationService translationService;

        public SidebarManager(IElementLibrary elementLibrary, ISkillService skillService, IUIManagerService uiManagerService, ITextureLibrary textureLibrary, ITranslationService translationService) {
            this.elementLibrary = elementLibrary;
            this.skillService = skillService;
            this.uiManagerService = uiManagerService;
            this.textureLibrary = textureLibrary;
            this.translationService = translationService;
        }

        IElement IUIManager.GetElement() => GetElement();

        public ISidebarElement GetElement() {
            var sidebar = elementLibrary.GetElement<ISidebarElement>().Value;

            List<ISkillSidebarElement> sidebarElements = new List<ISkillSidebarElement>();

            foreach(var skill in skillService.GetSkills().Value) {
                var sidebarElement = elementLibrary.GetElement<ISkillSidebarElement>().Value;

                sidebarElement.SkillClickedEvent += OnSkillClickedEvent;

                sidebarElement.Initialize(new SkillSidebarModel {
                    SkillID = skill.NamespacedID,
                    SkillLevel = skill.CurrentSkillLevel,
                    SkillMaxLevel = skill.MaxSkillLevel,
                    SkillThumbnail = textureLibrary.GetTexture(skill.SkillData.Thumbnail),
                    SkillDisplayText = translationService.GetLanguageString(skill.SkillData.TranslationKey)
                });

                sidebarElements.Add(sidebarElement);
            }

            var sidebarModel = new SidebarElementModel(sidebarElements);

            sidebar.Initialize(sidebarModel);

            return sidebar;
        }

        private void OnSkillClickedEvent(string skillID) {
            Debug.Log(skillID);
            skillService.ChangeShowingSkill(skillID);
        }
    }
}
