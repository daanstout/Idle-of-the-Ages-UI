using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Parsing;
using Node = IdleOfTheAgesLib.UI.Parsing.Trees.Node;

namespace IdleOfTheAges.Scripts.UI.Elements;

[ElementManager("model")]
public class ModelElement : ElementManager {
    private readonly IParserLibrary parserLibrary;

    public ModelElement(IParserLibrary parserLibrary) : base() {
        this.parserLibrary = parserLibrary;
    }

    public override Result Initialize(Node node, UIContext context) {
        if (!node.Metadata.TryGetValue("type", out string modelName)) {
            return (false, "No model type has been provided!");
        }

        var result = parserLibrary.GetUIModel(modelName);

        if (!result) {
            return (false, result.Errors);
        }

        if (!context.SetUIModel(result.Value)) {
            return (false, "Unable to set UI model");
        }

        return true;
    }
}
