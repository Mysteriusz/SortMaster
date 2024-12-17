using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Quic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class MergeSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            SortPart(arr, 0, arr.Length - 1, reversed);

            if (reversed)
                Array.Reverse(arr);

            return arr;
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T>
        {
            if (fromIndex < toIndex)
            {
                int mid = (fromIndex + toIndex) / 2;

                SortPart(arr, fromIndex, mid);
                SortPart(arr, mid + 1, toIndex);

                Merge(arr, fromIndex, mid, toIndex);
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }

        private T[] Merge<T>(T[] arr, int from, int mid, int to) where T : IComparable<T> 
        {
            int leftSize = mid - from + 1;
            int rightSize = to - mid;

            T[] left = new T[leftSize];
            T[] right = new T[rightSize];

            Array.Copy(arr, from, left, 0, leftSize);
            Array.Copy(arr, mid + 1, right, 0, rightSize);

            int i = 0, j = 0, k = from;

            while (i < leftSize && j < rightSize)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }

                k++;
            }

            while (i < leftSize)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < rightSize)
            {
                arr[k] = right[j];
                j++;
                k++;
            }

            return arr;
        }
    }
}
