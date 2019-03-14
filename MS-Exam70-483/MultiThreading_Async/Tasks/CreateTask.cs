using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.Tasks
{
    public class CreateTask
    {
        public static void DoWork()
        {
            Console.WriteLine("Work Starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work Finished");
        }

        public static void TaskCreation()
        {
            //Creates a Task
            Task newTask = new Task(() => DoWork());
            //Starts it running
            newTask.Start();
            //waits for task to complete
            newTask.Wait();
        }

        public static void Run()
        {
            //Creates ans starts the task
            Task newTask = Task.Run(() => DoWork());
            newTask.Wait();
        }
        public static int CalculateResult()
        {
            Console.WriteLine("Work Starting");
            Thread.Sleep(2000);
            Console.WriteLine("Work Finished");
            return 99;
        }
        public static void ReturnValue()
        {
            //creating task with return value
            Task<int> task = Task.Run(() => 
            {
                return CalculateResult();
            });
            //program waits when result property is read
            Console.WriteLine(task.Result);
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
        public static void DoWork(int i)
        {
            Console.WriteLine($"Task {i} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Task {i} finished");
        }
        public static void WaitAll()
        {
            Task[] tasks = new Task[10];
            for(int i=0; i<10; i++)
            {
                int taskNum = i; // makes a local copy of the loop counter so that the correct task number is
                //passed into the lambda expression.
                tasks[i] = Task.Run(() => DoWork(taskNum));
            }
            //Waits for all tasks to complete running
            Task.WaitAll(tasks);
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
        public static void HelloTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello");
        }

        public static void WorldTask()
        {
            Thread.Sleep(1000);
            Console.WriteLine("World");
        }
        public static void ContinuationTask()
        {
            Task task = Task.Run(() => HelloTask());
            //Starts executing this after completion of HelloTask.
            //if the antecedent task produces result, it can be supplied as input to continuation taks
            task.ContinueWith((prevTask) => WorldTask());
            //Overloads
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => WorldTask(), TaskContinuationOptions.OnlyOnFaulted);

            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }

        public static void DoChild(object state)
        {
            Console.WriteLine($"child {state} starting");
            Thread.Sleep(2000);
            Console.WriteLine($"Child {state} finished");
        }

        public static void ChildTasks()
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent Starts");
                //Child tasks can run independent of the parent or can be attached to parent
                //in the case of independent we can use Run method of task or explicitly state in 
                //task creation option
                for(int i=0;i<10; i++)
                {
                    int taskNo = i;
                    Task.Factory.StartNew(
                        (x) => DoChild(x),
                                taskNo,
                                TaskCreationOptions.AttachedToParent);
                }
            });

            parent.Wait();
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
    }
}