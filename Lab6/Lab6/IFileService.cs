﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public interface IFileService<T> where T: class
    {
        IEnumerable<T> ReadFile(string filename);
        void SaveData(IEnumerable<T> data, string filename);
    }
}
