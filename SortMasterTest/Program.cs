using System;
using System.Diagnostics;
using System.Net.Quic;
using System.Runtime.CompilerServices;
using SortMaster;
using SortMaster.Algorithms.NumberBased;

namespace SortMasterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            uint[] testArray = { 34, 7, 23, 32, 5, 62, 32, 11, 9, 0, 25, 43 };
            string[] words = { "apple", "orange", "banana", "pear", "grape" };

            PigeonholeSort qs = new PigeonholeSort();

            Debug.WriteLine(string.Join(", ", testArray));
            //testArray = qs.Sort(testArray, 0, testArray.Length - 1);
            //qs.Sort(testArray);
            //testArray = qs.SortPart(testArray, 2, 10, false);
            testArray = qs.Sort(testArray, false);

            Debug.WriteLine(string.Join(", ", testArray));
        }
    }
}
