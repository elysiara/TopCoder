using System;

namespace TopCoderSingles.Practice_Problems
{
    public class TurretDefense : IProblem
    {
        public string Name => "Turret Defense";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1347/2153/2323/1/1347";
        public string CodeAsString => @"        public int firstMiss(int[] xs, int[] ys, int[] times)
        {
            // Initialise start position and time
            int startX = 0;
            int startY = 0;
            int startTime = 0;

            // For each target, calculate the time window for a successful hit
            // and compare with the calculated time to fire.
            for (int i = 0; i < xs.Length; i++)
            {
                int changeInTime = (times[i] - startTime);
                int timeToFire = Math.Abs(xs[i] - startX) + Math.Abs(ys[i] - startY);

                if (changeInTime < timeToFire)
                {
                    // Insufficient time
                    return i;
                }
                else
                {
                    // Set up for the next target
                    startX = xs[i];
                    startY = ys[i];
                    startTime = times[i];
                }
            }
            // All targets were successfully hit
            return -1;
        }
";
        public IExample[] Examples => new TurretDefenseExample[]
{
            new TurretDefenseExample((
                new int[]{3,5,6},
                new int[]{7,5,6},
                new int[]{11,15,16}),
                2),
            new TurretDefenseExample((
                new int[]{ 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16},
                new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16},
                new int[]{2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32}),
                -1),
            new TurretDefenseExample((
                new int[]{ 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16},
                new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16},
                new int[]{2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,31}),
                15),
            new TurretDefenseExample((
                new int[]{ 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0},
                new int[]{1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0, 1000,0,1000,0,1000,0,1000,0,1000,0},
                new int[]{2000,4000,6000,8000,10000,12000,14000,16000,18000,20000, 22000,24000,26000,28000,30000,32000,34000,36000,38000,40000, 42000,44000,46000,48000,50000,52000,54000,56000,58000,60000, 62000,64000,66000,68000,70000,72000,74000,76000,78000,80000, 82000,84000,86000,88000,90000,92000,94000,96000,98000,100000}),
                -1),
            new TurretDefenseExample((
                new int[]{4,5},
                new int[]{4,5},
                new int[]{7,8}),
                0),
            new TurretDefenseExample((
                new int[]{1,2,3,4,15},
                new int[]{1,2,3,4,15},
                new int[]{100,200,300,400,405}),
                4)
};
        protected class TurretDefenseExample : ExampleBase<(int[] xs, int[] ys, int[] times), int>
        {
            public TurretDefenseExample((int[] xs, int[] ys, int[] times) inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = firstMiss(Inputs.xs, Inputs.ys, Inputs.times);
                return (output.Equals(CorrectOutput));
            }

            public int firstMiss(int[] xs, int[] ys, int[] times)
            {
                // Initialise start position and time
                int startX = 0;
                int startY = 0;
                int startTime = 0;

                // For each target, calculate the time window for a successful hit
                // and compare with the calculated time to fire.
                for (int i = 0; i < xs.Length; i++)
                {
                    int changeInTime = (times[i] - startTime);
                    int timeToFire = Math.Abs(xs[i] - startX) + Math.Abs(ys[i] - startY);

                    if (changeInTime < timeToFire)
                    {
                        // Insufficient time
                        return i;
                    }
                    else
                    {
                        // Set up for the next target
                        startX = xs[i];
                        startY = ys[i];
                        startTime = times[i];
                    }
                }
                // All targets were successfully hit
                return -1;
            }

        }
    }
}