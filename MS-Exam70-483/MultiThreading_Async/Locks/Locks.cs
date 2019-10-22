using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.Locks
{
    public class Locks
    {
        //Single Task running
        //Adding numbers in the array upto 50000000
        static int[] items = Enumerable.Range(0,50000001).ToArray();
        static void SumOfArray()
        {
            long total = 0;
            for(int i=0;i<items.Length;i++)
            {
                total += items[i];
            }
            Console.WriteLine($"The total is {total}");
            Console.ReadLine();
        }

        //Bad Task Interaction
        static long sharedTotal;
        static void AddRangeOfvalues(int start,int end)
        {
            while(start<end)
            {
                sharedTotal += items[start];
                start++;
            }
        }


        static void BadTaskCreation()
        {
            List<Task> tasks = new List<Task>();
            int rangeSize = 1000;
            int rangeStart = 0;
            while(rangeStart < items.Length)
            {
                int rangeEnd = rangeStart+rangeSize;
                if(rangeEnd > items.Length)
                {
                    rangeEnd = items.Length;
                }
                //create local copies of the parameters
                int rs = rangeStart;
                int re = rangeEnd;
                tasks.Add(Task.Run(() => AddRangeOfvalues(rs,re)));
                rangeStart = rangeEnd;
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Th total is{sharedTotal}");
        }

        static readonly object sharedTotalLock = new object();
        
        static void AddRangeOfValuesUsingLock(int start, int end)
        {
            while(start < end)
            {
                lock (sharedTotalLock)
                {
                    sharedTotal+=items[start];
                }
                start++;
            }
        }

        static void AddRangeOfValuesUsingSensibleLock(int start, int end)
        {
            long subTotal = 0;
            while(start < end)
            {
                subTotal = subTotal+items[start];
                start++;
            }
            lock(sharedTotalLock)
            {
                sharedTotal = sharedTotal+subTotal;
            }
        }
    }
}