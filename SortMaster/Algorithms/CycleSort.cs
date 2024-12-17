using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class CycleSort
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            int size = arr.Length;

            for (int start = 0; start < size - 1; start++)
            {
                T item = arr[start];

                int pos = start;

                for (int i = start + 1; i < size; i++)
                    if (arr[i].CompareTo(item) < 0)
                        pos++;
                
                if (pos == start)
                    continue;

                while (arr[pos].CompareTo(item) == 0)
                    pos++;

                if (pos != start)
                {
                    T temp = arr[pos];
                    arr[pos] = item;
                    item = temp;
                }

                while (pos != start)
                {
                    pos = start;
                    
                    for (int i = start + 1; i < size; i++)
                    {
                        if (arr[i].CompareTo(item) < 0)
                            pos++;
                    }

                    while (item.CompareTo(arr[pos]) == 0)
                        pos++;

                    if (arr[pos].CompareTo(item) != 0)
                    {
                        T temp = arr[pos];
                        arr[pos] = item;
                        item = temp;
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

        private void Swap<T>(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
