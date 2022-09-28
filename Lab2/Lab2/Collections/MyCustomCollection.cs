using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2.Interfaces;
using Lab2.Entities;
using System.Collections;

namespace Lab2.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private Node<T> Curr { get; set; }
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                Curr = Head;
                for (int i = 0; i < index; i++)
                    Next();
                return Curr.Data;
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                Curr = Head;
                for (int i = 0; i < index; i++)
                    Next();
                Curr.Data = value;
            }
        }

        public int Count { get; private set; } = 0;

        T IEnumerator<T>.Current => Curr.Data;

        object IEnumerator.Current => Curr;

        public void Add(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(item);
                Tail = Head;
            }
            else
            {
                Node<T> temp = new Node<T>(item);
                Tail.Next = temp;
                temp.Prev = Tail;
                Tail = temp;

            }

            ++Count;
        }

        public T Current()
        {
            if (Curr != null)
                return Curr.Data;
            else
            {
                Curr = Head;
                return Curr.Data;
            }
        }

        public void Next()
        {
            MoveNext();
        }

        public void Remove(T item)
        {
            Reset();
            while (MoveNext())
            {
                if (item.Equals(Curr.Data))
                {
                    RemoveCurrent();
                    Reset();
                    return;
                }

            }

            throw new Exception("There is no such item in the collection");
        }

        public T RemoveCurrent()
        {
            /*if (Count == 0)
                return default;
            T data;
            if (Curr == Head)
            {
                data = Curr.Data;
                Head = Head.Next;
                --Count;
                Curr = Curr.Next;
                return data;
            }

            Node<T> node = Head;
            while (node.Next != Curr)
                node = node.Next;
            data = node.Next.Data;
            node.Next = node.Next.Next;
            --Count;
            return data;*/
            T temp = Curr.Data;
            --Count;
            if (Object.ReferenceEquals(Head, Curr))
            {
                Head = Head.Next;
                Head.Prev = null;
                Curr = Head;

            }
            else if (Object.ReferenceEquals(Tail, Curr))
            {
                Tail = Tail.Prev;
                Tail.Next = null;
                Curr = Tail;
            }
            else
            {
                Curr.Prev.Next = Curr.Next;
                Curr.Next.Prev = Curr.Prev;
                Curr = Curr.Next;
            }

            return temp;
        }

        public void Reset()
        {
            Curr = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            if (Curr == null && Head == null)
            {
                return false;
            }
            else if (Curr == null)
            {
                Curr = Head;
                return true;
            }
            else if (Curr.Next != null)
            {
                Curr = Curr.Next;
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
