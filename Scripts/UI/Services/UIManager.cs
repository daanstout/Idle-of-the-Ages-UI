using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesLib.UI.Parsing.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAges.Scripts.UI.Services;

[Service<IUIManager>]
public class UIManager : IUIManager {
    private readonly IParserLibrary parserLibrary;
    private readonly IParserService parserService;

    private readonly Node rootNode = new(string.Empty);
    private readonly Dictionary<string, Node> nodes = [];

    public UIManager(IParserLibrary parserLibrary, IParserService parserService) {
        this.parserLibrary = parserLibrary;
        this.parserService = parserService;
    }

    public Result AddUI(string uiID, string parentID) {
        return true;
    }
}
