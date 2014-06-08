using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap<T>
    {
        private T[] _storage;
        
        public Heap()
        {
            _storage = new T[3];
        }
    }
}
