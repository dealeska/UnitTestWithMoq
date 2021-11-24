using System;
using NUnit.Framework;
using MPP_Lab_5;

namespace TestingMPPLab3
{
    public class UnitTests
    {
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
        public void CountAndCapasityAfterInitialization()
        {
            DynamicList<int> intList = new DynamicList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(intList.Capacity > intList.Count);
        }

        [Test]
        public void OutOfBoundsExceptionWhenSetElement()
        {
            DynamicList<int> intList = new DynamicList<int>(9);
            Assert.Throws<IndexOutOfRangeException>(() => intList[10] = 10);
        }

        [Test]
        public void CheckCountAfterRemoveElement()
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
        public void CompareCapasityAfterRemoving()
        {
            DynamicList<string> stringList = new DynamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            int lastCapasity = stringList.Capacity;

            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);

            Assert.AreEqual(stringList.Capacity, lastCapasity);
        }
    }
}