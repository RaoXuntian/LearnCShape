using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Test
{
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

        public static async void Excute()
        {
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Start Excute " + DateTime.Now);
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
                Thread.Sleep(1000);
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
                Thread.Sleep(1000);
            });
            await Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2 " + DateTime.Now);
                Thread.Sleep(1000);
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
                Thread.Sleep(1000);
            }).GetAwaiter().GetResult();
            Task.Run(() =>
            {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run2 " + DateTime.Now);
                Thread.Sleep(1000);
            }).GetAwaiter().GetResult();
            Console.WriteLine(Thread.CurrentThread.GetHashCode() + " SingleNoAwait End " + DateTime.Now);
            return;
        }

    }
}
