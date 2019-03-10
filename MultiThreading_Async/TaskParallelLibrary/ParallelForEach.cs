using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary
{
    public class ParallelForEach
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: "+ item);
            Thread.Sleep(100);
            Console.WriteLine($"Finished working on: {item}");
        }
        
        public static void Process()
        {
            var items = Enumerable.Range(0,500);
            //Performs a parallel implementation of the foreach loop construction.
            //takes in two parameters one is IEnumerable, second is the action to be performed on each.
            //Since parallel execution taks are not completed in the way they are started
            Parallel.ForEach(items, item => WorkOnItem(item));
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
    }
}