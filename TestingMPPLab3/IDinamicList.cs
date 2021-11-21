namespace TestingMPPLab3
{
    public interface IDinamicList<T>
    {
        public int Count { get; set; }
        public int Capasity { get; set; }
        public void Add(T item);
        public void RemoveAt(int index);
        public void Remove(T x);
        public void Clear();
    }
}
