using System;
using System.Collections.Generic;
namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Die> diceSet = new List<Die>
        {
            new Die(6, new double[] { 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6, 1.0 / 6 }),
            new Die(4, new double[] { 0.25, 0.25, 0.25, 0.25 })
        };

            var sumProbabilities = DiceProbabilityCalculator.CalculateSumProbabilities(diceSet);

            Console.WriteLine("All possible sums and their probabilities:");
            foreach (var entry in sumProbabilities)
            {
                Console.WriteLine($"Sum: {entry.Key}, Probability: {entry.Value}");
            }

            Console.WriteLine("\nSorted sums using Insertion Sort:");
            SortingAlgorithms.InsertionSort(new Dictionary<int, double>(sumProbabilities));

            Console.WriteLine("\nSorted sums using Quicksort:");
            SortingAlgorithms.QuickSort(new Dictionary<int, double>(sumProbabilities));

            Console.WriteLine("\nSorted sums using Merge Sort:");
            SortingAlgorithms.MergeSort(new Dictionary<int, double>(sumProbabilities));
        }
    }
}