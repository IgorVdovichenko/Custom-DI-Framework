namespace InJect.Tests
{
    public class ClassA: ISomeInterface
    {
        
    }

    public class ClassB: ISomeInterface
    {
        
    }

    public class ClassC : ISomeInterface
    {
        public ClassC(){}

        public ClassC(int a){}
    }
    
    public class ClassD
    {
        public ISomeInterface Dependency { get; }

        public ClassD(ISomeInterface dependency)
        {
            Dependency = dependency;
        }
    }
    
    public interface ISomeInterface{}
    
    public interface INotAssignableInterface{}
}