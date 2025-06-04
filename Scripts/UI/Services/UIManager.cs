using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI.Models;
using IdleOfTheAgesLib.UI.Services;
using System.Collections.Generic;

namespace IdleOfTheAges.Scripts.UI.Services;

[Service<IUIManager>(ServiceLevel = ServiceLevelEnum.Public)]
public class UIManager : IUIManager {
    public IUIElement Root { get; }

    private readonly IUIBuilder uiBuilder;
    private readonly Dictionary<string, IUIElement> elementsWithID = [];
    private readonly List<IUIElement> elementsWithoutID = [];

    public UIManager(IUIBuilder uiBuilder) {
        this.uiBuilder = uiBuilder;
    }

    public Result<IUIElement> AddUI(string parentID, string templateID) {
        var result = uiBuilder.BuildUI(templateID);

        if (!result) {
            return result.To<IUIElement>();
        }

        return result;
    }

    public Result<IUIElement> GetUI(string id) {
        if (elementsWithID.TryGetValue(id, out var element)) {
            return new Result<IUIElement>(element);
        }

        return (null, "No element with the provided ID exists!", new KeyNotFoundException());
    }
}
