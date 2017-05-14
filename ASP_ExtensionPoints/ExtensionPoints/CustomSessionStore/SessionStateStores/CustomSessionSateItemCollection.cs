namespace CustomSessionStore.SessionStateStores
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Specialized;
    using System.Web.SessionState;

    public class CustomSessionSateItemCollection : ISessionStateItemCollection
    {
        private static ConcurrentDictionary<int, object> dataByInt = new ConcurrentDictionary<int, object>();
        private static ConcurrentDictionary<string, object> dataByString = new ConcurrentDictionary<string, object>();
        private bool dirty;
        private bool isSynchronized;

        public object this[int index]
        {
            get
            {
                return dataByInt[index];
            }

            set
            {
                dataByInt[index] = value;
            }
        }

        public object this[string name]
        {
            get
            {
                object value = null;
                dataByString.TryGetValue(name, out value);

                return value;
            }

            set
            {
                dataByString[name] = value;
            }
        }

        public int Count
        {
            get
            {
                return dataByInt.Count + dataByString.Count;
            }
        }

        public bool Dirty
        {
            get
            {
                return this.dirty;
            }

            set
            {
                this.dirty = value;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.isSynchronized;
            }
        }

        public NameObjectCollectionBase.KeysCollection Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}