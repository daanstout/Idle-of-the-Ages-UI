using IdleOfTheAgesLib.UI.Models;
using System.Collections.Generic;

namespace IdleOfTheAges.Scripts.UI.Elements;

public class UIElement : IUIElement {
    public string ID { get; init; }

    public IReadOnlyCollection<string> Classes { get; init; } = [];

    public List<IUIElement> Children { get; } = [];

    
}
