using System;
using NUnit.Framework;
using MPP_Lab_5;
using Moq;

namespace TestingMPPLab3
{
    public class UnitTestsWithMoq
    {
        [Test]
        public void AddElement()
        {
            var mock = new Mock<IDinamicList<string>>();
            var list = new Dinamic<string>(mock.Object);

            list.AddEl("Hello, list!");

            // Проверяем, что вызвался метод Write нашего мока с любым аргументом
            mock.Verify(lw => lw.Add(It.IsAny<string>()));
        }

        [Test]
        public void GetCount()
        {
            IDinamicList<int> loggerDependency =
                Mock.Of<IDinamicList<int>>(d => d.Count == 5);
            var currentCount = loggerDependency.Count;

            Assert.That(currentCount, Is.EqualTo(5));
        }
    }
}