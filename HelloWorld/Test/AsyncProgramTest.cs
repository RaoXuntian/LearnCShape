using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Test
{
    [TestClass]
    public class AsyncProgramTest
    {
        //public static int NoAsyncTest()
        //{
        //    return 1;
        //}

        //public static async Task<int> AsyncTest()
        //{
        //    return 1;
        //}

        [TestMethod(), Owner("XuntianRao")]
        public void Test()
        {
            Excute();
        }

        public async void Excute()
        {
            Task t1 = new Task(() => {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task1 Start" + DateTime.Now);
                Thread.Sleep(10000);
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task1 End" + DateTime.Now);
            });
            Task t2 = new Task(() => {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task2 Start" + DateTime.Now);
                Thread.Sleep(8000);
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task2 End" + DateTime.Now);
            });
            t1.Start();
            t2.Start();
            t1.Wait();
            t2.Wait();
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Start Excute " + DateTime.Now);
            //await AsyncTest();
            await SingleAwait();
            await SingleNoAwait();
            //var waitTask = AsyncTestRun();
            //waitTask.Start();
            //int i = await waitTask;
            //Console.WriteLine(Thread.CurrentThread.GetHashCode() + " i " + i);
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " End Excute " + DateTime.Now);
        }

        public static async Task<int> AsyncTest()
        {
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1 " + DateTime.Now);
                Thread.Sleep(6000);
            }).GetAwaiter().GetResult();
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2 " + DateTime.Now);
                Thread.Sleep(4000);
            }).GetAwaiter().GetResult();
            return 1;
        }

        public static Task<int> AsyncTestRun()
        {
            Task<int> t = new Task<int>(() => {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1 " + DateTime.Now);
                Thread.Sleep(1000);
                return 100;
            });
            return t;
        }

        public static async Task SingleAwait()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest start " + DateTime.Now);
            await Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1 " + DateTime.Now);
                Thread.Sleep(8000);
            });
            await Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2 " + DateTime.Now);
                Thread.Sleep(2000);
            });
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " AwaitTest end " + DateTime.Now);
            return;
        }

        public static async Task SingleNoAwait()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " SingleNoAwait Start " + DateTime.Now);
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1 " + DateTime.Now);
                Thread.Sleep(5000);
            }).GetAwaiter().GetResult();
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2 " + DateTime.Now);
                Thread.Sleep(8000);
            }).GetAwaiter().GetResult();
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " SingleNoAwait End " + DateTime.Now);
            return;
        }

    }
}
