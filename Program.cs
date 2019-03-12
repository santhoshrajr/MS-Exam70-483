using System;
using System.Threading.Tasks;
using MS_Exam70_483.MultiThreading_Async.ParallelLINQ;
using MS_Exam70_483.MultiThreading_Async.TaskParallelLibrary;

namespace MS_Exam70_483
{
    public class Program
    {
        static void Main(string[] args)
        {
            PLinqAsParallel();
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
    }
}
