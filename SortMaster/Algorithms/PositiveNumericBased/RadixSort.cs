using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms.NumberBased
{
    public class RadixSort
    {
        public uint[] Sort(uint[] arr, bool reversed = false)
        {
            uint max = arr[0];
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > max)
                    max = arr[i];
            int pos = 1;

            while (max / pos > 0)
            {
                CountSort(arr, pos);
                pos = pos * 10;
            }

            if (reversed)
                Array.Reverse(arr);

            return arr;
        }
        public uint[] SortPart(uint[] arr, int fromIndex, int toIndex, bool reversed = false)
        {
            uint[] temp = arr.AsMemory(fromIndex, toIndex - fromIndex + 1).ToArray();
            Sort(temp, reversed);

            int outIndex = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                arr[i] = temp[outIndex];
                outIndex++;
            }

            return arr;
        }

        private void CountSort(uint[] arr, int pos)
        {
            uint[] count = new uint[10];
            uint[] output = new uint[arr.Length];

            foreach (uint number in arr)
            {
                var d = number / pos % 10;
                count[d] = count[d] + 1;
            }

            for (int i = 1; i < 10; i++)
                count[i] = count[i] + count[i - 1];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                var d = arr[i] / pos % 10;
                output[count[d] - 1] = arr[i];
                count[d] = count[d] - 1;
            }

            for (int i = 0; i < arr.Length; i++)
                arr[i] = output[i];
        }
    }
}
