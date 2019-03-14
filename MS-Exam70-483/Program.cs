﻿using System;
using MS_Exam70_483.MultiThreading_Async.ParallelLINQ;
using MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary;
using MS_Exam70_483.MultiThreading_Async.Tasks;

namespace MS_Exam70_483
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks();
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
    }
}