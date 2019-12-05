using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = {0,1,2,3,4,5,6,7,8,9,};
            string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};
            // bool[] trueFalse = new bool[10] {true, false, true, false, true, false, true, false, true, false};
               List<string> flavors = new List<string>();
               flavors.Add("Vanilla");
               flavors.Add("Chocolate");
               flavors.Add("Banana");
               flavors.Add("Strawberry");
               flavors.Add("Mint");
            //    Console.WriteLine(flavors.Count);
            //    Console.WriteLine(flavors[2]);
            //    flavors.Remove("Banana");
            //    Console.WriteLine(flavors.Count);

            Dictionary<string,string> profile = new Dictionary<string,string>();
           Random rand = new Random();
           foreach(string name in names)
           {
             profile.Add(name, flavors[rand.Next(flavors.Count)]); 
           }
           foreach(var entry in profile)
           {
               Console.WriteLine(entry.Key + " - " + entry.Value);
           }
            
    
          


            
            
        }
    }
}
