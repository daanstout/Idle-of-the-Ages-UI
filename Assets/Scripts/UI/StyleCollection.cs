using IdleOfTheAgesLib.UI.Styles;

using System;
using System.Collections.Generic;

using UnityEngine.UIElements;

namespace IdleOfTheAges.UI.Styles {
    public class StyleCollection : IStyleEntry{
        private readonly List<StyleEntry> styles;

        public StyleCollection() : this(Array.Empty<StyleEntry>()) { }

        public StyleCollection(params StyleEntry[] entry) {
            styles = new List<StyleEntry>(entry);
        }

        public void ApplyToStyle(IStyle style) {
            foreach (var entry in styles)
                entry.ApplyToStyle(style);
        }

        public void AddStyle(StyleEntry entry) => styles.Add(entry);

        public StyleCollection Clone() {
            var collection = new StyleCollection();
            collection.styles.AddRange(styles);
            return collection;
        }
    }
}
