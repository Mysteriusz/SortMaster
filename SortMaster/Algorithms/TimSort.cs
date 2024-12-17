using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class TimSort
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int minRun = 32;
            int n = arr.Length;

            for (int i = 0; i < n; i += minRun)
            {
                int end = Math.Min(i + minRun - 1, n - 1);
                InsSort(arr, i, end);
            }

            int size = minRun;

            while (size < n)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = Math.Min(left + size - 1, n - 1);
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                        Merge(arr, left, mid, right);
                }

                size *= 2;
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

        private T[] InsSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            for (int i = left; i <= right; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= left && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = key;
            }

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
