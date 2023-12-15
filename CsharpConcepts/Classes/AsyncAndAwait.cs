
using System.Diagnostics;

namespace CsharpConcepts.Classes
{
    public class AsyncAndAwait
    {
        public void DriverMethod()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Display1();
            DisplayNormal();
            Display2();
            Display3();
            stopwatch.Stop();
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine($"Time taken: {elapsedSeconds} seconds");
        }
        public async void Display1()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Display 1 execution Started");
                Thread.Sleep(3000);
            });
            Console.WriteLine("Display 1 execution finished");
        }

        public async void Display2()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Display 2 execution Started");
                Thread.Sleep(1000);
            });
            Console.WriteLine("Display 2 execution finished");
        }

        public async void Display3()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Display 3 execution Started");
                Thread.Sleep(4000);
            });
            Console.WriteLine("Display 3 execution finished");
        }
        public void DisplayNormal()
        {
                Console.WriteLine("DisplayNormal execution Started");
                Thread.Sleep(4000);
               Console.WriteLine("DisplayNormal execution finished");
        }

    }
}
