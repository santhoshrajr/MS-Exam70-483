using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary
{
    //Task is an abstraction of unit of work.
    //work is described by code, method or lambda expression
    public class ParallelInvoke
    {
        //Creating two tasks to pass to invoke method as action delegates
        public static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        public static void Task2()
        {
            Console.WriteLine("Task 2 Starting");
            Thread.Sleep(1000);
            Console.WriteLine("Task 2 Ending");
        }
        //Invoke method accepts no. of action delegates and creates task for each of them
        //Action delegates encapsulates methods that do not have parameters and return values
        public static void Process() 
        {
            //starts large number of tasks at once. No control over the order in which the tasks 
            //are started or assigned to processor. It returns after all tasks have completed.
            Parallel.Invoke(()=>Task1(),() => Task2());
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
    }
}