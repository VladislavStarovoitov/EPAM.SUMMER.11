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

        public Set() { }

        public Set(params T[] elements): this((IEnumerable<T>)elements) { }

        public Set(IEnumerable<T> elements)
        {
            if (ReferenceEquals(elements, null))
                throw new ArgumentNullException(nameof(elements));
            foreach (var element in elements)
            {
                Add(element);
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

        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));
            foreach (var element in other)
            {
                Add(element);
            }
        }

        //just for fun
        public void UnionWith(Dictionary<T, T> other)
        {
            var result = _set.Union(other).Select<KeyValuePair<T, T>, T>(element => element.Key);
            var newSet = new Set<T>(result);
            _set = newSet._set;
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var result = _set.Keys.Intersect(other);
            _set.Clear();
            foreach (var element in result)
            {
                Add(element);
            }
        }

        public void DifferenceWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var result = _set.Keys.Intersect(other);
            foreach (var element in result)
            {
                Remove(element);
            }
        }

        public bool Contains(T item)
        {
            return _set.ContainsKey(item);
        }

        public void Clear()
        {
            _set.Clear();
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
