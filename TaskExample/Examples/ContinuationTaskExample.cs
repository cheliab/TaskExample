using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class ContinuationTaskExample
    {
        public static void Start()
        {
            // первая задача
            Task taskFirst = new Task(() =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
                Thread.Sleep(3000);
            });
            
            // вторая задача (выполняем после завершения первой задачи)
            Task taskSecond = taskFirst.ContinueWith(Display);
            
            // Начинаем выполнять первое задание
            taskFirst.Start();

            // Ждем окончания задания
            taskSecond.Wait();

            Console.WriteLine("Start - End");

            Console.ReadLine();
        }

        private static void Display(Task lasTask)
        {
            Console.WriteLine($"id задачи: {Task.CurrentId}");
            Console.WriteLine($"id предыдушие задачи: {lasTask.Id}");
            
            Thread.Sleep(3000);
        }
    }
}