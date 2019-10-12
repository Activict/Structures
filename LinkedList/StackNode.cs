using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class StackNode<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public int Count { get; private set; }
        public void Push(T value)
        {
            if (Head == null)
            {
                Count++;
                Head = new Node<T>(value);
            }
            else
            {
                Node<T> node = new Node<T>(value);
                node.Next = Head;
                Head = node;
                Count++;
            }
            
        }
        public T Pop()
        {
            if (Head == null)
                throw new InvalidOperationException("Stack is empty");
            else
            {
                Node<T> node = Head;
                Head = Head.Next;
                Count--;
                return node.Value;
            }
        }
        public T Peek()
        {
            if (Head == null)
                throw new InvalidOperationException("Stack is empty");
            else
                return Head.Value;
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
