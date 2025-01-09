using InJect.Impl.Examples;
using InJect.Impl.Examples.Calculation;
using InJect.Impl.Examples.Solid.Processors;
using InJect.Impl.Examples.Solid.Readers;
using InJect.Impl.Examples.Solid.Writers;
using UnityEngine;
using Application = InJect.Impl.Examples.Calculation.Application;
using ILogger = InJect.Impl.Examples.ILogger;
using Input = InJect.Impl.Examples.Calculation.Input;
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
            
            //var container = new Container();
            
            // container.Register(Injectable.Implements<UnityEditorLogger>().For<ILogger>());
            // container.Register(Injectable.Implements<Example>());
            
            // container.Register(AutoMap
            //     .ForAssembly(a => a.ForType(typeof(Example)))
            //     .AllToBaseTypes());
            
            // container.Resolve<Example>().Execute();
            
            // container.Register(Injectable.Implements<Input>().For<IReader>());
            // container.Register(Injectable.Implements<Output>().For<IWriter>());
            //container.Register(Injectable.Implements<AverageCalculator>().For<IProcessor>().Named("Average"));
            //container.Register(Injectable.Implements<SumCalculator>().For<IProcessor>().Named("Sum"));
            // container.Register(Injectable.Implements<Application>().For<IApplication>());
            
            //container.Resolve<IApplication>().Run();
            
            // var app = new Examples.Solid.Application(
            //     new JsonReader(Global.DataFilePath),
            //     new UnityConsoleWriter(), 
            //     new Examples.Solid.Processors.SumCalculator());
            // app.Run();
            
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