using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet b1 = new Buffet();
            Food f1 = b1.Serve();
         
            // Console.WriteLine(f1.Name);

            Ninja n1 = new Ninja();

        for(int i = 0; i <= 3; i++)
            {
                n1.Eat(f1);
            }
        }
    }
}
