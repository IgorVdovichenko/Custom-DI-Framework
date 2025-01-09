using System;
using InJect.Impl;
using InJect.Impl.Exceptions;
using NSubstitute;
using NUnit.Framework;

namespace InJect.Tests
{
    public class ContainerTests
    {
        private Container _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Container();
        }
        
        [Test]
        public void _01_()
        {
            RegisterInjectable<ClassA>(typeof(ClassA));

            var result = _sut.Resolve<ClassA>();
            
            Assert.That(result, Is.InstanceOf<ClassA>());
        }
        
        [Test]
        public void _02_()
        {
            RegisterInjectable<ClassA>(typeof(ISomeInterface));

            var result = _sut.Resolve<ISomeInterface>();
            
            Assert.That(result, Is.InstanceOf<ClassA>());
        }
        
        [Test]
        public void _03_WhenRegisteredSeveralImplementations_TheLastIsResolved()
        {
            RegisterInjectable<ClassA>(typeof(ISomeInterface));
            RegisterInjectable<ClassB>(typeof(ISomeInterface));

            var result = _sut.Resolve<ISomeInterface>();
            
            Assert.That(result, Is.InstanceOf<ClassB>());
        }

        [Test]
        public void _04_()
        {
            RegisterInjectable<ClassA>(typeof(ISomeInterface));

            var instance1 = _sut.Resolve<ISomeInterface>();
            var instance2 = _sut.Resolve<ISomeInterface>();
            
            Assert.That(instance1, Is.Not.SameAs(instance2));
        }
        
        [Test]
        public void _05_()
        {
            RegisterInjectable<ClassA>(typeof(ISomeInterface), true);

            var instance1 = _sut.Resolve<ISomeInterface>();
            var instance2 = _sut.Resolve<ISomeInterface>();
            
            Assert.That(instance1, Is.SameAs(instance2));
        }

        [Test]
        public void _06_()
        {
            RegisterInjectable<ClassC>(typeof(ISomeInterface));
            
            Assert.That(() => _sut.Resolve<ISomeInterface>(),
                Throws.Exception.TypeOf<ConstructorInjectionException>());
        }

        [Test]
        public void _07_()
        {
            RegisterInjectable<ClassD>(typeof(ClassD));
            RegisterInjectable<ClassA>(typeof(ISomeInterface));

            var instance = _sut.Resolve<ClassD>();
            
            Assert.That(instance.Dependency, Is.InstanceOf<ClassA>());
        }

        [Test]
        public void _08_()
        {
            Assert.That(() => _sut.Resolve<ClassA>(),
                Throws.Exception.TypeOf<MissingBindingException>());
        }

        [Test]
        public void _09_()
        {
            _sut.Register(Injectable.Implements<ClassA>().For<ISomeInterface>().Named("Class A"));
            _sut.Register(Injectable.Implements<ClassB>().For<ISomeInterface>().Named("Class B"));

            var instance = _sut.Resolve<ISomeInterface>("Class A");
            
            Assert.That(instance, Is.InstanceOf<ClassA>());
        }
        

        private void RegisterInjectable<T>(Type forType, bool isSingleton = false)
        {
            var injectable = Substitute.For<IInjectable>();
            injectable.AbstractionType.Returns(forType);
            injectable.ImplementationType.Returns(typeof(T));
            injectable.IsSingleton.Returns(isSingleton);
            _sut.Register(injectable);
        }
    }
}