using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class Bullets : IDisplayableProblem, ITestableExamples<(string[], string), int>
    {
        public string Name => "Bullets";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1174/665/665/1/1174";
        public string CodeAsString => @"public int match(string[] guns, string bullet)
        {
            // Initialise counter for the guns
            int i = 0;

            // Check to see whether the bullet matches each gun
            // If it doesn't match, 'rotate' the bullet and try again until all orientations have been tried
            foreach (string gun in guns)
            {
                for (int j = 0; j <= gun.Length; j++)
                {
                    if (gun.Equals(bullet))
                    {
                        return i;
                    }
                    else
                    {
                        string shiftedBullet = bullet.Last().ToString() + bullet.Substring(0, bullet.Length - 1);
    bullet = shiftedBullet;
                    }
                }
                i++;
            }
            // If no guns match, return -1
            return -1;
        }";

        public GenericTester<(string[], string), int> BulletTester = new GenericTester<(string[], string), int>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await BulletTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await BulletTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<(string[], string), int>[] Examples => new BulletExample[]
        {
            new BulletExample((new string[]{"| | | |","|| || |"," |||| "},"|| || |"),1),
            new BulletExample((new string[]{"||| |","| | || "},"|||| "),0),
            new BulletExample((new string[]{"|| || ||","| | | | ","||||||||"},"||| ||| "),-1),
            new BulletExample((new string[]{},"| | | |"),-1),
            new BulletExample((new string[]{"|| || ||","| | | | ","||| ||| ","||||||||"},"|| ||| |"),2)
        };
        public bool TestExample(IExample<(string[], string), int> example)
        {
            return example.Output.Equals(Match(example.Inputs.Item1, example.Inputs.Item2));
        }
        public int Match(string[] guns, string bullet)
        {
            // Initialise counter for the guns
            int i = 0;

            // Check to see whether the bullet matches each gun
            // If it doesn't match, 'rotate' the bullet and try again until all orientations have been tried
            foreach (string gun in guns)
            {
                for (int j = 0; j <= gun.Length; j++)
                {
                    if (gun.Equals(bullet))
                    {
                        return i;
                    }
                    else
                    {
                        string shiftedBullet = bullet.Last().ToString() + bullet.Substring(0, bullet.Length - 1);
                        bullet = shiftedBullet;
                    }
                }
                i++;
            }
            // If no guns match, return -1
            return -1;
        }

        private class BulletExample : IExample<(string[], string), int>
        {
            private (string[], string) _input;
            private int _output;

            public (string[], string) Inputs
            {
                get => _input;
                set => _input = value;
            }
            public int Output
            {
                get => _output;
                set => _output = value;
            }

            public BulletExample((string[], string) inputs, int output)
            {
                Inputs = inputs;
                Output = output;
            }
        }
    }
}