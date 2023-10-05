using System;
using System.Collections.Generic;


namespace Lab_1
{
    public class DiceProbabilityCalculator
    {
        public static List<int> GetAllPossibleSums(List<Die> diceSet)
        {
            List<int> possibleSums = new List<int> { 0 };

            foreach (var die in diceSet)
            {
                List<int> newSums = new List<int>();
                for (int face = 1; face <= die.Faces; face++)
                {
                    foreach (var sum in possibleSums)
                    {
                        int newSum = sum + face;
                        newSums.Add(newSum);
                    }
                }
                possibleSums = newSums;
            }

            return possibleSums;
        }

        public static Dictionary<int, double> CalculateSumProbabilities(List<Die> diceSet)
        {
            Dictionary<int, double> sumProbabilities = new Dictionary<int, double>();

            List<int> possibleSums = GetAllPossibleSums(diceSet);

            foreach (var sum in possibleSums)
            {
                double probability = 1.0;

                for (int i = 0; i < diceSet.Count; i++)
                {
                    double[] probabilities = diceSet[i].Probabilities;
                    probability *= probabilities[Math.Min(sum - 1, diceSet[i].Faces - 1)];
                }

                sumProbabilities[sum] = probability;
            }

            return sumProbabilities;
        }
    }
}
