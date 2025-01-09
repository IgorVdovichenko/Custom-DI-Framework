using System.Linq;
using JetBrains.Annotations;

namespace InJect.Impl.Examples.Calculation
{
    [UsedImplicitly]
    public class SumCalculator: IProcessor
    {
        public double ProcessData(double[] data)
        {
            return data.Sum();
        }
    }
}