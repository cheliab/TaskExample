using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class ParallelForEachExample
    {
        public static void Start() 
        {
            List<int> list = new List<int>{ 1, 2, 3, 4, 5 };
            var result = Parallel.ForEach<int>(list, Factorial);

            Console.ReadLine();
        }

        private static void Factorial(int x) 
        {
            int result = 1;

            for (int i = 1; i < x; i++)
            {
                result *= i;
            }

            Thread.Sleep(3000);

            Console.WriteLine($"Выполняется задача: {Task.CurrentId}");

            Console.WriteLine($"Факториал числа {x} равен {result}");
        }
    }
}