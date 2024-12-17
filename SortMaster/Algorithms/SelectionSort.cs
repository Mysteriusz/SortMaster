using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class SelectionSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int smallestIndex = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[smallestIndex]) < 0)
                        smallestIndex = j;
                }

                if (smallestIndex != i)
                {
                    T temp = arr[i];
                    arr[i] = arr[smallestIndex];    
                    arr[smallestIndex] = temp;
                }
            }

            if (reversed)
                Array.Reverse(arr);

            return arr;
        }

        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            for (int i = fromIndex; i <= toIndex; i++)
            {
                int smallestIndex = i;

                for (int j = i; j <= toIndex; j++)
                {
                    if (arr[j].CompareTo(arr[smallestIndex]) < 0)
                        smallestIndex = j;
                }

                if (smallestIndex != i)
                {
                    T temp = arr[i];
                    arr[i] = arr[smallestIndex];
                    arr[smallestIndex] = temp;
                }
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }
    }
}
