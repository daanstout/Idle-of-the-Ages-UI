using IdleOfTheAgesLib.DependencyInjection;

using System;

#nullable enable

namespace IdleOfTheAges.DependencyInjection {
    internal class Resolver<TType> : IResolver<TType>
        where TType : class {
        public Func<IServiceLibrary, object>? Factory { get; set; }

        public bool IsSingleton { get; set; } = true;

        private readonly Type? instanceType;

        private TType? instance;
        private bool isResolved;
        private bool isResolving;

        public Resolver() : this(typeof(TType)) { }

        public Resolver(Type? instanceType) {
            this.instanceType = instanceType;
        }

        object IResolver.Resolve(IServiceLibrary serviceLibrary) => Resolve(serviceLibrary);

        public TType Resolve(IServiceLibrary serviceLibrary) {
            if (isResolved && this.instance != null) {
                return this.instance;
            }

            if (isResolving) {
                throw new CyclicalDependencyException($"Cyclical dependency found when resolving for {GetType().FullName}");
            }

            isResolving = true;
            TType instance;

            if (Factory != null) {
                instance = (TType)Factory(serviceLibrary);
            } else if (instanceType != null) {
                var constructor = instanceType.GetConstructors()[0];

                var objects = serviceLibrary.GetInstances(constructor.GetParameters());

                instance = (TType)constructor.Invoke(objects);
            } else if (!typeof(TType).IsInterface && !typeof(TType).IsAbstract) {
                var constructor = typeof(TType).GetConstructors()[0];

                var objects = serviceLibrary.GetInstances(constructor.GetParameters());

                instance = (TType)constructor.Invoke(objects);
            } else {
                throw new InvalidOperationException($"Cannot create instance for type {typeof(TType).FullName}! No factory or instance type has been provided.");
            }

            if (IsSingleton) {
                isResolved = true;
                this.instance = instance;
            }

            isResolving = false;
            return instance;
        }

        public void ToInstance(object instance) {
            isResolved = true;
            isResolving = false;
            IsSingleton = true;
            this.instance = (TType)instance;
        }
    }
}
