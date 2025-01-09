using System.Linq;
using InJect.Impl.Examples.Solid.Processors.Api;
using JetBrains.Annotations;

namespace InJect.Impl.Examples.Solid.Processors
{
    [UsedImplicitly]
    public sealed class SumCalculator : IProcessor
    {
        public double GetResult(double[] values)
        {
            return values.Sum();
        }
    }
}