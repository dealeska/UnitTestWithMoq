using System.Collections;
using NUnit.Framework;
using MPP_Lab_5;
using Moq;

namespace TestingMPPLab3
{
    public class UnitTestsWithMock
    {
        private static Person[] people = new Person[]
        {
            new Person("Alesya", 19),
            new Person("Katya", 19),
            new Person("Kirill", 20),
            new Person("Masha", 23),
            new Person("Alena", 20)
        };

        [Test]
        public void CheckGetEnumerator()
        {            
            var constant = 10;
            DynamicList<int> dynList = new DynamicList<int>();
            DynamicList<int> dynList2 = new DynamicList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < constant; i++)
            {
                dynList.Add(i + constant);
            }

            var mock = new Mock<IEnumerable>();
            mock.Setup(x => x.GetEnumerator()).Returns(dynList2.GetEnumerator());
            
            int expectedValue = 1;
            foreach (var i in mock.Object)
            {                
                Assert.AreEqual(expectedValue++, i);
            }
        }                   

        [Test]
        public void SortByName()
        {
            var mock = new Mock<IComparer>();
            mock.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((Person)x).Name.CompareTo(((Person)y).Name);
            });

            DynamicList<Person> peopleList = new DynamicList<Person>(people);
            peopleList.Sort(mock.Object);

            Person[] expected = new Person[]
            {
                new Person("Alena", 20),
                new Person("Alesya", 19),                
                new Person("Katya", 19),
                new Person("Kirill", 20),
                new Person("Masha", 23)                
            };

            CollectionAssert.AreEqual(expected, peopleList);
        }

        [Test]
        public void SortByAge()
        {
            var mock = new Mock<IComparer>();
            mock.Setup(cmp => cmp.Compare(It.IsAny<object?>(), It.IsAny<object?>())).Returns((object? x, object? y) =>
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return 1;
                else if (y == null)
                    return -1;
                else
                    return ((Person)x).Age.CompareTo(((Person)y).Age);
            });

            DynamicList<Person> peopleList = new DynamicList<Person>(people);
            peopleList.Sort(mock.Object);

            Person[] expected = new Person[]
            {
                new Person("Alesya", 19),
                new Person("Katya", 19),
                new Person("Kirill", 20),
                new Person("Alena", 20),                                                
                new Person("Masha", 23)
            };

            CollectionAssert.AreEqual(expected, peopleList);
        }

        [Test]
        public void GetCount()
        {
            IDynamicList<int> loggerDependency =
                Mock.Of<IDynamicList<int>>(d => d.Count == 5);
            var currentCount = loggerDependency.Count;

            Assert.That(currentCount, Is.EqualTo(5));
        }
    }
}