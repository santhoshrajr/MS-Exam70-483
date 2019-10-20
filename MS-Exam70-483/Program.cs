using System;
using System.Threading;
using System.Threading.Tasks;
using MS_Exam70_483.DependencyInjection;
using MS_Exam70_483.MultiThreading_Async.ParallelLINQ;
using MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary;
using MS_Exam70_483.MultiThreading_Async.Tasks;
using MS_Exam70_483.MultiThreading_Async.Threads;

namespace MS_Exam70_483
{
    class Program
    {
        public static async Task Main(string[] args)
        {
             await Async();
            
        }
        public static void TPLInvoke()
        {
            ParallelInvoke.Process();
        }

        public static void TPLForEach()
        {
            ParallelForEach.Process();
        }
        public static void TPLFor()
        {
            ParallelFor.Process();
        }
        public static void TPLManageParallel()
        {
            ManageParallelLoop.Process();
        }
        public static void PLinqAsParallel()
        {
            Person person = new Person();
            person.PLinq();
            person.PLinq_ForceParalleization();
            person.PLinq_AsOrdered();
            person.Plinq_AsSequential();
            person.Plinq_ForAll();
            person.Plinq_Exception();
        }
        public static void Tasks()
        {
            CreateTask.TaskCreation();
            CreateTask.Run();
            CreateTask.ReturnValue();
            CreateTask.WaitAll();
            CreateTask.ContinuationTask();
            CreateTask.ChildTasks();
        }
        public static async Task<double> Async()
        {
            AsyncAwait asyncAwait = new AsyncAwait();
            return await asyncAwait.GetAverageAsync(1000000000);
        }
        public static void ThreadMethods()
        {
            Threads.CreateThread();
            Threads.CreateThreadLambda();
            Threads.PassDataToThread();
            Threads.PassDataToThreadLambda();
            //Threads.AbortThread();
            Threads.AbortThreadBySharedVariable();
            Threads.ThreadSynchronization();
            Threads.ThreadLocal();
            Thread.CurrentThread.Name = "Main Method";
            Threads.DisplayThread(Thread.CurrentThread);
            Threads.ThreadPoolQueue();
        }
    }
}
