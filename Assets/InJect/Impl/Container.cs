using System;
using System.Collections.Generic;
using System.Linq;
using InJect.Impl.Exceptions;
using UnityEngine;

namespace InJect.Impl
{
    public sealed class Container
    {
        private readonly List<IInjectable> _injectables = new List<IInjectable>();
        
        private readonly Dictionary<Type, object> _singletons = new Dictionary<Type, object>();
        
        
        public void Register(IInjectable injectable)
        {
            _injectables.Add(injectable);

            if (injectable.IsSingleton)
            {
                _singletons.TryAdd(injectable.AbstractionType, CreateInstance(injectable.ImplementationType));
            }
        }

        public void Register(Injectable[] injectables)
        {
            foreach (var injectable in injectables)
            {
                Register(injectable);
            }
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public T Resolve<T>(string name)
        {
            var injectable = _injectables.LastOrDefault(i => 
                i.AbstractionType == typeof(T) && i.Name == name);

            if (injectable == null) throw new MissingBindingException(typeof(T));

            var typeToInstantiate = injectable.ImplementationType;
            
            return !injectable.IsSingleton
                ?  (T) CreateInstance(typeToInstantiate)
                : (T) _singletons[injectable.AbstractionType];
        }

        private object Resolve(Type type)
        {
            var injectable = _injectables.LastOrDefault(i => i.AbstractionType == type);

            if (injectable == null) throw new MissingBindingException(type);

            var typeToInstantiate = injectable.ImplementationType;
            
            return !injectable.IsSingleton
                ? CreateInstance(typeToInstantiate)
                : _singletons[injectable.AbstractionType];
        }

        private object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors();
            var constructor = constructors.FirstOrDefault();
            
            if(constructors.Length > 1) throw new ConstructorInjectionException(type);
            
            var parameters = constructor!.GetParameters();

            var constructorArgs = parameters.Select(parameter => Resolve(parameter.ParameterType)).ToArray();

            return constructor.Invoke(constructorArgs);
        }
    }
}