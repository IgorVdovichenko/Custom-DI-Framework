using InJect.Impl.Examples.Solid.Readers;
using InJect.Impl.Examples.Solid.Writers;
using UnityEngine;
using IProcessor = InJect.Impl.Examples.Solid.Processors.Api.IProcessor;
using IReader = InJect.Impl.Examples.Solid.Readers.Api.IReader;
using IWriter = InJect.Impl.Examples.Solid.Writers.Api.IWriter;
using SumCalculator = InJect.Impl.Examples.Solid.Processors.SumCalculator;

namespace InJect.Impl.Root
{
    public class CompositionRoot : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            var container = new StructureMap.Container();
            
             container.Configure(r =>
                 r.For<IReader>()
                     .Use<JsonReader>()
                     .Ctor<string>().Is(Global.DataFilePath));
            
             container.Configure(r =>
                 r.For<IWriter>()
                     .Use<UnityConsoleWriter>());
            
             container.Configure(r =>
                 r.For<IProcessor>()
                     .Use<SumCalculator>());
            
             var app = container.GetInstance<Examples.Solid.Application>();

             app.Run();
        }
    }
}