using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MS_Exam70_483.MultiThreading_Async.Tasks
{
    public class AsyncAwait
    {
        //Synchronous execution of a long running operation
        //The following function calcualte averages for given 
        //number of random number. Lets say the value is very large
        //and it takes significant time to compute. In that scenario 
        //its better to execute this method asynchronously 
        //so that it wont block any user actions
        private double ComputeAverages(long noOfValues)
        {
            double total = 0;
            Random rand = new Random();
            for(long values=0; values<noOfValues; values++)
            {
                total += rand.NextDouble();
            }
            return total/noOfValues;
        }

        //Creating a task for the long running background operation
        //which can be run asynchronously
        private  Task<double> AsyncComputeAverages(long noOfValues)
        {
            return Task<double>.Run(() => 
            {
               return  ComputeAverages(noOfValues);
            });
        }
        //Executing the task asynchronously
        //async method indicates the method will run the task in background
        //
        public async Task<double> GetAverageAsync(long noOfValues)
        {
            Task<double> taskResult = AsyncComputeAverages(noOfValues);
            //Do Independent work
            Console.WriteLine($"Calculating Average for {noOfValues} random numbers");
            //Await when the result is needed
            //control returns back to main t
            double result = await taskResult;
            Console.WriteLine($"Result is {result}");
            return result;
        }

        private async Task<string> FetchWebPage(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

        private async Task<IEnumerable<string>> FetchWebPages(string []urls)
        {
            var tasks = new List<Task<string>>();
            foreach(var url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }
            return await Task.WhenAll(tasks);
        }
        private async void GetWebPage(string url)
        {
            try
            {
                string result = await FetchWebPage(url);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured in FetchWebPage{ex.Message}");
            }
        }
    }
}