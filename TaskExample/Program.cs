using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        /// <summary>
        /// Простой пример запуска задачи 
        /// </summary>
        private static void SimpleTaskExample()
        {
            Task task = new Task(() => Console.WriteLine("Hello simple task!"));
            task.Start();

            Task.Factory.StartNew(() => Console.WriteLine("Hello from factory!"));

            Task.Run(() => Console.WriteLine("Hello from run!"));
            
            Console.WriteLine("End of Main");

            Console.ReadLine();
        }

        /// <summary>
        /// Пример с вложенной задачей
        /// </summary>
        private static void InnerTaskExample()
        {
            // Внешняя задача
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task - Start");

                // Внутренная задача
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task - Start");
                    Thread.Sleep(5000); // ждем 5 сек.
                    Console.WriteLine("Inner task - End");
                });
                
                Console.WriteLine("Outer task - End");
            });
            outer.Wait();
            
            Console.WriteLine("End of Main");

            Console.ReadLine();
        }
        
        /// <summary>
        /// Пример с вложенной задачей
        /// </summary>
        private static void InnerTaskAttachedExample()
        {
            // Внешняя задача
            var outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task - Start");

                // Внутренная задача
                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task - Start");
                    Thread.Sleep(5000); // ждем 5 сек.
                    Console.WriteLine("Inner task - End");
                }, TaskCreationOptions.AttachedToParent);
                
                Console.WriteLine("Outer task - End");
            });
            outer.Wait();
            
            Console.WriteLine("End of Main");

            Console.ReadLine();
        }

        /// <summary>
        /// Массив заданий
        /// </summary>
        private static void ArrayOfTaskExample()
        {
            Task[] taskArr = new Task[3]
            {
                new Task(() => Console.WriteLine("First task")),
                new Task(() => Console.WriteLine("Second task")),
                new Task(() => Console.WriteLine("Third task"))
            };

            foreach (var task in taskArr)
            {
                task.Start();
            }
            
            // Ждем завершения любой из задач
            Task.WaitAny(taskArr);
            
            Console.WriteLine("Main - end");
        }

        private static void ArrayOfTaskSecondExample()
        {
            Task[] tasks = new Task[3];

            int j = 1;
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(5000);
                    Console.WriteLine($"Task {j++}");
                });
            }
            
            // // Ждать пока завершатся задания
            // Task.WaitAll(tasks);
            
            // Ждем завершения любой задачи
            Task.WaitAny(tasks);

            Console.WriteLine("Main - end");

            Console.ReadLine();
        }
        
        static void Main(string[] args)
        {
            // SimpleTaskExample();
            // InnerTaskExample();
            // InnerTaskAttachedExample();
            // ArrayOfTaskExample();
            ArrayOfTaskSecondExample();
        }
    }
}