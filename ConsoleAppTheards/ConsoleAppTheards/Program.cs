using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppTheards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread dataThread = new Thread(DoWork);
            //dataThread.Start();
            //dataThread.Join();
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(string.Format("Main therad: {0}", i));
            //    Thread.Sleep(1000);
            //}
            //dataThread.Join();
            //Thread transactionThread = new Thread(() =>
            //{
            //    TransactionDeposit("Envelope Cat");
            //    //Thread.Sleep(10);
            //    //Thread.Sleep(100);
            //});
            //transactionThread.Start();
            //TransactionDeposit("Envelope Tom");
            //transactionThread.Join();

            //Thread transactionThread = new Thread(Close);
            //transactionThread.Start();
            ////TransactionDeposit("Envelope Tom");
            //transactionThread.Join();
            //Thread transactionThreadA = new Thread(Close);
            //transactionThreadA.Start();
            ////TransactionDeposit("Envelope Tom");
            //transactionThread.Join();

            Task task1 = Task.Run(() => Close("Envelope Tom"));
            Thread.Sleep(3000);
            Task task2 = Task.Run(() => Close("Envelope Cat"));
            Thread.Sleep(5000);
            Task task3 = Task.Run(() => Close("Envelope Mis"));
            //Task.WaitAll(task1, task2);
            Task.WaitAll(task1);
            Task.WaitAll(task2);
            Task.WaitAll(task3);
            Console.WriteLine("Main thread finished!");
            Console.ReadKey();
        }
        static void Close(string title)
        {
            Thread transactionThread = new Thread(() =>
            {
                TransactionDeposit(title);
            });
            transactionThread.Start();
            transactionThread.Join();
        }
        static void TransactionDeposit(string data)
        {
            Console.WriteLine(string.Format(">>>>>>> Start {0}", data));
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("Thread {0}: {1}", data, i));
                Thread.Sleep(1000);
            }
            Console.WriteLine(string.Format("Thread {0} Completed...", data));
        }

        static void DoWork()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("New therad: {0}", i));
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread Work Completed...");
        }
    }
}
