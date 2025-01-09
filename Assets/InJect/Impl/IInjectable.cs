using System;

namespace InJect.Impl
{
    public interface IInjectable
    {
        Type ImplementationType { get; }
        Type AbstractionType { get; }
        bool IsSingleton { get; }
        string Name { get; }
    }
}