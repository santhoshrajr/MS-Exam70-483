using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary
{ 
    public class ManageParallelLoop
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
            //using loopstate to manage the loop to terminate the execution when the value is 200
            //ParallelLoopResult is used to determine whether or not a parallel loop has successfully completed
            ParallelLoopResult result =  Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {
                //when stop is used to break the execution, parallel loop result will be false with a null lowestbreakiteration
                //if break is used to stop the execution, parallel loop result will be true with a non-null lowestbreakiteration.
                if(i == 200)
                loopState.Stop();
                WorkOnItem(items[i]);
            });
            Console.WriteLine($"Completed: {result.IsCompleted}");
            Console.WriteLine($"Items:{result.LowestBreakIteration}");
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
    }
}