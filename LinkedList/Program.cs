using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }

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

    class DoubleLinkedList<T> : IEnumerable<T>
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

    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<int> linkedList = new LinkedListNode<int>();
            //linkedList.Head = new Node<int>(5);

            #region Проверка Add Добавление элементов в односвязный список

            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            Console.Write("Add 1, 2, 3, 4 to linkedList: ");
            linkedList.Display();
            Console.WriteLine();
            #endregion

            #region Удаление Remove() элемента по значению 3 из односвязного списка

            linkedList.Remove(3);
            Console.Write("Remove 3 from linkedList: ");
            linkedList.Display();
            Console.WriteLine();
            #endregion

            #region Копирование списка в массив CopyToArray()

            int[] arr = linkedList.CopyToArray();
            Console.Write("Copy linkedList to array: ");
            foreach (var item in arr)
                Console.Write(item.ToString() + ' ');
            Console.WriteLine('\n');
            #endregion

            #region Удаление всех эелементов списка Clear()

            linkedList.Clear();
            Console.Write("linkedList after Clear(): ");
            linkedList.Display();
            Console.WriteLine();
            #endregion

            //Console.ReadLine();
            DoubleLinkedList<int> dLinkedList = new DoubleLinkedList<int>();
            //dLinkedList.Head = new NodeDouble<int>(5);

            #region Добавление элементов в двусвязный список

            dLinkedList.AddLast(1);
            dLinkedList.AddLast(2);
            dLinkedList.AddLast(3);
            dLinkedList.AddLast(4);
            dLinkedList.AddLast(5);
            Console.Write("Add 1, 2, 3, 4, 5 to dLinkedList: ");
            dLinkedList.Display();
            Console.WriteLine();
            #endregion

            #region Удаление Remove() элемента по значению 1 из двусвязного списка

            dLinkedList.Remove(1);
            Console.Write("Remove 1 from dLinkedList: ");
            dLinkedList.Display();
            Console.WriteLine();
            #endregion

            #region Копирование списка в массив

            arr = dLinkedList.CopyToArray();
            Console.Write("Copy dLinkedList to array: ");
            foreach (var item in arr)
                Console.Write(item.ToString() + ' ');
            Console.WriteLine('\n');
            #endregion

            #region Проверка наличия элементоа 4 и 6 в листе

            Console.Write("Chek contains 6 in list: ");
            Console.WriteLine(dLinkedList.Contains(6));
            Console.Write("Chek contains 4 in list: ");
            Console.WriteLine(dLinkedList.Contains(4));
            Console.WriteLine();
            #endregion

            #region Добавление в начало и конец списка, очищение списка, удаление элемента по значению

            Console.Write("Add to start 0: ");
            dLinkedList.AddFirst(0);
            dLinkedList.Display();
            Console.WriteLine();

            Console.Write("Clear list: ");
            dLinkedList.Clear();
            dLinkedList.Display();
            Console.WriteLine();

            Console.Write("Add to start 0 and remove last: ");
            dLinkedList.AddLast(0);
            dLinkedList.RemoveLast();
            dLinkedList.Display();
            Console.WriteLine();
            #endregion

            #region Добавить в начало, добавить после, добавить до
            dLinkedList.AddFirst(2);
            dLinkedList.AddAfter(2, 5);
            dLinkedList.AddFirst(4);
            dLinkedList.AddAfter(4, 7);
            dLinkedList.RemoveFirst();
            dLinkedList.RemoveFirst();

            dLinkedList.AddBefore(2, 1);
            dLinkedList.AddBefore(5, 4);
            Console.Write("AddFirst 2, AddAfter(2, 5), AddFirst 4, AddAfter(4, 7) \nAddBefore(2, 1), AddBefore(5, 4) \nMust: 1 2 4 5 \ndLinkedList: ");
            dLinkedList.Display();
            #endregion

            Console.ReadKey();
        }
    }
}
