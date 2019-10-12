using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{

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
            LinkedListDouble<int> LinkedListDouble = new LinkedListDouble<int>();
            //dLinkedList.Head = new NodeDouble<int>(5);

            #region Добавление элементов в двусвязный список

            LinkedListDouble.AddLast(1);
            LinkedListDouble.AddLast(2);
            LinkedListDouble.AddLast(3);
            LinkedListDouble.AddLast(4);
            LinkedListDouble.AddLast(5);
            Console.Write("Add 1, 2, 3, 4, 5 to dLinkedList: ");
            LinkedListDouble.Display();
            Console.WriteLine();
            #endregion

            #region Удаление Remove() элемента по значению 1 из двусвязного списка

            LinkedListDouble.Remove(1);
            Console.Write("Remove 1 from dLinkedList: ");
            LinkedListDouble.Display();
            Console.WriteLine();
            #endregion

            #region Копирование списка в массив

            arr = LinkedListDouble.CopyToArray();
            Console.Write("Copy dLinkedList to array: ");
            foreach (var item in arr)
                Console.Write(item.ToString() + ' ');
            Console.WriteLine('\n');
            #endregion

            #region Проверка наличия элементоа 4 и 6 в листе

            Console.Write("Chek contains 6 in list: ");
            Console.WriteLine(LinkedListDouble.Contains(6));
            Console.Write("Chek contains 4 in list: ");
            Console.WriteLine(LinkedListDouble.Contains(4));
            Console.WriteLine();
            #endregion

            #region Добавление в начало и конец списка, очищение списка, удаление элемента по значению

            Console.Write("Add to start 0: ");
            LinkedListDouble.AddFirst(0);
            LinkedListDouble.Display();
            Console.WriteLine();

            Console.Write("Clear list: ");
            LinkedListDouble.Clear();
            LinkedListDouble.Display();
            Console.WriteLine();

            Console.Write("Add to start 0 and remove last: ");
            LinkedListDouble.AddLast(0);
            LinkedListDouble.RemoveLast();
            LinkedListDouble.Display();
            Console.WriteLine();
            #endregion

            #region Добавить в начало, добавить после, добавить до
            LinkedListDouble.AddFirst(2);
            LinkedListDouble.AddAfter(2, 5);
            LinkedListDouble.AddFirst(4);
            LinkedListDouble.AddAfter(4, 7);
            LinkedListDouble.RemoveFirst();
            LinkedListDouble.RemoveFirst();

            LinkedListDouble.AddBefore(2, 1);
            LinkedListDouble.AddBefore(5, 4);
            Console.Write("AddFirst 2, AddAfter(2, 5), AddFirst 4, AddAfter(4, 7) \nAddBefore(2, 1), AddBefore(5, 4) \nMust: 1 2 4 5 \ndLinkedList: ");
            LinkedListDouble.Display();
            #endregion

            Console.ReadKey();
        }
    }
}
