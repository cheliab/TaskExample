using System;
using System.Threading.Tasks;

namespace TaskExample
{
    public class SimpleTask
    {
        /// <summary>
        /// Простой пример запуска задачи 
        /// </summary>
        public static void Start()
        {
            Task task = new Task(() => Console.WriteLine("Hello simple task!"));
            task.Start();

            Task.Factory.StartNew(() => Console.WriteLine("Hello from factory!"));

            Task.Run(() => Console.WriteLine("Hello from run!"));
            
            Console.WriteLine("End of Main");

            Console.ReadLine();
        }
    }
}