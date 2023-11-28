using IdleOfTheAgesLib;
using IdleOfTheAgesLib.UI;

using System;
using System.Collections.Generic;

namespace IdleOfTheAges.UI {
    [Service(typeof(IElementLibrary), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class ElementLibrary : IElementLibrary {
        private struct ElementKey : IEquatable<ElementKey> {
            public Type Type { get; set; }

            public string Key { get; set; }

            public ElementKey(Type type, string key) {
                Type = type;
                Key = key;
            }

            public static implicit operator ElementKey((Type type, string Key) tuple) => new ElementKey(tuple.type, tuple.Key);

            public override readonly string ToString() => $"Type: {Type} - Key: {Key}";

            public override bool Equals(object obj) => obj is ElementKey key && Equals(key);
            public bool Equals(ElementKey other) => EqualityComparer<Type>.Default.Equals(Type, other.Type) && Key == other.Key;
            public override int GetHashCode() => HashCode.Combine(Type, Key);

            public static bool operator ==(ElementKey left, ElementKey right) => left.Equals(right);
            public static bool operator !=(ElementKey left, ElementKey right) => !(left == right);
        }

        private readonly Dictionary<ElementKey, Type> elementDictionary = new();

        public Result<TElement> GetElement<TElement>(string key = null) where TElement : IElement => new((TElement)GetElement(typeof(TElement), key).Value);
        
        public Result<IElement> GetElement(Type interfaceType, string key = null) {
            if(elementDictionary.TryGetValue((interfaceType, key), out var type)) {
                var element = (IElement)Activator.CreateInstance(type);
                return new Result<IElement>(element);
            }

            return (null, $"No element registered for {(interfaceType, key)}");
        }

        public Result RegisterElement<TInterface, TElement>(string key = null)
            where TInterface : IElement
            where TElement : Element => RegisterElement(typeof(TInterface), typeof(TElement), null);

        public Result RegisterElement(Type interfaceType, Type elementType, string key = null) {
            if (!interfaceType.IsInterface) {
                return (false, $"Type {interfaceType.FullName} is not an interface!", new ArgumentException(nameof(interfaceType)));
            }

            if (elementType.IsInterface || elementType.IsAbstract) {
                return (false, $"Type {elementType.FullName} is an interface or an abstract class", new ArgumentException(nameof(elementType)));
            }

            elementDictionary[(interfaceType, key)] = elementType;

            return true;
        }
    }
}
