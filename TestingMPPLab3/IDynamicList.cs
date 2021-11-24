namespace TestingMPPLab3
{
    public interface IDynamicList<T>
    {
        public int Count { get; set; }
        public int Capacity { get; set; }
        public T[] Add(T item);
        public void RemoveAt(int index);
        public void Remove(T x);
        public void Clear();
    }
}
