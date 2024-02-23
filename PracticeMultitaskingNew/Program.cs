using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMultitaskingNew
{
    
    internal class Program
    {
        //public delegate int DelegateEx(int x, int y);
        //static DelegateEx objofDelegate;

        static void Main(string[] args)
        {

            Task.Factory.StartNew(() => { Console.WriteLine("I'm Factory Method Task !"); });

            //objofDelegate += Sum;
            //objofDelegate += Sub;
            //objofDelegate(10, 20);
            //var list = objofDelegate.GetInvocationList();
            //foreach (var item in list)
            //{Console.WriteLine(item.ToString());}

            Console.WriteLine("Possible ways of creating task");
            Console.WriteLine("============================");
            Task.Factory.StartNew(() =>
            {
                CreateTaskusingFactoryMethod();
            });
            Task actionT = new Task(new Action(CreateTaskUsingAction));
            actionT.Wait(2000);
            actionT.Start();

            Task del = new Task(delegate { CreateTaskUsingDelegate(); });
            del.Wait(2000);
            del.Start();

            Task lambdaTask = new Task(() => CreateTaskUsingLambdaAndNamedMethod());
            lambdaTask.Wait(2000);
            lambdaTask.Start();

            CreateAsyncTask();

            Calculate(58, 2);

            Console.ReadKey();



        }

        private static void CreateTaskusingFactoryMethod()
        {
            Console.WriteLine("This Task is created using factory methhod");
        }

        static void CreateTaskUsingAAsync()
        {
            Console.WriteLine("This Task is created using Async");
        }
        static void CreateTaskUsingAction()
        {
            Console.WriteLine("This Task is created using Action Delegate");
        }
        static void CreateTaskUsingDelegate()
        {
            Console.WriteLine("This Task is created using   Delegate");
        }
        static void CreateTaskUsingLambdaAndNamedMethod()
        {
            Console.WriteLine("This Task is created using   Lambda and Named method");
        }
        static void CreateTaskUsingAsynAwait()
        {
            Console.WriteLine("This Task is created using   AsynAwait");
        }
        static async void CreateAsyncTask()
        {
            await Task.Run(() => CreateTaskUsingAAsync());
        }
        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Sub(int x, int y)
        {
            return x - y;
        }
        private static async void Calculate(int x, int y)
        {
            int result = await Task.FromResult(Add(x, y));
            int sub = await Task.FromResult(Sub(x, y));
            await Task.Delay(5000);
            Console.WriteLine($"{x}+{y}= {result} ,{x}-{y}={sub}");
        }

        //tumi 10 minite late

    }
       
}
