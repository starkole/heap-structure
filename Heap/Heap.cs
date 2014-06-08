using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Heap
{
    public class Heap<T> where T : IComparable<T>
    {
        #region Fields

        /// <summary>
        /// The core array where actual heap items are stored
        /// </summary>
        private T[] _storage = null;

        /// <summary>
        /// Indicates the heap size
        /// </summary>
        public int Count { get; private set; }

        #endregion//Fields

        #region Constructors

        /// <summary>
        /// Creates empty heap
        /// </summary>
        public Heap()
        {
            Count = 0;
        }//end:Heap()

        /// <summary>
        /// Creates heap from the items provided
        /// </summary>
        /// <param name="items">Items to add to the new hap</param>
        public Heap(params T[] items)
        {
            if (items.Count() == 0)
            {
                Count = 0;
                return;
            }
            foreach (var item in items)
            {
                this.Add(item);
            }
        }//end:Heap(params T items)

        /// <summary>
        /// Create a heap by copying existing one
        /// </summary>
        /// <param name="heap">A heap being copied</param>
        public Heap(Heap<T> heap)
        {
            this._storage = new T[heap.Count];
            for (int i = 0; i < heap.Count; i++)
            {
                this._storage[i] = heap._storage[i];
            }
        }//end:Heap(Heap<T> heap)

        #endregion//Constructors

        #region PrivateMethods

        /// <summary>
        /// Increases or decreases the _storage size 
        /// by copying it to the new array
        /// </summary>
        private void ResizeStorage()
        {

            throw new NotImplementedException();
        }//end:ResizeStorage

        #endregion//PrivateMethods

        #region PublicMethods

        /// <summary>
        /// Add an item to the heap
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            //Add the very first item to the _storage
            if (_storage == null)
            {
                _storage = new T[1];
                _storage[0] = item;
                Count = 1;
                return;
            }

            //When the _storage isn't large enough to add one more item,
            //double the _storage size
            if (_storage.Count() <= Count)
            {
                T[] _newStorage = new T[_storage.Count() * 2];
                for (int i = 0; i < _storage.Count(); i++)
                {
                    _newStorage[i] = _storage[i];
                }
                _storage = _newStorage;
            }
            Debug.Assert(_storage.Count() > Count, "_storage did not properly resized");

            //Add item to the end of other items
            _storage[Count] = item;

            //Maintain the main heap invariance:
            //parent nodes must <= than child nodes
            Debug.Assert(Count > 1, "Count should be grater than 1 here");
            int parentIndex = Count / 2;
            int childIndex = Count;
            while (parentIndex > 0
                && _storage[parentIndex - 1].CompareTo(_storage[childIndex]) > 0)
            {
                //Swap child with parent
                item = _storage[parentIndex - 1];
                _storage[parentIndex - 1] = _storage[childIndex];
                _storage[childIndex] = item;
                //Advance indexes
                childIndex = parentIndex - 1;
                parentIndex = parentIndex / 2;
            }

            //Advance the items counter
            Count++;

        }//end:Add

        /// <summary>
        /// Returns minimum item from the heap's root without deleting it.
        /// For several equal minimum items an arbitrary item is returned.
        /// </summary>
        /// <returns>Heap's minimum item</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _storage[0];
        }//end:Peek

        /// <summary>
        /// Returns minimum item from the heap's root 
        /// with the item deletion and heap reordering.
        /// For several equal minimum items an arbitrary item is returned.
        /// </summary>
        /// <returns>Heap's minimum item</returns>
        public T GetMin()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T result = _storage[0]; //Get the minimum item

            if (Count == 1)
            {
                Count--;
                _storage = null;
                return result;
            }

            _storage[0] = _storage[Count - 1]; //Add the last item into the place of min item
            Count--;

            //Maintain the main heap invariance: parent item must be <= of it's children
            int parentIndex = 1;
            int leftChildIndex = parentIndex * 2;
            int rightChildIndex = parentIndex * 2 + 1;
            T item;
            while (leftChildIndex <= Count && rightChildIndex <= Count
                && (_storage[parentIndex - 1].CompareTo(_storage[leftChildIndex - 1]) > 0
                || _storage[parentIndex - 1].CompareTo(_storage[rightChildIndex - 1]) > 0))
            {
                item = _storage[parentIndex - 1];
                //Parent always swapped with the least of it's children
                if (_storage[leftChildIndex - 1].CompareTo(_storage[rightChildIndex - 1]) < 0)
                {
                    _storage[parentIndex - 1] = _storage[leftChildIndex - 1];
                    _storage[leftChildIndex - 1] = item;
                    parentIndex = leftChildIndex;
                }
                else
                {
                    _storage[parentIndex - 1] = _storage[rightChildIndex - 1];
                    _storage[rightChildIndex - 1] = item;
                    parentIndex = rightChildIndex;
                }
                leftChildIndex = parentIndex * 2;
                rightChildIndex = parentIndex * 2 + 1;
            }

            //Resize _storage if there is too many empty items at the end of the array
            if (_storage.Count() / 2 > Count)
            {
                T[] _newStorage = new T[_storage.Count() / 2];
                for (int i = 0; i < Count; i++)
                {
                    _newStorage[i] = _storage[i];
                }
                _storage = _newStorage;
            }

            return result;
        }//end:GetMin

        #endregion//PublicMethods

    }//end:class Heap

}//end:namespace Heap
