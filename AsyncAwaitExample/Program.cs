using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Application thread ID: {Thread.CurrentThread.ManagedThreadId}");
            var stuff = new AsyncAwaitDemo();
            var t = stuff.DoStuff();
            t.Wait();
            Console.WriteLine($"Finished on thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadLine();
        }
    }

    public class AsyncAwaitDemo
    {
        public Task DoStuff()
        {
            return Task.Run(() =>
            {
                LongRunningOperation();
            });
        }

        private void LongRunningOperation()
        {
            int counter;

            for (counter = 0; counter < 50; counter++)
            {
                Console.WriteLine($"{counter} from Task thread ID: {Thread.CurrentThread.ManagedThreadId}");

            }
        }
    }
}
