using InJect.Impl;
using InJect.Impl.Exceptions;
using NUnit.Framework;

namespace InJect.Tests
{
    public class InjectableTests
    {
        [Test]
        public void _01_()
        {
            var sut = Injectable.Implements<ClassA>();
            Assert.That(sut.ImplementationType, Is.EqualTo(typeof(ClassA)));
        }

        [Test]
        public void _02_()
        {
            var sut = Injectable.Implements<ClassA>().For<ISomeInterface>();
            Assert.That(sut.AbstractionType, Is.EqualTo(typeof(ISomeInterface)));
        }

        [Test]
        public void _03_()
        {
            var sut = Injectable.Implements<ClassA>();
            Assert.That(sut.AbstractionType, Is.EqualTo(typeof(ClassA)));
        }

        [Test]
        public void _04_()
        {
            var sut = Injectable.Implements<ClassA>();
            Assert.That(sut.IsSingleton, Is.False);
        }
        
        [Test]
        public void _05_()
        {
            var sut = Injectable.Implements<ClassA>().AsSingleton();
            Assert.That(sut.IsSingleton, Is.True);
        }

        [Test]
        public void _06_()
        {
            Assert.That(() => { Injectable.Implements<ClassA>().For<INotAssignableInterface>();},
                Throws.Exception.TypeOf<InvalidBindingException>());
        }

        [Test]
        public void _07_()
        {
            var sut = Injectable.Implements<ClassA>().For<ISomeInterface>().Named("Class A");
            
            Assert.That(sut.Name, Is.EqualTo("Class A"));
        }
    }
}