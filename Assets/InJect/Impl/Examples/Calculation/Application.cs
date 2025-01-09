using JetBrains.Annotations;

namespace InJect.Impl.Examples.Calculation
{
    [UsedImplicitly]
    public class Application : IApplication
    {
        private readonly IReader _input;
        private readonly IWriter _output;
        private readonly IProcessor _processor;

        public Application(IReader input, IWriter output, IProcessor processor)
        {
            _input = input;
            _output = output;
            _processor = processor;
        }

        public void Run()
        {
            var data = _input.ReadData();
            var result = _processor.ProcessData(data);
            _output.Write(result);
        }
    }
}