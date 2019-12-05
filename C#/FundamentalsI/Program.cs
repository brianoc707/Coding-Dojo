using System;

namespace FundamentalsI
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i%3  == 0 && i%5 == 0){
                    Console.WriteLine($"FizzBuzz - {i}");
                }
            else
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine($"Fizz - {i}");
                }
                if(i % 5 == 0)
                {
                    Console.WriteLine($"Buzz - {i}");
                }
            }
            
        

                // int i = 1;
                // while (i <= 100)
                //{
                //     if (i%3  == 0){ 
                //         Console.WriteLine("Fizz");
                        
                //     }
                //     if (i%5  == 0){  
                //         Console.WriteLine("Buzz");
                        
                //     }
                //     if (i%3  == 0 && i%5 == 0){
                //         Console.WriteLine("FizzBuzz");
                        
                //         }
                //     i = i+1;
                //}
            } 
        }
    }
}
