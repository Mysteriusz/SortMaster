using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class BubbleSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            T temp;

            for (int i = (arr.Length - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            if (reversed)
                Array.Reverse(arr);
            
            return arr;
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            T temp;

            for (int i = toIndex; i >= fromIndex; i--)
            {
                for (int j = fromIndex + 1; j <= i; j++)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }
    }
}
