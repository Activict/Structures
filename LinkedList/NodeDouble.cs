namespace Structures
{
    class NodeDouble<T>
    {
        public T Value { get; set; }
        public NodeDouble<T> Next { get; set; }
        public NodeDouble<T> Previos { get; set; }
        public NodeDouble(T value)
        {
            Value = value;
        }
    }
}
