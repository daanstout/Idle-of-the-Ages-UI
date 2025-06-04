using ExCSS;
using IdleOfTheAges.Scripts.UI.Elements;
using IdleOfTheAgesLib.UI.Models;

namespace IdleOfTheAges.Scripts.UI.ElementBuilders;

public abstract class ElementBuilderBase {
    protected static void AddDefaultUI(UIElement uiElement, StyleData styleData) {
        foreach (var @class in uiElement.Classes) {
            foreach(var style in styleData.GetStyles(@class)) {
                SetBackground(uiElement, style);
            }
        }
    }

    private static void SetBackground(UIElement uiElement, StyleDeclaration style) {
        if (string.IsNullOrWhiteSpace(style.BackgroundColor)) {
            return;
        }
    }
}
