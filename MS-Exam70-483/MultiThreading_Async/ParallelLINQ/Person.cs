using System;
using System.Linq;
namespace MS_Exam70_483.MultiThreading_Async.ParallelLINQ
{
    public class Person
    {
        public string Name { get; set; }

        public string City { get; set; }

        public Person[] peopleArray {get;set;}
        public void Initialize()
        {
            Person[] personArray = new Person[] {
                new Person  {Name = "Alan", City = "Hull"},
                new Person  {Name = "Beryl", City = "Seattle"},
                new Person  {Name = "Charles", City = "London"},
                new Person  {Name = "David", City = "Seattle"},
                new Person  {Name = "Eddy", City = "Paris"},
                new Person  {Name = "Fred", City = "Berlin"},
                new Person  {Name = "Gordon", City = "Hull"},
                new Person  {Name = "Henry", City = "Seattle"},
                new Person  {Name = "Issac", City = "Seattle"},
                new Person  {Name = "James", City = "Londond"},
            };
            peopleArray = personArray;
        }
        public void InitializeEmptyCity()
        {
            Person[] personArray = new Person[] {
                new Person  {Name = "Alan", City = ""},
                new Person  {Name = "Beryl", City = "Seattle"},
                new Person  {Name = "Charles", City = "London"},
                new Person  {Name = "David", City = "Seattle"},
                new Person  {Name = "Eddy", City = "Paris"},
                new Person  {Name = "Fred", City = "Berlin"},
                new Person  {Name = "Gordon", City = "Hull"},
                new Person  {Name = "Henry", City = "Seattle"},
                new Person  {Name = "Issac", City = "Seattle"},
                new Person  {Name = "James", City = "Londond"},
            };
            peopleArray = personArray;
        }
        public  void PLinq()
        {
            Initialize();
            //usage of AsParallel
            //determines if running parallely improves performance. if so,
            //breaks into number of processes and executes concurrently.
            //When using AsParallel, query design should be made keeping this in mind
            var result = from person in peopleArray.AsParallel()
                         where person.City == "Seattle"
                         select person;
            
            foreach(var person in result)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
        public void PLinq_ForceParalleization()
        {
            Initialize();
            //Forcing parallization whether performance is improved or not 
            //with the query executed on a maximum of four processors
            //All parallel query output is not in the same order as input
            var result = from person in peopleArray.AsParallel().
                         WithDegreeOfParallelism(4).
                         WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         where person.City == "Seattle"
                         select person;
            foreach(var person in result)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }

        public void PLinq_AsOrdered()
        {
            Initialize();
            //This can impact performance but provides output in the same order as input
            var result = from person in peopleArray.AsParallel().
                         AsOrdered()
                         where person.City == "Seattle"
                         select person;
            foreach(var person in result)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }

        public void Plinq_AsSequential()
        {
            Initialize();
            //parallel query many remove ordering of complext query. AsSequential preserves sequential ordering
            //Identifying elements of a parallel query as sequential
            var result = (from person in peopleArray.AsParallel()
                         where person.City == "Seattle"
                         orderby(person.Name)
                         select new
                         {
                             Name = person.Name
                         }).AsSequential().Take(4);
            foreach(var person in result)
            {
                Console.WriteLine(person.Name);
            }
            Console.WriteLine("Finished Processing. Press a key to end sequential");
            Console.ReadKey();
        }
        public void Plinq_ForAll()
        {
            Initialize();
            //ForAll iterate through all elements of query
            //differs from foreach, ForAll does iteration and parallel and will start before the query is complete
            //The ordering of output is not the same as input
            Console.WriteLine("ForAll");
             
             var result = (from person in peopleArray.AsParallel()
                         where person.City == "Seattle"
                         select person);
            result.ForAll(person => Console.WriteLine(person.Name));            
            Console.WriteLine("Finished Processing. Press a key to end");
            Console.ReadKey();
        }
        public bool CheckCity(string name)
        {
            if(name == "")
                throw new ArgumentException(name);
            return name == "Seattle";
        }

        public void Plinq_Exception()
        {
            //HandlingExceptions in Parallel queries
            try
            {
                InitializeEmptyCity();
                 var result = (from person in peopleArray.AsParallel()
                         where CheckCity(person.City)
                         select person); 
                result.ForAll(person => Console.WriteLine(person));
            }
            catch(AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions.Count + "exceptions.");
            }
        }
    }
}