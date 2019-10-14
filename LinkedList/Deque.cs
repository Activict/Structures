using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class Deque<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public NodeDouble<T> Tail { get; private set; }
        public NodeDouble<T> Head { get; set; }
        public void AddLast(T value)
        {
            if (Count == 0)
                Tail = Head = new NodeDouble<T>(value);

            else if (Count > 0)
            {
                NodeDouble<T> temp = new NodeDouble<T>(value);
                Tail.Next = temp;
                temp.Previos = Tail;
                Tail = Tail.Next;
            }
            Count++;
        }
        public void AddFirst(T value)
        {
            if (Count == 0)
                Tail = Head = new NodeDouble<T>(value);
            else if (Count > 0)
            {
                NodeDouble<T> temp = new NodeDouble<T>(value);
                temp.Next = Head;
                Head.Previos = temp;
                Head = Head.Previos;
            }
            Count++;
        }
        public T GetLast()
        {
            if (Count > 1)
            {
                T value = Tail.Value;
                Tail = Tail.Previos;
                Tail.Next = null;
                Count--;
                return value;
            }
            else if (Count == 1)
            {
                T value = Tail.Value;
                Tail = Head = null;
                Count--;
                return value;
            }
            else
                throw new IndexOutOfRangeException("Deck is empty");
        }
        public T GetFirst()
        {
            if (Count > 1)
            {
                T value = Head.Value;
                Head = Head.Next;
                Head.Previos= null;
                Count--;
                return value;
            }
            else if (Count == 1)
            {
                T value = Tail.Value;
                Tail = Head = null;
                Count--;
                return value;
            }
            else
                throw new IndexOutOfRangeException("Deck is empty");
        }
        public T First()
        {
            if (Head != null)
                return Head.Value;
            else
                throw new IndexOutOfRangeException("Deck is empty");
        }
        public T Last()
        {
            if (Tail != null)
                return Tail.Value;
            else
                throw new IndexOutOfRangeException("Deck is empty");
        }
        public bool Contains(T value)
        {
            NodeDouble<T> current = Tail;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Clear()
        {
            Tail = Head = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodeDouble<T> current = Head;
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
