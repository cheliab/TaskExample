using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class ParallelBreakExample
    {
        public static void Start()
        {
            var result = Parallel.For(1, 10, Factorial);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение было завершено на значении {result.LowestBreakIteration}");

            Console.ReadLine();
        }

        private static void Factorial(int x, ParallelLoopState pls) 
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;

                if (i == 5)
                    pls.Break();
            }

            Console.WriteLine($"Выполняется задание: {Task.CurrentId}");

            Console.WriteLine($"Факториал числа {x} равен {result}");
        }
    }
}