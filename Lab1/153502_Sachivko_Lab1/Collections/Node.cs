using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Sachivko_Lab1.Entities
{
    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; } 
        public Node<T> Next { get; set; }
    }
}
