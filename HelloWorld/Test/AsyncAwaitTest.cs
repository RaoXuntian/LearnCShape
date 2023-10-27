using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod(), Owner("XuntianRao")]
        public void TestTaskWhenAny()
        {
            Assert.AreEqual(AsyncTestTaskWhenAny().ConfigureAwait(false).GetAwaiter().GetResult(), 1);
        }

        public async Task<int> AsyncTestTaskWhenAny()
        {
            var timeout = TimeSpan.FromSeconds(5);
            Task task = Task.Run(() => { 
                Console.WriteLine(Thread.CurrentThread.GetHashCode() + " Run1 " + DateTime.Now);
                Thread.Sleep(2000);
                throw new Exception("Mock an exp");
            });

            //if (!task.Wait(timeout))
            if (await Task.WhenAny(task, Task.Delay(timeout)).ConfigureAwait(false) != task)
            {
                Console.WriteLine("timeout!");
            }

            await task.ConfigureAwait(false);

            return 1;
        }

        [TestMethod(), Owner("XuntianRao")]
        public async Task TestWhenAllAsync()
        {
            var taskNames = new List<string> { "T1", "T2", "T3", "T4", "T5" };

            var tasks = taskNames.Select(name => MainTask(name)).ToList();

            foreach (var task in tasks)
            {
                await task;
            }
        }

        private async Task MainTask(string taskName)
        {
            Console.WriteLine($"[{taskName}] MainTask Start {DateTime.Now}");

            await SubTask(10);
            Console.WriteLine($"[{taskName}] SubTask1 End {DateTime.Now}");
            

            await SubTask(5);
            Console.WriteLine($"[{taskName}] SubTask2 End {DateTime.Now}");

            await SubTask(2);
            Console.WriteLine($"[{taskName}] SubTask3 End {DateTime.Now}");

            Console.WriteLine($"[{taskName}] MainTask End {DateTime.Now}");
        }

        private async Task SubTask(int sleepSeconds)
        {
            await Task.Delay(sleepSeconds * 1000);
        }
    }
}
