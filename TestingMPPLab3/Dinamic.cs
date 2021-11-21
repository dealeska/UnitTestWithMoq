using System;
using System.Collections;
using System.Collections.Generic;

namespace TestingMPPLab3
{
    public class Dinamic<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public int Capasity { get; private set; }
        private T[] _list;
        private readonly IDinamicList<T> _logWriter;

        public Dinamic(IDinamicList<T> logWriter)
        {
            _logWriter = logWriter;
            _list = new T[0];
            Count = 0;
            Capasity = 0;
        }

        public Dinamic(IEnumerable<T> newList)
        {
            _list = new T[0];
            Count = 0;
            foreach (var item in newList)
            {
                AddEl(item);
            }
        }

        public Dinamic(int count)
        {
            _list = new T[count];
            Count = count;
        }

        public void AddEl(T item)
        {
            _logWriter.Add(item);
        }

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= Count))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                return _list[index];
            }
            set
            {
                if ((index < 0) || (index >= Count))
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                _list[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            _logWriter.RemoveAt(index);
        }

        public void Remove(T x) => RemoveAt(IndexOf(x));

        private int IndexOf(T x)
        {
            int i = 0;
            while ((_list[i] == null) || (i < Count) && (!_list[i].Equals(x)))
            {
                i++;
            }
            if (i == Count)
            {
                throw new NotImplementedException();
            }
            return i;
        }

        public void Clear()
        {
            Array.Resize(ref _list, 0);
            Count = 0;
            Capasity = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            int i = 0;
            while (i < Count)
            {
                yield return _list[i++];
            }
        }
    }
}
