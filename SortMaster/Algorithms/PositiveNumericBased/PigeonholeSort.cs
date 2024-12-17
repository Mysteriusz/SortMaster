using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms.NumberBased
{
    public class PigeonholeSort
    {
        public uint[] Sort(uint[] arr, bool reversed = false)
        {
            uint min = GetMin(arr);
            uint max = GetMax(arr);

            int numHoles = (int)(max - min + 1);
            List<int>[] holes = new List<int>[numHoles];

            for (int i = 0; i < holes.Length; i++)
                holes[i] = new List<int>();

            foreach (int val in arr)
            {
                int index = (int)(val - min);
                holes[index].Add(val);
            }

            List<uint> sorted = new List<uint>();

            foreach (var hole in holes)
                foreach (uint val in hole)
                    sorted.Add(val);

            for (int i = 0; i < arr.Length; i++)
                arr[i] = sorted[i];

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
