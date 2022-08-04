using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Test
{
    [TestClass]
    public class AsyncAwaitTest
    {
        [TestMethod(), Owner("XuntianRao")]
        public void Test()
        {
            //var res = AsyncAwaitTestAsync().Result;
            var res = AsyncAwaitTestCase();
            Assert.AreEqual(res, 7);
        }

        public int AsyncAwaitTestCase()
        {
            Task<string> task1 = TaskOneAsync();
            Task tb = DoIndependentWorkAsync("B-");
            //Task tt = DoIndependentWorkAsync("D-");

            DoIndependentWork("A-");

            string contents = task1.ConfigureAwait(false).GetAwaiter().GetResult();
            //string contents = await TaskOneAsync().ConfigureAwait(false);

            //await tb;
            //tt.ConfigureAwait(false);

            DoIndependentWorkAsync("C-").ConfigureAwait(false).GetAwaiter().GetResult();

            return contents.Length;
        }

        public async Task<int> AsyncAwaitTestAsync()
        {
            Task<string> task1 = TaskOneAsync();
            Task tb = DoIndependentWorkAsync("B-");
            //Task tt = DoIndependentWorkAsync("D-");

            DoIndependentWork("A-");

            string contents = await task1;
            //string contents = await TaskOneAsync().ConfigureAwait(false);

            //await tb;
            //tt.ConfigureAwait(false);

            await DoIndependentWorkAsync("C-");

            return contents.Length;
        }

        public async Task<string> TaskOneAsync()
        {
            await Task.Run(() => {
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task1 Start" + DateTime.Now);
                Thread.Sleep(20000);
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " task1 End" + DateTime.Now);
            }).ConfigureAwait(false);

            return "TaskOne";
        }

        public void DoIndependentWork(string prefix = "")
        {
            for (int i=0; i<10; ++i)
            {
                Console.WriteLine(prefix + "Working..." + i + "..." + DateTime.Now + "..." + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
        }

        public async Task DoIndependentWorkAsync(string prefix = "")
        {
            for (int i = 0; i < 10; ++i)
            {
                await Task.Run(() => {
                    Console.WriteLine(prefix + "Working..." + i + "..." + DateTime.Now + "..." + Thread.CurrentThread.GetHashCode());
                    Thread.Sleep(5000);
                }).ConfigureAwait(false);
            }
        }
    }
}
