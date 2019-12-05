using System;

namespace WizardNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja n1 = new Ninja("arjun");
            n1.GetStats();
            Wizard w1 = new Wizard("brian");
            w1.GetStats();
            n1.GetStats();
            n1.Steal(w1);
            
        }
    }
}
