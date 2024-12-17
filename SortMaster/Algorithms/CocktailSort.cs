using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class CocktailSort
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            bool swapped = true;
            
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;

                swapped = false;
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    if (arr[i].CompareTo(arr[i - 1]) < 0)
                    {
                        Swap(arr, i, i - 1);
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

        private void Swap<T>(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
