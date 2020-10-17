using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    public class InnerTask
    {
        /// <summary>
        /// Пример с вложенной задачей
        /// </summary>
        public static void StartExample()
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
        public static void StartAttachedExample()
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
    }
}