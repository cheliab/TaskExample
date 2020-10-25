using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class PallelInvokeExample
    {
        public static void Start() 
        {
            Parallel.Invoke(Display,
            () => {
                Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
            }, () => Factorial(5));

            Console.ReadLine();
        }

        private static void Display() 
        {
            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");
            Thread.Sleep(3000);
        }

        private static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");

            Thread.Sleep(3000);

            Console.WriteLine($"Результат {result}");
        }
    }
}