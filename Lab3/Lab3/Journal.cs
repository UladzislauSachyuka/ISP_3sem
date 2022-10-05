using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Journal
    {
        public string History { get; private set; }
        public Journal()
        {
            History = "";
        }
        public void AddToHistory(string message)
        {
            History += message + '\n';
        }
        public void ShowHistory()
        {
            Console.WriteLine(History);
        }
    }
}
