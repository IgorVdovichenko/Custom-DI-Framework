using InJect.Impl.Examples.Solid.Processors.Api;
using InJect.Impl.Examples.Solid.Readers.Api;
using InJect.Impl.Examples.Solid.Writers.Api;

namespace InJect.Impl.Examples.Solid
{
    public class Application
    {
        private readonly IProcessor _processor;
        private readonly IWriter _writer;
        private readonly IReader _reader;

        public Application(IReader reader, IWriter writer, IProcessor processor)
        {
            _processor = processor;
            _reader = reader;
            _writer = writer;
        }

        public void Run()
        {
            var data = _reader.Read();
            var result = _processor.GetResult(data);
            _writer.Write(result);
        }
    }
}