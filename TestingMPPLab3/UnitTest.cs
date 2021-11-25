using System;
using NUnit.Framework;
using MPP_Lab_5;

namespace TestingMPPLab3
{
    public class UnitTests
    {
        private static string[] stringList = new string[]
        {
            "This", "is", "my", "string", "for", "tests"
        };

        [Test]
        public void CreateList()
        {
            DynamicList<int> intList = new DynamicList<int>();
            Assert.IsNotNull(intList);        
        }

        [Test]
        public void CountOfCreatedList()
        {
            DynamicList<int> intList = new DynamicList<int>();
            Assert.Zero(intList.Count);
        }

        [Test]
        public void CapasityOfCreatedList()
        {
            DynamicList<int> intList = new DynamicList<int>();
            Assert.Zero(intList.Capacity);
        }

        [Test]
        public void ClearItemsIntegerValues()
        {
            DynamicList<int> intList = new DynamicList<int>() { 1, 2, 3, 4, 5 };
            intList.Clear();

            Assert.That(intList.Count == 0);
        }

        [Test]
        public void OutOfBoundsExceptionWhenSetElement()
        {
            DynamicList<int> intList = new DynamicList<int>(9);
            Assert.Throws<IndexOutOfRangeException>(() => intList[10] = 10);
        }

        [Test]
        public void CheckCountAfterRemovingElement()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            stringList.RemoveAt(5);
            Assert.AreEqual(stringList.Count, 8);
        }

        [Test]
        public void OutOfBoundsExceptionWhenRemoveAtElement()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            Assert.Catch<IndexOutOfRangeException>(() => stringList.RemoveAt(stringList.Count));            
        }

        [Test]
        public void OutOfBoundsExceptionWhenRemoveElement()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            Assert.Catch<IndexOutOfRangeException>(() => stringList.Remove("qwerty"));
        }

        [Test]
        public void CompareCountAfterAdding()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            int lastCount = stringList.Count;

            stringList.Add("q");
            stringList.Add("w");
            stringList.Add("e");

            Assert.AreEqual(stringList.Count - 3, lastCount);
        }

        [Test]
        public void CompareCapañityAfterRemoving()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            int lastCapañity = stringList.Capacity;

            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);

            Assert.AreEqual(stringList.Capacity, lastCapañity);
        }

        [Test]
        public void CompareListAfterRemoving()
        {
            DynamicList<string> actualList = new DynamicList<string>(stringList);
            DynamicList<string> expectedList = new DynamicList<string>()
            {
                "This", "is", "string", "list"
            };

            actualList.Remove(actualList[2]);
            actualList.Add("list");
            actualList.Remove(actualList[3]);
            actualList.Remove(actualList[3]);

            Assert.AreEqual(expectedList, actualList);
        }
    }
}