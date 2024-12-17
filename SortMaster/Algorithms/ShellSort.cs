using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class ShellSort : 
    {
        private readonly int[] gaps = [701, 301, 132, 57, 23, 10, 4, 1];
        
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            foreach (int gap in gaps)
            {
                for (int i = gap; i < arr.Length; i++)
                {
                    T temp = arr[i];
                    int j = i;

                    for (j = i; (j >= gap) && (arr[j - gap].CompareTo(temp) > 0); j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
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
