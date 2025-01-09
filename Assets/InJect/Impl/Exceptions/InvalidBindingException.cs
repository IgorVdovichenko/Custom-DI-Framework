using System;

namespace InJect.Impl.Exceptions
{
    public class InvalidBindingException: Exception
    {
        private readonly Type _abstractionType;
        private readonly Type _implementationType;

        public InvalidBindingException(Type abstr, Type impl)
        {
            _abstractionType = abstr;
            _implementationType = impl;
        }

        public override string Message =>
            $"Type {_abstractionType} is not assignable from {_implementationType}";
    }
}