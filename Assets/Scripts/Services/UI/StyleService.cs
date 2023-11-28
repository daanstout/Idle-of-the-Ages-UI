using IdleOfTheAges.UI.Styles;

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;
using IdleOfTheAgesLib.UI.Styles;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.Collections.Generic;

namespace IdleOfTheAges.UI {
    [Service(typeof(IStyleService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class StyleService : IStyleService {
        private static readonly JsonSerializerSettings settings = new() {
            ContractResolver = new DefaultContractResolver {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };
        private readonly Dictionary<string, StyleCollection> styleCollections = new();

        public Result AddStyle(string identifier, string json) {
            var style = JsonConvert.DeserializeObject<StyleEntry>(json, settings);

            if (styleCollections.TryGetValue(style.Name, out var collection)) {
                collection.AddStyle(style);
            }else if(styleCollections.TryGetValue(style.LinkedStyle, out collection)) {
                var clone = collection.Clone();
                clone.AddStyle(style);
                styleCollections.Add(style.Name, clone);
            } else {
                styleCollections.Add(style.Name, new StyleCollection(style));
            }

            return true;
        }

        public Result<IStyleEntry> GetStyle(string style) => styleCollections[style];
    }
}
