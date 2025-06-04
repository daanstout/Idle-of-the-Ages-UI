using HtmlAgilityPack;
using IdleOfTheAges.Scripts.UI.Elements;
using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI.Attributes;
using IdleOfTheAgesLib.UI.Models;
using System.Linq;

namespace IdleOfTheAges.Scripts.UI.ElementBuilders;

[ElementBuilder(ElementName = "div")]
public class DivBuilder : ElementBuilderBase, IElementBuilder {
    public Result<IUIElement> Build(HtmlNode html, StyleData styleData) {
        var uiElement = new UIElement() {
            ID = html.Id,
            Classes = html.GetClasses().ToArray()
        };

        AddDefaultUI(uiElement, styleData);

        return uiElement;
    }
}
