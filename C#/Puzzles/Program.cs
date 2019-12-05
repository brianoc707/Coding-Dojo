using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
    
    public static List<int> RandomList()
    {
        Random rand = new Random();        
        List<int> newList = new List<int>();
        for(int i = 0; i <= 10; i ++)
        {
            newList.Add(rand.Next(5,25));
        }
        return newList;


    }
    public static string TossCoin()
    {
        Console.WriteLine("Tossing a Coin!");
        List<string> toss = new List<string>();
        toss.Add("Heads");
        toss.Add("Tails");
        Random rand = new Random();
        int i = rand.Next(0,2);
        int j = 0;
        if(toss[i] == toss[j])
        {
            Console.WriteLine("Heads!");
        }
        else
        {
            Console.WriteLine("Tails!");

        }
        string x = toss[i];
        return x;
    }
    public static double TossMultipleCoins(int num)
    {   
        int headtoss = 0;
        for(int i = 0; i < num; i++)
        {
            string x = TossCoin();
            if(x == "Heads")
            {
            headtoss += 1;
            }
        }
        Console.WriteLine(headtoss);
        double ratio = (double)headtoss / (double)num;
        Console.WriteLine(ratio);
        return ratio;
        
    }
    public static void Names()
        {
            List<string> namez = new List<string>();
            namez.Add("Todd");
            namez.Add("Tiffany");
            namez.Add("Charlie");
            namez.Add("Geneva");
            namez.Add("Sydney");

            List<string> randomList = new List<string>();

            Random r = new Random();
            int randomIndex = 0;
            while (namez.Count > 0)
            {
                randomIndex = r.Next(0, namez.Count); 
                randomList.Add(namez[randomIndex]);
                namez.RemoveAt(randomIndex);
            }
            foreach (string name in randomList)
            {
                Console.WriteLine(name);
            }
            List<string> shortNames = new List<string>();
            foreach (string name in randomList)
            {
                if (name.Length >= 5)
                {
                    shortNames.Add(name);
                }
            }
            Console.WriteLine(String.Join(", ",shortNames));
        }
        static void Main(string[] args)
        {
            // List<int> newList = RandomList();
            // int max = newList[0];
            // int min = newList[0];
            // for(int i = 0; i < newList.Count; i++)
            // {
            //     if(newList[i] < min)
            //     {
            //         min = newList[i];
            //     }
            //     if(newList[i] > max)
            //     {
            //         max = newList[i];
            //     }
               
                
            // }
            // Console.Write(String.Join(", ", newList));
            // Console.WriteLine("***********");
            // Console.WriteLine(max);
            // Console.WriteLine("***********");
            // Console.WriteLine(min);
            // int sum = 0;
            // for(int i = 0; i < newList.Count; i++)
            // {
            //     sum += newList[i];
            // }
            // Console.Write(String.Join(", ", newList));
            // Console.WriteLine();
            // Console.WriteLine("***********");
            // Console.WriteLine(sum);
            // TossCoin();
            // TossMultipleCoins(3);
            Names();
            
        }
    }
}
