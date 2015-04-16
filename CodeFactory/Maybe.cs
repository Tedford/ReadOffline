using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeFactory
{
    /// <summary>
    /// A representation of the Maybe Monad which represents a value that is 
    /// either a singleton value of <typeparamref name="T"/> or no value at all
    /// </summary>
    /// <typeparam name="T">The type of option contained within</typeparam>
    public class Maybe<T> : IEnumerable<T>
    {
        private IEnumerable<T> _item;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        public Maybe()
        {
            _item = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{T}"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="System.ArgumentNullException">item</exception>
        public Maybe(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _item = new[] { item };
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _item.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
