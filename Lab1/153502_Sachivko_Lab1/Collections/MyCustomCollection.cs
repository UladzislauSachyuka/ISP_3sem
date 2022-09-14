using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Sachivko_Lab1.Interfaces;
using _153502_Sachivko_Lab1.Entities;

namespace _153502_Sachivko_Lab1.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private Node<T> Curr { get; set; }
        private Node<T> Head { get; set; }
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                Node<T> it = Head;
                for (int i = 0; i != index; ++i)
                    it = it.Next;

                return it.Data;
            }
            set
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                Node<T> it = Head;
                for (int i = 0; i != index; ++i)
                    it = it.Next;

                it.Data = value;
            }
        }

        public int Count { get; private set; } = 0;

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (Count == 0)
            {
                Head = newNode;
                Curr = newNode;
                ++Count;
                return;
            }
            if (Count == 1)
            {
                Head.Next = newNode;
                ++Count;
                return;
            }

            Node<T> node = Head;
            while (node.Next.Next != null)
                node = node.Next;
            node.Next.Next = newNode;
            ++Count;
        }

        public T Current()
        {
            return Curr.Data;
        }

        public void Next()
        {
            if (Curr.Next != null)
                Curr = Curr.Next;
        }

        public void Remove(T item)
        {
            if (Count == 0)
                return;
            if (Count == 1)
            {
                Count = 0;
                Head = null;
                Curr = null;
                return;
            }

            if (Head.Data.Equals(item))
            {
                if (Curr == Head)
                    Curr = Head.Next;
                Head = Head.Next;
                --Count;
                return;
            }

            if (Head.Next.Data.Equals(item))
            {
                if (Curr == Head.Next)
                    Curr = Head;
                Head.Next = Head.Next.Next;
                --Count;
                return;
            }

            Node<T> node = Head;
            while (node.Next.Next != null)
            {
                if (node.Next.Next.Data.Equals(item))
                {
                    if (Curr == node.Next.Next)
                        Curr = node.Next;
                    node.Next.Next = node.Next.Next.Next;
                    --Count;
                    break;
                }
                node = node.Next;
            }

            if (node.Next.Next == null)
                return;
        }

        public T RemoveCurrent()
        {
            if (Count == 0)
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
            return data;
        }

        public void Reset()
        {
            Curr = Head;
        }
    }
}
