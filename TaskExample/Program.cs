using System;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        private static void SimpleTaskExample()
        {
            Task task = new Task(() => Console.WriteLine("Hello simple task!"));
            task.Start();

            Task.Factory.StartNew(() => Console.WriteLine("Hello from factory!"));

            Task.Run(() => Console.WriteLine("Hello from run!"));
        } 
        
        static void Main(string[] args)
        {
            SimpleTaskExample();
            
            Console.ReadLine();
        }
    }
}