using System;
using System.Runtime.CompilerServices;
namespace Threading
{
    public class ThreadingEx
    {
         public static void Task1()
        {
            Console.WriteLine("For Loop for Even");
            for(int i = 0; i < 50; i += 2)
            {
                //slowing the process by 0.2 seconds
                Thread.Sleep(200);
                Console.Write(i+" ");
            }

        }
        public static void Task2()
        {
             Console.WriteLine("For Loop for Odd");
             for(int i = 1; i < 50; i += 2)
            {
                Thread.Sleep(200);
                Console.Write(i+" ");
            }

        }

        // if we dont mention datatype with async method it automatically consider void 
        // public async Task<string> FetchDataAsync(string url)
        // {
            
        // }

        // public async void FetchDataAsync(string url)
        // {
            
        // }
        //for calling async method , the method from where we2 are calling needs to be async AS WELL but main cant be async so need to create a seaprate method to call async if working on older version 


        public async Task CallMethod()
        {
            string result = await FetchDataAsync("https://google.com");
            Console.WriteLine(result);
            await AsyncMethod();
        }
        /// <summary>
        /// async method 
        /// </summary>
        /// <returns></returns>
        public static async Task AsyncMethod()
        {
            Console.WriteLine("Task started");
            await Task.Delay(3000);   //non-blocking delay
            Console.WriteLine("Task completed after 3 seconds");

        }
        /// <summary>
        /// asyn method FetchDataAsync .. Task - Preknown delegate 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response  = await client.GetStringAsync(url);
                return response;
            }
        }


        public static async Task Main()
        {
            ThreadingEx threading = new ThreadingEx();
            Console.WriteLine("before async call");
            await threading.CallMethod();

            Console.WriteLine("After async call");
            Console.ReadLine();
            
            // Thread t1 = new Thread(Task1);
            // Thread t2 = new Thread(Task2);
            // t1.Start(Task1);
            //Thread.Sleep(3000);
            // t2.Start(Task2);




            
        }
    }
}