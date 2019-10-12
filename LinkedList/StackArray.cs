using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class StackArray<T> : IEnumerable<T>
    {
        T[] arr = new T[4];
        public int Count { get; private set; }

        public void Push(T value)
        {
            if (Count == arr.Length)
            {
                T[] arrNew = new T[arr.Length * 2];
                arr.CopyTo(arrNew, 0);
                arr = arrNew;
            }
            arr[Count] = value;
            Count++;
        }
        public T Pop()
        {
            if (Count < arr.Length / 2 && Count > 2)
            {
                T[] newArr = new T[arr.Length / 2];
                for (int i = 0; i < newArr.Length; i++)
                    newArr[i] = arr[i];
                arr = newArr;
            }
            if (Count > 0)
            {
                T value = arr[Count - 1];
                Count--;
                return value;
            }
            else
                throw new Exception("Stack is empty");
        }
        public T Pick()
        {
            if (Count > 0)
                return arr[Count - 1];
            else
                throw new Exception("Stack is empty");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
