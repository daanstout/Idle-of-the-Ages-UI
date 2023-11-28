using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using System;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Elements {
    /// <summary>
    /// An element to display a skill in the sidebar the user can navigate to.
    /// </summary>
    [UIElement(typeof(ISkillSidebarElement))]
    public class SkillSidebarElement : Element<Box, SkillSidebarModel>, ISkillSidebarElement {
        private readonly Image thumbnailImage = new();
        private readonly Label skillNameLabel = new();
        private readonly Label levelLabel = new();

        /// <summary>
        /// Instantiates a new SKill Sidebar Element.
        /// </summary>
        public SkillSidebarElement() : base() {
            RegisterCallback<ClickEvent>(OnElementClicked);
        }

        public event Action<string> SkillClickedEvent;

        /// <inheritdoc/>
        protected override Box RebuildInternal() {
            var target = base.RebuildInternal();

            thumbnailImage.image = Data.SkillThumbnail;
            thumbnailImage.style.height = 30;
            thumbnailImage.style.width = 30;
            target.Add(thumbnailImage);

            skillNameLabel.text = Data.SkillDisplayText;
            target.Add(skillNameLabel);

            target.style.flexDirection = FlexDirection.Row;

            levelLabel.text = $"{Data.SkillLevel}/{Data.SkillMaxLevel}";

            return target;
        }

        private void OnElementClicked(ClickEvent args) {
            SkillClickedEvent?.Invoke(Data.SkillID);
        }
    }
}
