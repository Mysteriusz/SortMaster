using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;

namespace SortMaster.Algorithms.NumberBased
{
    public class CountSort
    {
        public uint[] Sort(uint[] arr, bool reversed = false)
        {
            uint min = GetMin(arr);
            uint max = GetMax(arr);

            int range = (int)(max - min + 1);
            int offset = (int)-min;

            uint[] count = new uint[range];

            for (int i = 0; i < arr.Length; i++)
                count[arr[i] + offset]++;

            for (int i = 1; i <= range - 1; i++)
                count[i] += count[i - 1];

            uint[] output = new uint[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                uint num = arr[i];
                output[count[num + offset] - 1] = num;
                count[num + offset] -= 1;
            }

            for (int i = 0; i < arr.Length; i++)
                arr[i] = output[i];

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

        private uint GetMax(uint[] arr)
        {
            uint max = arr[0];

            for (int i = 0; i < arr.Length; i++)
                if (max < arr[i])
                    max = arr[i];

            return max;
        }

        private uint GetMin(uint[] arr)
        {
            uint min = arr[0];

            for (int i = 0; i < arr.Length; i++)
                if (min > arr[i])
                    min = arr[i];

            return min;
        }
    }
}
