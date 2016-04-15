namespace ListWriteThreadSafe
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var tasks = new List<Task>();
            var list = new ThreadSafeList<int>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 10000; j++)
                    {
                        list.Add(j);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(list.Count);
        }
    }

    public class ThreadSafeList<T>
    {
        private object _locker = new object();
        private List<T> list = new List<T>();

        public void Add(T item)
        {
            lock (_locker)
            {
                this.list.Add(item);
            }
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }
    }
}
