/*
 * Async and Await examples.
 * "I want to count to a big number but I don't want to wait for it to finish..."
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * 
 * 1. Run this as-is, note the elapsed time
 * 2. Uncomment the additional two calls to the asyunch logic
 * 3. Run again, note the elapsed time is not three times the number we got in step 1
 * 4. Conclude that the CountAsynchronously() method executes asynchronously to the rest of the code. 
 * 
 * 1. Run this as-is, note the elapsed time.
 * 2. Add some time-consuming logic to the 'la la la' section and then run it again, noting the elapsed time doesn't change much.
 * 3. Conclude that the CountAsynchronously() method executes asynchronously to the rest of the code. 
 
 Current time in milliseconds: DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond 
 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class AsyncDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling Demo()...");
            AsyncDemo asyncDemo = new AsyncDemo();
            asyncDemo.Demo();
            Console.WriteLine("Returned from Demo()...");

            // We can't simply end here because all the threads will be killed when the main thread ends. This is a common mistake we make: beware!
            Console.WriteLine("Back in the main() ! Press <Enter> and the entire program will terminate.");
            Console.ReadLine();
        }
        private async void Demo()
        {
            Console.WriteLine("Starting Demo()...");
            Task<int> MakeItCount = Task.Run(() => CountAsynchronously());  // NOT calling the method. Just declaring something
            //Task<int> MakeItCountAgain = Task.Run(() => CountAsynchronously());  // NOT calling the method. Just declaring something
            //Task<int> MakeItCountAgainAgain = Task.Run(() => CountAsynchronously());  // NOT calling the method. Just declaring something
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await MakeItCount;                 // NOW we call CountAsynchronously and we won't don't wait for it to finish.
            //await MakeItCountAgain;            // NOW we call CountAsynchronously (again) and we won't don't wait for it to finish.
            //await MakeItCountAgainAgain;            // NOW we call CountAsynchronously (again) and we won't don't wait for it to finish.
            // Right here we can do stuff while the CountAsynchronously method runs asynchronously relative to us
            // la la la ...
            //Console.Write("Counting in main thread...");  for (long i = 0; i < 5_000_000; i++) { } Console.WriteLine(" Done counting in main thread...");
            stopWatch.Stop();
            Console.WriteLine("Elapsed time in milliseconds = " + stopWatch.ElapsedMilliseconds);
        }
        private int CountAsynchronously()
        {
            Console.WriteLine("Starting to count asynchronously...");
//            for (long i = 0; i < long.MaxValue; i++)
            for (long i = 0; i < 5_000_000_000; i++)
            {
                // We're just counting...
            }
            Console.WriteLine("Done counting asynchronously.");
            return 1;
        }
    }
}
