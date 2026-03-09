using System.Formats.Asn1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Asynchronus_Programming
{
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Mainnnnn");
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Task<Egg> eggstask = FryEggsAsync(2);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "Mainnnnn");
            Task<Bacon> baconTask = FryBaconAsync(2);
          
            ValueTask<Toast> toasttask = Doyouwanttotoast();

        
            await Task.WhenAll(eggstask, baconTask);
           

        }

        private static Coffee PourCoffee()
        {
            return new Coffee();
        }
        public static async Task<Egg> FryEggsAsync(int countofeggs)
        {
            Console.WriteLine("warming the pan");
            await Task.Delay(10000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " EGGSSSSSSS");
            Console.WriteLine($"cracking {countofeggs} eggs");
            Console.WriteLine("cooking the eggs");
            //need to check about it
            await Task.Delay(3000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " MAINNNNN");

            Console.WriteLine("Put eggs on plate");

            return new Egg();

        }
        public static async Task<Bacon> FryBaconAsync(int countofbacons)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "bacon beginning");
            Console.WriteLine($"putting {countofbacons}  slices");
            await Task.Delay(2000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Bacon");

            for (int slice = 0; slice < countofbacons; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();

        }

        public static void applyingjam()
        {
            Console.WriteLine("applying jam");
        }
        public static async Task<Toast> toastingandapplyingjam()
        {
            Console.WriteLine("started toasting");
            await Task.Delay(5000);
            Console.WriteLine("toasting completed");
            return new  Toast();
        }
        public static async ValueTask<Toast> Doyouwanttotoast()
        {
            
            Console.WriteLine("if you want to toast press 1 else enter 0");
            int temp = int.Parse(Console.ReadLine());
            if(temp==0)
            {

                applyingjam();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "appppplying jam");
                return null;
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "toastedd");
                var task = toastingandapplyingjam();
               
                return await task;

           

            }

        }

    }
}
