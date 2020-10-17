using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class ArrayOfTask
    {
        /// <summary>
        /// Массив заданий
        /// </summary>
        public static void StartExample()
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

        public static void StartSecondExample()
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
    }
}