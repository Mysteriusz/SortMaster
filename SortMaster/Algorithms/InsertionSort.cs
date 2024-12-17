using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class InsertionSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int i = 1;

            while (i < arr.Length)
            {
                T x = arr[i];
                int j = i;

                while (j > 0 && arr[j - 1].CompareTo(x) > 0)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = x;
                i++;
            }

            if (reversed)
            {
                Array.Reverse(arr);
            }

            return arr;
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            for (int i = fromIndex + 1; i <= toIndex; i++)
            {
                T x = arr[i];
                int j = i - 1;

                while (j >= fromIndex && arr[j].CompareTo(x) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = x;
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }
    }
}   
