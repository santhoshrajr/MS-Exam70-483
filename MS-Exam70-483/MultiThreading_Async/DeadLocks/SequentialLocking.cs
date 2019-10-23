using System;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.DeadLocks
{
    public class SequentialLocking
    {
        static object lock1 = new object();
        static object lock2 = new object();

        static void Method1()
        {
            lock(lock1)
            {
                Console.WriteLine("Method 1 got lock1");
                Console.WriteLine("Method 1 waiting for lock2");
                lock(lock2)
                {
                    Console.WriteLine("Method 1 got lock 2");
                }
                Console.WriteLine("Method 1 released lock 2");
            }
            Console.WriteLine("Method 1 released lock 1");
        }
        
        static void Method2()
        {
            lock(lock2)
            {
                Console.WriteLine("Method 2 got lock2");
                Console.WriteLine("Method 2 waiting for lock1");
                lock(lock1)
                {
                    Console.WriteLine("Method 2 got lock 1");
                }
                Console.WriteLine("Method 2 released lock 1");
            }
            Console.WriteLine("Method 2 released lock 2");
        }

        static void SequentialExecution()
        {
            Method1();
            Method2();
            Console.WriteLine("Methods Complete. Press any key to exit");
        }

        static void DeadLockedTasks()
        {
            Task t1 = Task.Run(() => Method1());
            Task t2 = Task.Run(() => Method2());
            Console.WriteLine("Waiting for Task2");
            t2.Wait();
            Console.WriteLine("Methods Complete. Press any key to exit");
        }


    }
}