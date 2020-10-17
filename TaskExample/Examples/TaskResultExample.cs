using System;
using System.Threading.Tasks;

namespace TaskExample
{
    public class TaskResultExample
    {
        public static void Start()
        {
            Task<int> task = new Task<int>(() => Factorial(5));
            task.Start();
            
            // При использовании task.Result
            // основной поток останавливается и ждет пока выполнится Task
            Console.WriteLine($"Факториал числа 5 равен {task.Result}");
            
            Console.WriteLine("Start - end;");

            Console.ReadLine();
        }

        private static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}