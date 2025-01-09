using System;
using System.Linq;

namespace InJect.Impl.Examples.Calculation
{
    public class OnlyPositivesSumCalculator: IProcessor
    {
        private readonly IProcessor _baseProcessor;

        public OnlyPositivesSumCalculator(IProcessor baseProcessor)
        {
            _baseProcessor = baseProcessor;
        }
        
        public double ProcessData(double[] data)
        {
            if (!AllPositives(data))
            {
                throw new ArgumentException();
            }

            return _baseProcessor.ProcessData(data);
        }

        private static bool AllPositives(double[] values)
        {
            return !values.Any(value => value < 0);
        }
    }
}