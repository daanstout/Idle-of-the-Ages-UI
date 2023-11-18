using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;

using System.Collections.Generic;

namespace IdleOfTheAges.Services.UI {
    [Service(typeof(IUIService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class UIService : IUIService {
        private static readonly string ROOT_STRING = "root";

        private readonly Dictionary<string, Element> elements = new();

        public Result<Element> GetRoot() {
            if(!elements.TryGetValue(ROOT_STRING, out var element)) {
                return (null, "No root element has been registered!");
            }

            return element;
        }

        public Result AddElement(Element element, string identifier) {
            if (string.IsNullOrWhiteSpace(identifier)) {
                return (false, "The passed identifier is empty!");
            }

            if (elements.ContainsKey(identifier)) {
                return (false, $"An element with the identifier {identifier} already exists!");
            }

            elements.Add(identifier, element);

            return true;
        }

        public Result<TElement> GetElement<TElement>(string identifier) where TElement : Element => GetElement(identifier) as TElement;

        public Result<Element> GetElement(string identifier) {
            if (!elements.TryGetValue(identifier, out var element)) {
                return (null, $"No element with identifier {identifier} has been registered!");
            }

            return element;
        }
    }
}
