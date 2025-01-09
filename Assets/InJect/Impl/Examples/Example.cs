namespace InJect.Impl.Examples
{
    public class Example
    {
        private readonly string text = "Hello, World!!!!!!!";
        private readonly ILogger _logger;

        public Example(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Execute()
        {
            _logger.Print(text);
        }
    }
}