using System;

namespace InJect.Impl.Exceptions
{
    public class ConstructorInjectionException: Exception
    {
        private readonly Type _type;

        public ConstructorInjectionException(Type type)
        {
            _type = type;
        }
        
        public override string Message =>
            $"Construction injection failed for {_type}. The class has more than one constructor of an appropriate constructor not found.";
    }
}