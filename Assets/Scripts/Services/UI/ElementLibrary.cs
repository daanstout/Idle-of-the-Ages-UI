using IdleOfTheAges.DependencyInjection;

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Services.UI;
using IdleOfTheAgesLib.UI;

using System;

namespace IdleOfTheAges.Services.UI {
    public class ElementLibrary : IElementLibrary {
        private readonly IElementLibrary parent;
        private readonly ServiceLibrary serviceLibrary;
        private readonly IUIService uiService;

        public ElementLibrary(IElementLibrary parent, IServiceLibrary serviceLibrary, IUIService uiService) {
            this.parent = parent;
            this.serviceLibrary = new ServiceLibrary(serviceLibrary);
            this.uiService = uiService;
        }

        public Result<TElement> Create<TElement>(string instanceIdentifier, string identifier = null) where TElement : Element {
            return (TElement)Create(typeof(TElement), instanceIdentifier, identifier);
        }

        public Result<Element> Create(Type type, string instanceIdentifier, string identifier = null) {
            if (string.IsNullOrWhiteSpace(instanceIdentifier)) {
                return (null, "Instance Identifier is empty!");
            }

            if (!serviceLibrary.ContainsService(type, identifier)) {
                return parent?.Create(type, instanceIdentifier, identifier) ?? (null, $"No element was registered for identifier {identifier}");
            }

            var instance = (Element)serviceLibrary.Get(type, identifier);

            uiService.AddElement(instance, instanceIdentifier);

            instance.Initialize();

            return instance;
        }

        public Result RegisterElement<TElement>(string identifier = null) => RegisterElement(typeof(TElement), identifier);

        public Result RegisterElement(Type type, string identifier = null) {
            serviceLibrary.Bind(type, identifier).IsSingleton = false;
            return true;
        }
    }
}
