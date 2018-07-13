using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
namespace MyBatchApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> jobs = new List<Task>();
            //start 20 background tasks that will keep the CPU bussy
            for (int i = 0; i < 20; i++)
            {
                string id = "super busy worker  " + i;
                jobs.Add(Task.Factory.StartNew(new Action<object>(Run), id));
            }
            //do not exit, continue forever
            Task.WaitAll(jobs.ToArray());
        }

        public static void Run(Object param)
        {
            while (true)
            {
                //sleep for 500ms so we won't burn all CPU
                string stamp = DateTime.Now.ToString("HH:mm:ss") + "-->" 
                    + Math.Sqrt(DateTime.Now.Millisecond);

                Console.WriteLine($"{param}:{stamp}");
            }
        }
    }
}
