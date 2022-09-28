using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab2.Interfaces
{
    interface ICustomCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        T this[int index] { get; set; }
        void Reset();
        void Next();
        T Current();
        int Count { get; }
        void Add(T item);
        void Remove(T item);
        T RemoveCurrent();
    }
}