using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomeCollections
{
    public class Set<T> : IEnumerable<T> where T: class, IEqualityComparer<T>
    {
        private Dictionary<T, T> _set = new Dictionary<T, T>();

        public int Count => _set.Count;

        public Set(params T[] elements)
        {
            if (ReferenceEquals(elements, null))
                throw new ArgumentNullException(nameof(elements));
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        public bool Add(T item)
        {
            if (!_set.ContainsKey(item))
            {
                _set.Add(item, item);
                return true;
            }
            else
                return false;
        }

        public bool Remove(T item)
        {
            return _set.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
