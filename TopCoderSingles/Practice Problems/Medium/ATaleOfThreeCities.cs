using System;
using System.Collections.Generic;
using System.Linq;

namespace TopCoderSingles.Practice_Problems
{
    class ATaleOfThreeCities : IProblem
    {
        public string Name => "A Tale of Three Cities";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1499/3281/3543/2/1499";
        public string CodeAsString => @"            double connect(int[] ax, int[] ay, int[] bx, int[] by, int[] cx, int[] cy)
            {
                // Task:
                // ax and ay are the positions of subway stations in A
                // bx and by are the positions of subway stations in A
                // cx and cy are the positions of subway stations in A

                // Find the shortest possible distance between any station in A and B, B and C and A and C

                // Return the sum of the two shortest distances

                List<double> minDistanceBetween = new List<double>()
                {
                    minDistanceBetweenCities(ax, ay, bx, by),
                    minDistanceBetweenCities(bx, by, cx, cy),
                    minDistanceBetweenCities(ax, ay, cx, cy)
                };

                minDistanceBetween.Remove(minDistanceBetween.Max());

                return minDistanceBetween.Sum();
            }

            double minDistanceBetweenCities(int[] city1x, int[] city1y, int[] city2x, int[] city2y)
            {
                double shortestDistance = 0;

                for (int i = 0; i < city1x.Length; i++)
                {
                    for (int j = 0; j < city2x.Length; j++)
                    {
                        double distance = Math.Sqrt(Math.Pow(city1x[i] - city2x[j], 2) + Math.Pow(city1y[i] - city2y[j], 2));

                        if ((i == 0 && j == 0) || (distance < shortestDistance))
                            shortestDistance = distance;
                    }
                }

                return shortestDistance;
            }
";
        public IExample[] Examples => new IExample[]
{
            // The tunnel connecting the subway station in city A at(0,2) with the subway station in city C at(1,3) has a length of about 1.41
            // and the tunnel connecting the subway station in city A at(0,1) with the subway station in city B at(2,1) has a length of 2.
            new ATaleOfThreeCitiesExample((
                new int[]{0,0,0},
                new int[]{0,1,2},
                new int[]{2,3},
                new int[]{1,1},
                new int[]{1,5},
                new int[]{3,28}),
                3.414213562373095),
            new ATaleOfThreeCitiesExample((
                new int[]{-2,-1,0,1,2},
                new int[]{0,0,0,0,0},
                new int[]{-2,-1,0,1,2},
                new int[]{1,1,1,1,1},
                new int[]{-2,-1,0,1,2},
                new int[]{2,2,2,2,2}),
                2.0),
            new ATaleOfThreeCitiesExample((
                new int[]{4,5,11,21,8,10,3,9,5,6},
                new int[]{12,8,9,12,2,3,5,7,10,13},
                new int[]{34,35,36,41,32,39,41,37,39,50},
                new int[]{51,33,41,45,48,22,33,51,41,40},
                new int[]{86,75,78,81,89,77,83,88,99,77},
                new int[]{10,20,30,40,50,60,70,80,90,100}),
                50.323397776611024)
};
        public class ATaleOfThreeCitiesExample : ExampleBase<(int[], int[], int[], int[], int[], int[]), double>
        {
            public ATaleOfThreeCitiesExample((int[], int[], int[], int[], int[], int[]) inputs, double correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                double output = connect(Inputs.Item1, Inputs.Item2, Inputs.Item3, Inputs.Item4, Inputs.Item5, Inputs.Item6);
                // Tweak output to allow for rounding differences since TopCoder allows these to pass
                return Math.Round(output - CorrectOutput, 13) == 0 ? true : false;
            }

            double connect(int[] ax, int[] ay, int[] bx, int[] by, int[] cx, int[] cy)
            {
                // Task:
                // ax and ay are the positions of subway stations in A
                // bx and by are the positions of subway stations in A
                // cx and cy are the positions of subway stations in A

                // Find the shortest possible distance between any station in A and B, B and C and A and C

                // Return the sum of the two shortest distances

                List<double> minDistanceBetween = new List<double>()
                {
                    minDistanceBetweenCities(ax, ay, bx, by),
                    minDistanceBetweenCities(bx, by, cx, cy),
                    minDistanceBetweenCities(ax, ay, cx, cy)
                };

                minDistanceBetween.Remove(minDistanceBetween.Max());

                return minDistanceBetween.Sum();
            }

            double minDistanceBetweenCities(int[] city1x, int[] city1y, int[] city2x, int[] city2y)
            {
                double shortestDistance = 0;

                for (int i = 0; i < city1x.Length; i++)
                {
                    for (int j = 0; j < city2x.Length; j++)
                    {
                        double distance = Math.Sqrt(Math.Pow(city1x[i] - city2x[j], 2) + Math.Pow(city1y[i] - city2y[j], 2));

                        if ((i == 0 && j == 0) || (distance < shortestDistance))
                            shortestDistance = distance;
                    }
                }

                return shortestDistance;
            }
        }
    }
}