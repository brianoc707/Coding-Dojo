using System;


namespace BinarySearch
{
    class Program
    {
          static void Main(string[] args)
        {
            int[] arr = [1,2,3,4,5,6,];
            BinarySearch(5, arr);
        }
        public static bool BinarySearch(int i, int[] arr)
            {
            int start = 0;
            int end = arr.Length -1;
            int half = (end = start) / 2;
            if (i < arr[0])
            {
                return false;
            }
            if (i > arr[arr.Length])
            {
                return false;
            }
            bool found = false;
            while (found == false)
            {
                if (arr[half] == i)
                {
                    return true;
                }
                if (i > arr[half])
                {
                    start = half;
                }
                if (i < arr[half])
                {
                    end = half;
                }
                half = (end - start) / 2;
                half = start + half;
            }

    }


}
      
    


