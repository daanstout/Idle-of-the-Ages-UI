using HtmlAgilityPack;
using IdleOfTheAges.Scripts.UI.Elements;
using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Models;
using IdleOfTheAgesLib.UI.Models;
using IdleOfTheAgesLib.UI.Services;
using IdleOfTheAgesLib.UI.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAges.Scripts.UI.Services;

[Service<IUIBuilder>(ServiceLevel = ServiceLevelEnum.Public)]
public class UIBuilder : IUIBuilder {
    private readonly ITemplateLibrary templateLibrary;
    private readonly ICssLibrary cssLibrary;
    private readonly IElementBuilderLibrary elementBuilderLibrary;

    public UIBuilder(ITemplateLibrary templateLibrary, ICssLibrary cssLibrary, IElementBuilderLibrary elementBuilderLibrary) {
        this.templateLibrary = templateLibrary;
        this.cssLibrary = cssLibrary;
        this.elementBuilderLibrary = elementBuilderLibrary;
    }

    public Result<IUIElement> BuildUI(string templateID) {
        var template = templateLibrary.GetTemplate(templateID);

        if (!template) {
            return template.To<IUIElement>();
        }

        ResultBuilder resultBuilder = new ResultBuilder();
        UIElement templateRoot = new UIElement();

        ProcessHTML(template, resultBuilder, templateRoot);

        return templateRoot;
    }

    private void ProcessHTML(Template template, ResultBuilder resultBuilder, UIElement element) {
        Stack<(HtmlNode, UIElement)> stack = new Stack<(HtmlNode, UIElement)>();
        stack.Push((template.HtmlDocument.DocumentNode, element));

        while (stack.Count != 0) {
            (var currentNode, var currentElement) = stack.Pop();
        }
    }
}
