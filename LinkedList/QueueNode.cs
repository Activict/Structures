using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class QueueNode<T> : IEnumerable<T>
    {
        public Node<T> Tail { get; private set; }
        public Node<T> Head { get; private set; }
        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            if (Head == null)
            {
                Head = Tail = new Node<T>(value);
                Count++;
            }
            else
            {
                Tail.Next = new Node<T>(value);
                Tail = Tail.Next;
                Count++;
            }
        }
        public T Dequeue()
        {
            if (Head == null)
                throw new Exception("Queue is empty");
            else if (Count > 1)
            {
                T first = Head.Value;
                Head = Head.Next;
                Count--;
                return first;
            }
            else
            {
                T first = Head.Value;
                Head = Tail = null;
                Count--;
                return first;
            }
            
        }
        public T First()
        {
            if (Head == null)
                throw new Exception("Queue is empty");
            return Head.Value;
        }
        public T Last()
        {
            if (Head == null)
                throw new Exception("Queue is empty");
            return Tail.Value;
        }
        public void Clear()
        {
            Head = Tail = null;
        }
        public bool Contains(T value)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
