namespace ConsoleApplication1
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    class EventLogSample
    {
        public static void Main()
        {
            var app = new EventLogSample();
            app.Do();
        }

        public void Do()
        {
            Console.WriteLine(Assembly.GetAssembly(this.GetType()));

            Task.Run(() => { }).ContinueWith(t => t, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}