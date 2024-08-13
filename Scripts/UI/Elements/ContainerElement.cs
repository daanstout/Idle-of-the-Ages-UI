using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI.Elements;
using IdleOfTheAgesLib.UI.Parsing.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAges.Scripts.UI.Elements;

public class ContainerElement : ElementManager {
    public override Result<object> ConstructObject(Node node, UIContext context) {
        return new(null);
    }
}
