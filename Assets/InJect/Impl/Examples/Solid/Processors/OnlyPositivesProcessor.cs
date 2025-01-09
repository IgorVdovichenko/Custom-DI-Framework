using System.Linq;
using InJect.Impl.Examples.Solid.Processors.Api;

namespace InJect.Impl.Examples.Solid.Processors
{
    public class OnlyPositivesProcessor: IProcessor
    {
        private readonly IProcessor _baseProcessor;

        public OnlyPositivesProcessor(IProcessor baseProcessor)
        {
            _baseProcessor = baseProcessor;
        }
        
        public new double GetResult(double[] values)
        {
            var positives = values.Where(v => v > 0);
            return _baseProcessor.GetResult(positives.ToArray());
        }
    }
}