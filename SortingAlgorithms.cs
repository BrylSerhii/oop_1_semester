using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class SortingAlgorithms
    {
        public static void InsertionSort(Dictionary<int, double> sums)
        {
            int n = sums.Count;
            var sumArray = sums.ToArray();

            for (int i = 1; i < n; i++)
            {
                int key = sumArray[i].Key;
                double value = sumArray[i].Value;

                int j = i - 1;

                while (j >= 0 && sumArray[j].Value < value)
                {
                    sumArray[j + 1] = sumArray[j];
                    j--;
                }

                sumArray[j + 1] = new KeyValuePair<int, double>(key, value);
            }

            PrintSortedSums(sumArray);
        }

        public static void QuickSort(Dictionary<int, double> sums)
        {
            var sumArray = sums.ToArray();
            QuickSort(sumArray, 0, sumArray.Length - 1);
            PrintSortedSums(sumArray);
        }

        private static void QuickSort(KeyValuePair<int, double>[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private static int Partition(KeyValuePair<int, double>[] arr, int low, int high)
        {
            double pivot = arr[high].Value;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].Value >= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        public static void MergeSort(Dictionary<int, double> sums)
        {
            var sumArray = sums.ToArray();
            MergeSort(sumArray, 0, sumArray.Length - 1);
            PrintSortedSums(sumArray);
        }

        private static void MergeSort(KeyValuePair<int, double>[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(KeyValuePair<int, double>[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            KeyValuePair<int, double>[] leftArr = new KeyValuePair<int, double>[n1];
            KeyValuePair<int, double>[] rightArr = new KeyValuePair<int, double>[n2];

            Array.Copy(arr, left, leftArr, 0, n1);
            Array.Copy(arr, mid + 1, rightArr, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (leftArr[i].Value >= rightArr[j].Value)
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }
        }

        private static void Swap(KeyValuePair<int, double>[] arr, int i, int j)
        {
            KeyValuePair<int, double> temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void PrintSortedSums(KeyValuePair<int, double>[] sums)
        {
            foreach (var sum in sums)
            {
                Console.WriteLine($"Sum: {sum.Key}, Probability: {sum.Value}");
            }
        }
    }

}
