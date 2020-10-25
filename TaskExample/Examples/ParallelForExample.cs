using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class PallelForExample
    {
        public static void Start() 
        {
            Parallel.For(1, 10, Factorial);

            Console.ReadLine();
        }

        private static void Factorial(int x) 
        {
            int result = 1;

            for (int i = 1; i < x; i++)
            {
                result *= i;
            }

            Thread.Sleep(10000);

            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");

            Console.WriteLine($"Факториал числа {x} равен {result}");
        }
    }
}