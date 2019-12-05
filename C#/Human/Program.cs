using System;

namespace Human
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Human h1 = new Human("Brian", 3, 3, 3, 100);
            h1.GetStats();
            Human h2 = new Human("Arjun", 3, 3, 3, 100);
            h2.GetStats();

            h2.Attack(h1);
            h1.GetStats();

        }
    }
}
