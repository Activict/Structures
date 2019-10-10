using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    class LinkedListNode<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Head == null)
                Head = node;
            else
            {
                Head.Next = node;
                Head = node;
            }
            if (Tail == null)
                Tail = node;
            Count += 1;
        }
        public bool Remove(T value)
        {
            Node<T> previos = null;
            Node<T> current = Tail;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previos != null)
                    {
                        if (current.Next == null)
                            Head = previos;

                        previos.Next = current.Next;
                    }
                    else
                        Tail = current.Next;
                    Count -= 1;
                    return true;
                }
                previos = current;
                current = current.Next;
            }
            return false;
        }
        public T[] CopyToArray()
        {
            Node<T> current = Tail;
            T[] arr = new T[Count];
            int counter = 0;
            while (current != null)
            {
                arr[counter] = current.Value;
                current = current.Next;
                counter++;
            }
            return arr;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public void Display()
        {
            foreach (var item in this)
            {
                Console.Write(item.ToString() + ' ');
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Tail;
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
