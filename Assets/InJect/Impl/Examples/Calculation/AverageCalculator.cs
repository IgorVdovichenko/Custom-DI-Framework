using System.Linq;

namespace InJect.Impl.Examples.Calculation
{
    public class AverageCalculator: IProcessor
    {
        public double ProcessData(double[] data)
        {
            return data.Average();
        }
    }
}