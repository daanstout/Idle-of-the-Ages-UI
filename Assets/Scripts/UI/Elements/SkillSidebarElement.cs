using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI {
    /// <summary>
    /// An element to display a skill in the sidebar the user can navigate to.
    /// </summary>
    [UIElement]
    public class SkillSidebarElement : Element<Box> {
        private readonly Image thumbnailImage = new();
        private readonly Label skillNameLabel = new();
        private readonly Label levelLabel = new();
        private readonly ITextureLibrary textureLibrary;
        private readonly ISkillService skillService;
        private readonly ITranslationService translationService;
        private SkillSidebarModel skillSidebarModel;

        /// <summary>
        /// Instantiates a new SKill Sidebar Element.
        /// </summary>
        /// <param name="gameState">The current state of the game.</param>
        public SkillSidebarElement(ITextureLibrary textureLibrary, ISkillService skillService, ITranslationService translationService) : base() {
            this.textureLibrary = textureLibrary;
            this.skillService = skillService;
            this.translationService = translationService;

            RegisterCallback<ClickEvent>(OnElementClicked);
        }

        public void Initialize(SkillSidebarModel skillSidebarModel) {
            this.skillSidebarModel = skillSidebarModel;
        }

        /// <inheritdoc/>
        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            //target.style.height = 100;

            thumbnailImage.image = textureLibrary.GetTexture(skillSidebarModel.SkillThumbnail);
            thumbnailImage.style.height = 30;
            thumbnailImage.style.width = 30;
            target.Add(thumbnailImage);

            skillNameLabel.text = translationService.GetLanguageString(skillSidebarModel.SkillTranslationKey);
            //skillNameLabel.style.width = 100;
            target.Add(skillNameLabel);

            target.style.flexDirection = FlexDirection.Row;

            levelLabel.text = $"{skillSidebarModel.SkillLevel}/{skillSidebarModel.SkillMaxLevel}";

            return target;
        }

        private void OnElementClicked(ClickEvent args) {
            skillService.ChangeShowingSkill(skillSidebarModel.SkillID);
        }
    }
}
