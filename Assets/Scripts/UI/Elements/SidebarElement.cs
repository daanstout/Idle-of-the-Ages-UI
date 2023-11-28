using IdleOfTheAgesLib.Attributes;
using IdleOfTheAgesLib.Skills;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

using System.Collections.Generic;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Elements {
    /// <summary>
    /// The sidebar of the game.
    /// </summary>
    [UIElement(typeof(ISidebarElement))]
    public class SidebarElement : Element<ScrollView, SidebarElementModel>, ISidebarElement {
        /// <inheritdoc/>
        protected override ScrollView RebuildInternal() {
            var target = base.RebuildInternal();

            target.style.width = 210;

            target.horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            target.verticalScrollerVisibility = ScrollerVisibility.Auto;
            target.style.flexDirection = FlexDirection.Row;
            target.style.minWidth = 100;
            target.style.maxWidth = 500;

            foreach(var sidebarElement in Data.SkillElements) {
                target.Add(sidebarElement.GetVisualElement());
            }

            return target;
        }
    }
}
