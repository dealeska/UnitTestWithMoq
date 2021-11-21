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
            DinamicList<int> intList = new DinamicList<int>();
            Assert.IsNotNull(intList);        
        }

        [Test]
        public void CountOfCreatedList()
        {
            DinamicList<int> intList = new DinamicList<int>();
            Assert.Zero(intList.Count);
        }

        [Test]
        public void CapasityOfCreatedList()
        {
            DinamicList<int> intList = new DinamicList<int>();
            Assert.Zero(intList.Capasity);
        }

        [Test]
        public void CountAndCapasityAfterInitialization()
        {
            DinamicList<int> intList = new DinamicList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(intList.Capasity > intList.Count);
        }

        [Test]
        public void OutOfBoundsExceptionWhenSetElement()
        {
            DinamicList<int> intList = new DinamicList<int>(9);
            Assert.Throws<IndexOutOfRangeException>(() => intList[10] = 10);
        }

        [Test]
        public void CheckCountAfterRemoveElement()
        {
            DinamicList<string> stringList = new DinamicList<string>(9);
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
            DinamicList<string> stringList = new DinamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            Assert.Catch<IndexOutOfRangeException>(() => stringList.RemoveAt(stringList.Count));            
        }

        [Test]
        public void OutOfBoundsExceptionWhenRemoveElement()
        {
            DinamicList<string> stringList = new DinamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            Assert.Catch<IndexOutOfRangeException>(() => stringList.Remove("qwerty"));
        }

        [Test]
        public void CompareCountAfterAdding()
        {
            DinamicList<string> stringList = new DinamicList<string>(9);
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
            DinamicList<string> stringList = new DinamicList<string>(9);
            for (int i = 0; i < stringList.Count; i++)
            {
                stringList[i] = i.ToString();
            }
            int lastCapasity = stringList.Capasity;

            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);
            stringList.RemoveAt(1);

            Assert.AreEqual(stringList.Capasity, lastCapasity);
        }
    }
}