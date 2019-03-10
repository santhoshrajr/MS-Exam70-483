using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary
{
    public class ParallelFor
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: "+ item);
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on: {item}");
        }
        public static void Process()
        {
            var items = Enumerable.Range(0,500).ToArray();
            //Performs a parallel implementation of the for loop construction.
            Parallel.For(0, items.Length, i =>WorkOnItem(items[i]));
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
    }
}