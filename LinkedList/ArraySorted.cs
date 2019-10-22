using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class ArraySorted
    {
        int[] array;
        public int Count { get; set; }
        public ArraySorted(int[] array)
        {
            this.array = array;
            Count = array.Length;
        }
        void Swap(int left, int right)
        {
            if (left != right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
        }
        public void BubbleSort()
        {
            if (Count > 1)
            {
                int j = array.Length;
                for (int i = 0; i < j-1; j--)
                {
                    for (; i < j-1; i++)
                    {
                        if (array[i] > array[i + 1])
                            Swap(i, i+1);
                    }
                    i = 0;
                }
            }
        }
        public void InsertionSort()
        {
            if (array.Length > 1)
            {
                int indexSorted = 1;
                while (indexSorted < array.Length)
                {
                    if (array[indexSorted] < array[indexSorted-1])
                    {
                        int indexInsert = searchIndexInsert(indexSorted);
                        insertIndex(indexInsert, indexSorted);
                    }
                    indexSorted++;
                }
            }
        }
        private int searchIndexInsert(int indexSorted)
        {
            for (int i = 0; i < indexSorted; i++)
            {
                if (array[i] > array[indexSorted])
                    return i;
            }
            throw new IndexOutOfRangeException();          
        }
        private void insertIndex(int indexInsert, int indexSorted)
        {
            int temp = array[indexSorted];
            for (; indexInsert < indexSorted; indexSorted--)
            {
                array[indexSorted] = array[indexSorted - 1];
            }
            array[indexInsert] = temp;
        }
        public void SelectionSort()
        {
            if (array.Length > 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int min = i;
                    int j = i + 1;
                    for (; j < array.Length; j++)
                    {
                        if (array[min] > array[j])
                            min = j;
                    }
                    Swap(i, min);
                }
            }
        }
        public void MergeSort()
        {
            if (array.Length % 2 == 1)
                return;

            int halfLength = array.Length / 2;

            int[] left = new int[halfLength];
            int[] right = new int[halfLength];

            Array.Copy(array, 0, left, 0, halfLength);
            Array.Copy(array, halfLength, right, 0, halfLength);

            mergeSort(left);
            mergeSort(right);

            merge(array, left, right);
        }
        private void mergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            int halfLength = arr.Length / 2;

            int[] left = new int[halfLength];
            int[] right = new int[halfLength];

            Array.Copy(arr, 0, left, 0, halfLength);
            Array.Copy(arr, halfLength, right, 0, halfLength);

            mergeSort(left);
            mergeSort(right);

            merge(arr, left, right);
        }
        private void merge(int[] arr, int[] left, int[] right)
        {
            int l = 0;
            int r = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (r < right.Length && l < left.Length)
                {
                    if (left[l] > right[r])
                    {
                        arr[i] = right[r++];
                    }
                    else
                    {
                        arr[i] = left[l++];
                    }
                }
                else if (r == right.Length)
                {
                    arr[i] = left[l++];
                    //Array.Copy(left, l, arr, r+l, left.Length-l); break;
                }
                else if (l == left.Length)
                {
                    arr[i] = right[r++];
                    //Array.Copy(right, r, arr, r + l, right.Length - r); break;
                }
            }
        }
        public void QuickSort()
        {
            if (Count > 1)
            {
                quickSort(0, array.Length-1);
            }
        }
        private void quickSort(int left, int right)
        {
            if (left < right)
            {
                Random rnd = new Random();
                int pivotIndex = rnd.Next(left, right);

                int newPivot = quickSortPart(left, right, pivotIndex);

                quickSort(left, newPivot - 1);
                quickSort(newPivot + 1, right);
            }
        }
        private int quickSortPart(int left, int right, int pivotIndex)
        {
            Swap(pivotIndex, right);
            int biggerIndex = left;
            for (int i = left; i < right; i++)
            {
                if (array[i] < array[right])
                {
                    Swap(biggerIndex, i);
                    biggerIndex++;
                } 
            }
            Swap(biggerIndex, right);
            return biggerIndex;
        }


    }
}
