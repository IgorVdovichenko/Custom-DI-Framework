using System;

namespace InJect.Impl.Exceptions
{
    public class MissingBindingException: Exception
    {
        private readonly Type _type;

        public MissingBindingException(Type type)
        {
            _type = type;
        }
        
        public override string Message => $"Trying to resolve unmapped dependency of type {_type}";
    }
}