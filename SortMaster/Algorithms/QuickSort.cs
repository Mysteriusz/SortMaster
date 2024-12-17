using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class QuickSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int lastIndex = arr.Length - 1;
            int firstIndex = 0;

            if (firstIndex < lastIndex)
            {
                int p = Partition(arr, firstIndex, lastIndex);

                SortPart(arr, firstIndex, p - 1);
                SortPart(arr, p + 1, lastIndex);
            }

            if (reversed)
                Array.Reverse(arr);

            return arr;
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            if (fromIndex < toIndex)
            {
                int p = Partition(arr, fromIndex, toIndex);

                SortPart(arr, fromIndex, p - 1);
                SortPart(arr, p + 1, toIndex);
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }

        private int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            T pivot = arr[hi];
            int i = lo;

            for (int j = lo; j < hi; j++)
            {
                if (arr[j].CompareTo(pivot) <= 0)
                {
                    Swap(arr, i, j);
                    i += 1;
                }
            }

            Swap(arr, i, hi);
            return i;
        }
        private void Swap<T>(T[] arr, int i1, int i2)
        {
            T temp = arr[i2];
            arr[i2] = arr[i1];
            arr[i1] = temp;
        }
    }
}
