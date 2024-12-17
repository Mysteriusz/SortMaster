using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Algorithms
{
    public class HeapSort : 
    {
        public T[] Sort<T>(T[] arr, bool reversed = false) where T : IComparable<T>
        {
            Heapify(arr, arr.Length);

            int end = arr.Length - 1;
            while (end > 0)
            {
                Swap(arr, end, 0);
                ShiftDown(arr, 0, end);
                end--;
            }

            if (reversed)
                Array.Reverse(arr);

            return arr; 
        }
        public T[] SortPart<T>(T[] arr, int fromIndex, int toIndex, bool reversed = false) where T : IComparable<T> 
        {
            T[] temp = arr.AsMemory(fromIndex, toIndex - fromIndex + 1).ToArray(); 

            Sort(temp);

            int outIndex = 0;
            for (int i = fromIndex; i <= toIndex; i++)
            {
                arr[i] = temp[outIndex];
                outIndex++;
            }

            if (reversed)
                Array.Reverse(arr, fromIndex, toIndex - fromIndex + 1);

            return arr;
        }

        private T[] Heapify<T>(T[] arr, int count) where T : IComparable<T>
        {
            int start = iParent(count - 1);
        
            while (start >= 0)
            {
                ShiftDown(arr, start, count);
                start--;
            }

            return arr; 
        }
        private T[] ShiftDown<T>(T[] arr, int root, int end) where T : IComparable<T> 
        {
            while (iLeftChild(root) < end)
            {
                int child = iLeftChild(root);

                if (child + 1 < end && arr[child].CompareTo(arr[child + 1]) < 0)
                    child++;


                if (arr[root].CompareTo(arr[child]) < 0)
                {
                    Swap(arr, root, child);
                    root = child;
                }
                else
                    break;
            }

            return arr;
        }

        private void Swap<T>(T[] arr, int s1, int s2)
        {
            T temp = arr[s1];
            arr[s1] = arr[s2];
            arr[s2] = temp;
        }

        private int iLeftChild(int i)
        {
            return 2 * i + 1;
        }
        private int iRightChild(int i)
        {
            return 2 * i + 2;
        }
        private int iParent(int i)
        {
            return (i - 1) / 2;
        }
    }
}
