using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class GnomeSort
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int i = 1;
            int j = 2;

            while (i < arr.Length)
            {
                if (arr[i - 1].CompareTo(arr[i]) <= 0)
                {
                    i = j;
                    j++;
                }
                else
                {
                    Swap(arr, i - 1, i);
                    i--;
                    if (i == 0)
                        i = 1;
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

        private void Swap<T>(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
