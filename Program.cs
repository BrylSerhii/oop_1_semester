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
            // Die with 6 faces, each with different probabilities
            new Die(6, new double[] { 0.1, 0.15, 0.2, 0.15, 0.2, 0.2 }),

            // Die with 10 faces, each with different probabilities
            new Die(10, new double[] { 0.05, 0.08, 0.1, 0.12, 0.15, 0.1, 0.08, 0.07, 0.1, 0.15 })
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
