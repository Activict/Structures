using System;
using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    class LinkedListDouble<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public NodeDouble<T> Head { get; private set; }
        public NodeDouble<T> Tail { get; private set; }
        public void AddLast(T value)
        {
            NodeDouble<T> node = new NodeDouble<T>(value);
            if (Head == null)
                Head = Tail = node;
            else
            {
                Tail.Next = node;
                node.Previos = Tail;
                Tail = node;
            }
            Count++;
        }
        public void AddFirst(T value)
        {
            NodeDouble<T> node = new NodeDouble<T>(value);
            if (Head != null)
            {
                Head.Previos = node;
                node.Next = Head;
            }
            Head = node;
            Count++;
            Tail = Tail ?? Head;
            //if (tail == null) tail = head;
        }
        public void AddAfter(T value, T addValue)
        {
            NodeDouble<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    NodeDouble<T> temp = current.Next;
                    current.Next = new NodeDouble<T>(addValue);
                    current.Next.Previos = current;
                    if (temp != null)
                        current.Next.Next = temp;
                    else
                        Tail = current.Next;
                    Count++;
                    return;
                }
                current = current.Next;
            }
        }
        public void AddBefore(T value, T addValue)
        {
            NodeDouble<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    NodeDouble<T> previos = current.Previos;
                    if (previos == null)
                    {
                        Head = new NodeDouble<T>(addValue);
                        Head.Next = current;
                        current.Previos = Head;
                    }
                    else
                    {
                        previos.Next = new NodeDouble<T>(addValue);
                        previos.Next.Next = current;
                        previos.Next.Previos = previos;
                        current.Previos = previos.Next;
                    }
                    Count++;
                    return;
                }
                current = current.Next;
            }
        }
        public bool Remove(T value)
        {
            NodeDouble<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Previos == null)
                    {
                        Head = current.Next;
                        if (Head != null)
                            Head.Previos = null;
                        else Tail = null;
                    }
                    else if (current.Next == null)
                    {
                        Tail = current.Previos;
                        Tail.Next = null;
                    }
                    else
                    {
                        current.Previos.Next = current.Next;
                        current.Next.Previos = current.Previos;
                    }
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
        public void RemoveLast()
        {
            if (Tail != null)
            {
                if (Tail.Previos == null)
                    Clear();
                else
                {
                    Tail.Previos.Next = null;
                    Tail = Tail.Previos;
                    Count--;
                }
            }
        }
        public void RemoveFirst()
        {
            if (Count <= 1)
                Clear();
            else
            {
                Head.Next.Previos = null;
                Head = Head.Next;
                Count--;
            }
        }
        public T[] CopyToArray()
        {
            T[] arr = new T[Count];
            NodeDouble<T> current = Head;
            int counter = 0;
            while (current != null)
            {
                arr[counter] = current.Value;
                counter++;
                current = current.Next;
            }
            return arr;
        }
        public bool Contains(T value)
        {
            NodeDouble<T> current = Head;
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
            Head = Tail = null;
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
