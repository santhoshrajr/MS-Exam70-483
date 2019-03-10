using System;
using System.Threading.Tasks;
using MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary;

namespace MS_Exam70_483
{
    public class Program
    {
        static void Main(string[] args)
        {
            TPLManageParallel();
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
    }
}
