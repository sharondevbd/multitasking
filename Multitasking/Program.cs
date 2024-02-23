using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multitasking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskExecMethod();
            
            
            Console.ReadLine();
        }


        public static void TaskExecMethod()
        {
            Thread.Sleep(4000);
            var nourinTask = Task.Run(() => { return (10 * 20); });
            var result = nourinTask.GetAwaiter().GetResult();
            Console.WriteLine(result);
            var result2 = nourinTask.GetAwaiter();
            result2.OnCompleted(() => { Console.WriteLine("My Work is done for Nourin Task"); });
            
            
        }
        

        public static void Exec()
        {

            var task = Task.Run(() => { return add() * add2(50);});

            var firstResult = task.GetAwaiter().GetResult();
            Console.WriteLine(firstResult);

            var task1 = Task.Run(() =>
            {
                return add();
            });
            var result = task1.GetAwaiter();
            result.OnCompleted(() =>
            {
                Console.WriteLine(add2(result.GetResult()));
            });
        }
        

        public static int add()
        {
            Thread.Sleep(4000);
            Console.Write("First Output: ");
            return 10;
        }
        public static int add2(int z)
        {
            Console.Write("Secound Output: ");
            return 10;
        }
    }
}
