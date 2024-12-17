using SortMaster.Algorithms;
using SortMaster.Algorithms.NumberBased;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMaster.Utils
{
    public class SortingManager
    {
        public BubbleSort BubbleSort { get { return new BubbleSort(); } }
        public CocktailSort CocktailSort { get { return new CocktailSort(); } }
        public CombSort CombSort { get { return new CombSort(); } }
        public CycleSort CycleSort { get { return new CycleSort(); } }
        public GnomeSort GnomeSort { get { return new GnomeSort(); } }
        public HeapSort HeapSort { get { return new HeapSort(); } }
        public InsertionSort InsertionSort { get { return new InsertionSort(); } }
        public MergeSort MergeSort { get { return new MergeSort(); } }
        public QuickSort QuickSort { get { return new QuickSort(); } }
        public SelectionSort SelectionSort { get { return new SelectionSort(); } }
        public ShellSort ShellSort { get { return new ShellSort(); } }
        public TimSort TimSort { get { return new TimSort(); } }
        public CountSort CountSort { get { return new CountSort(); } }
        public PigeonholeSort PigeonholeSort { get { return new PigeonholeSort(); } }
        public RadixSort RadixSort { get { return new RadixSort(); } }
    }
}
