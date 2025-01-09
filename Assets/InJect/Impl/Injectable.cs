using System;
using InJect.Impl.Exceptions;

namespace InJect.Impl
{
    public sealed class Injectable: IInjectable
    {
        public Type ImplementationType { get; private set; }
        public Type AbstractionType { get; private set; }
        public bool IsSingleton { get; private set; }
        public string Name { get; private set; }

        private Injectable(){}

        public static Injectable Implements<T>()
        {
            return Implements(typeof(T));
        }
        
        public static Injectable Implements(Type type)
        {
            return new Injectable
            {
                ImplementationType = type,
                AbstractionType = type
            };
        }

        public Injectable For<T>()
        {
            return For(typeof(T));
        }
        
        public Injectable For(Type type)
        {
            AbstractionType = type;
            
            if(!type.IsAssignableFrom(ImplementationType)) 
                throw new InvalidBindingException(AbstractionType, ImplementationType);
            
            return this;
        }

        public Injectable AsSingleton()
        {
            IsSingleton = true;
            return this;
        }

        public Injectable Named(string name)
        {
            Name = name;
            return this;
        }

        public Injectable Constructor()
        {
            
            return this;
        }
    }

    public class CtorArgs
    {
        
    }
}