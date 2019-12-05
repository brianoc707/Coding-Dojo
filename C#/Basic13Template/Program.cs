using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        // An example list for use has been provided below

        //Print every value from 1 to 255
        public static void Print1to255()
        {
            for(int i = 1; i <= 255; i++)
        {
            Console.WriteLine(i);
        }
        }

        //Print every odd number from 1 to 255
        public static void PrintOdds1to255()
        {
            for(int i = 1; i <= 255; i++)
        {
            if(i%2 != 0)
            {
                Console.WriteLine(i);
            }
        }
        }

        //Print every number from 255 and along the way print the sum of all the numbers you've printed
        public static void PrintIntsAndSums1to255()
        {
            int sum = 0;
            for(int i = 0; i <= 255; i++)
            {
            
            sum += i;
            Console.WriteLine($"new number = {i} sum = {sum}");
            }
        }

        // Print all the values in a list
        public static void PrintList(List<int> exampleList)
        {
            foreach (int manu in exampleList)
            {
                Console.WriteLine(manu);
            }
        }

        //Print the largest value in the list
        public static void PrintMax(List<int> exampleList) 
        {
            int max = 0;
            foreach(int val in exampleList)
            {
                if(max < val)
                {
                    max = val;
                }
                
            }
            Console.WriteLine(max);
        }

        //Print the average of all the numbers in the list
        public static void PrintAverage(List<int> exampleList)
        {   
            double average = 0;
            int sum = 0;
            foreach(int val in exampleList)
            {
                sum += val;
                average =  (double)sum / exampleList.Count;

            }
            Console.WriteLine(average);
        }

        //Get all the odd numbers from 1 to 255 and put them into a list
        public static void OddList() 
        {
            List<int> newList = new List<int>();
            for(int i = 0; i <= 255; i++)
            {
                if(i%2 != 0)
                {
                    newList.Add(i);
                }
            }
            foreach(var item in newList)
            {
            Console.WriteLine(item);
            }
        }

        //Print all the values in a list that are greater than y
        public static void greaterThanY(List<int> exampleList, int y)
        {
            int count = 0;
            y = -10;
            foreach(int val in exampleList)
            {
                if(val > y)
                {
                    count+= 1;
                }
                
            }
            Console.WriteLine(count);

            
        } 

        //Square all the values in a list
        public static void squareListValues(List<int> exampleList)
        {
            int square = 0;
            foreach(int val in exampleList)
            {
                  square = val * val;
                  Console.WriteLine(square);
            }
        
        }

        //Set all negative numbers in a list to 0
        public static void setNegativesToZero(List<int> exampleList)
        {
           
            for(int idx = 0; idx < exampleList.Count; idx++)
            {
                if(exampleList[idx] < 0)
                {
                    exampleList[idx] = 0;
                }
               
            }
            foreach(int val in exampleList)
            {
            Console.WriteLine(val);
            }
        }

        //Given a list of numbers, shift each number by one to the front and add 0 to the end
        //Ex: if the given list is [1,5,10,7,-2], the output should be [5,10,7,-2,0]
        public static void ShiftValuesToRight(List<int> arr) 
        {
            for(int idx = 0; idx < arr.Count -1; idx++)
            {
                arr[idx] = arr[idx+1];
                arr[(arr.Count - 1)] = 0;
            } 
          
                Console.Write(String.Join(", ", arr));
        }

        static void Main(string[] args)
        {
            List<int> exampleList = new List<int>() {
                3,
                -4,
                7,                      
                12,
                -11,
                0,
                -2
            };
            
            //Print1to255();
            //PrintOdds1to255();
            // PrintIntsAndSums1to255();
            // PrintList(exampleList);
            // PrintMax(exampleList);
            // PrintAverage(exampleList);
            // OddList();
            // greaterThanY(exampleList, -10);
            // squareListValues(exampleList);
            // setNegativesToZero(exampleList);
            ShiftValuesToRight(exampleList);
        }
    }
}

