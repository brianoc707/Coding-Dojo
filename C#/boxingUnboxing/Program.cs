using System;
using System.Collections.Generic;


namespace boxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
        List<object> emptyList = new List<object>();
        emptyList.Add(7);
        emptyList.Add(28);
        emptyList.Add(-1);
        emptyList.Add(true);
        emptyList.Add("chair");
        int sum = 0;
        foreach(var item in emptyList)
        {
            if (item is int)
            {
                sum += (int)item;
            }
            
        }
        Console.WriteLine(sum);


        }
    }
}
