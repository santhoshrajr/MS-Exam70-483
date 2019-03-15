using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MS_Exam70_483.MultiThreading_Async.Threads
{
    public class Threads
    {
        public static void ThreadHello()
        {
            Console.WriteLine("Hello from the thread");
            Thread.Sleep(1000);
        }
        public static void CreateThread()
        {
            //pass in method name to the thread constructor to create a thread 
            Thread thread = new Thread(ThreadHello);
            //Start method runs the thread to completion.
            thread.Start();
        }

        public static void CreateThreadLambda()
        {
            //Creating a thread using lambda expression 
            Thread thread = new Thread(() => 
            {
                Console.WriteLine("Hello from the thread");
                Thread.Sleep(1000);
            });
            thread.Start();
            Console.WriteLine("Press a key to end");
            Console.ReadLine();
        }
        public static void WorkOnData(object data)
        {
            Console.WriteLine($"Working on data :{data}");
            Thread.Sleep(1000);
        }
        public static void PassDataToThread()
        {
            //using parameterized we can pass data to thread by object reference
            ParameterizedThreadStart ps = new ParameterizedThreadStart(WorkOnData);
            Thread thread = new Thread(ps);
            thread.Start(99);
        }
        public static void PassDataToThreadLambda()
        {
            //passing data to thread using lambda 
            Thread thread = new Thread((data) =>
            {
                WorkOnData(data);
            });
            thread.Start(99);
        }

        public static void AbortThread()
        {
            Thread tickThread = new Thread(() =>
            {
                while(true)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });
            tickThread.Start();
            Console.WriteLine("Press a key to stop the clock");
            //This would stop the thread instantly leaving program in ambiguous state
            //Throws Platform Not Supported Exception
            tickThread.Abort();
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        public static void AbortThreadBySharedVariable()
        {
            var tickRunning = true;
            Thread tickThread = new Thread(() =>
            {
                while (tickRunning)
                {
                    Console.WriteLine("Tick");
                    Thread.Sleep(1000);
                }
            });
            tickThread.Start();
            Console.WriteLine("Press a key to stop the clock");
            //This would stop the loop thereby stops the thread from execution
            tickRunning = false;
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        public static void ThreadSynchronization()
        {
            Thread threadToWaitFor = new Thread(() =>
            {
                Console.WriteLine("Thread Starting");
                Thread.Sleep(2000);
                Console.WriteLine("Thread Done");
            });
            threadToWaitFor.Start();
            Console.WriteLine("Joining Thread");
            //Main thread waits for threadToWaitFor to complete
            threadToWaitFor.Join();
            Console.WriteLine("Press a key to exit");
            Console.ReadLine();
        }


        public static ThreadLocal<Random> RandomGenrator = new
            ThreadLocal<Random>(() =>
            {
                return new Random(2);
            });

        public static void ThreadLocal()
        {
            Thread t1 = new Thread(() =>
            {
                for(int i=0;i<5;i++)
                {
                    Console.WriteLine($"t1: {RandomGenrator.Value.Next(10)}");
                    Thread.Sleep(500);
                }
            });
            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"t2: {RandomGenrator.Value.Next(10)}");
                    Thread.Sleep(500);
                }
            });
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }

        public static void DisplayThread(Thread t)
        {
            Console.WriteLine($"Name {t.Name}");
            Console.WriteLine($"Culture {t.CurrentCulture}");
            Console.WriteLine($"Is Background? {t.IsBackground}");
            Console.WriteLine($"Context {t.ExecutionContext}");
            Console.WriteLine($"Priority {t.Priority}");
            Console.WriteLine($"Is Pool? {t.IsThreadPoolThread}");
        }

        public static void DoWork(object state)
        {
            Console.WriteLine($"Doing work on state: {state}");
            Thread.Sleep(500);
            Console.WriteLine($"Work finished on state: {state}");
        }
        public static void ThreadPoolQueue()
        {
            for(int i=0;i<50;i++)
            {
                int stateNumber = i;
                ThreadPool.QueueUserWorkItem(state => DoWork(stateNumber));
            }
            Console.ReadKey();
        }

    }
}
