namespace InJect.Impl.Examples.Calculation
{
    public class CompileTimeInput: IReader
    {
        private readonly double[] _values;

        public CompileTimeInput(double[] values)
        {
            _values = values;
        }
        public double[] ReadData()
        {
            return _values;
        }
    }
}