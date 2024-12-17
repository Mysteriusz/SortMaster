using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class CombSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int gap = arr.Length;
            T tmp;

            bool swapped = false;
            while (gap > 1 || swapped)
            {
                gap = gap * 10 / 13;
                
                if (gap == 0)
                    gap = 1;

                swapped = false;

                for (int i = 0; i + gap < arr.Length; i++)
                {
                    if (arr[i + gap].CompareTo(arr[i]) < 0)
                    {
                        tmp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = tmp;
                        swapped = true;
                    }
                }
            }

            if (reversed)
                Array.Reverse(arr);

            return arr;
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            T[] temp = arr.AsMemory(fromIndex, toIndex - fromIndex + 1).ToArray();
            Sort(temp, reversed);

            int outIndex = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                arr[i] = temp[outIndex];
                outIndex++;
            }

            return arr;    
        }
    }
}
