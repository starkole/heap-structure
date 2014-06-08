using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap<T> where T: IComparable<T>
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

        public Heap() 
        {
            Count = 0;
        }//end:Heap()

        public Heap(params T[] items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }//end:Heap(params T items)
        
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
        /// by copying to the new array
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
            throw new NotImplementedException();
        }//end:Add

        /// <summary>
        /// Returns minimum item from the heap's root without deleting it.
        /// For several equal minimum items an arbitrary item is returned.
        /// </summary>
        /// <returns>Heap's minimum item</returns>
        public T Peek()
        {
            throw new NotImplementedException();
        }//end:Peek

        /// <summary>
        /// Returns minimum item from the heap's root 
        /// with the item deletion and heap reordering.
        /// For several equal minimum items an arbitrary item is returned.
        /// </summary>
        /// <returns>Heap's minimum item</returns>
        public T GetMin()
        {
            throw new NotImplementedException();
        }//end:GetMin

        #endregion//PublicMethods

    }//end:class Heap

}//end:namespace Heap
