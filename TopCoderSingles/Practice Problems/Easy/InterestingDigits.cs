using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    class InterestingDigits : IDisplayableProblem, ITestableExamples<int, int[]>
    {
        public string Name => "Interesting Digits";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1262/1435/1523/2/1262";
        public string CodeAsString => @"        public int[] digits(int numBase)
        {
            List<int> interestingNumbers = new List<int>();

            // 0 and 1 are trivially interesting, so start at 2
            for (int i = 2; i <= numBase; i++)
            {
                // Reset the 'interesting' state to true
                bool interesting = true;

                // Test a large number of multiples for 'interesting' behaviour
                for (int j = 1; j <= 999; j++)
                {
                    // Calculate the multiple
                    int multiple = i * j;

        // Sum the digits that make up that multiple in the chosen base
        List<int> digits = new List<int>();
                    while (multiple > 0)
                    {
                        digits.Add(multiple % numBase);
                        multiple /= numBase;
                    }
    int sum = digits.Sum();

                    // If the sum is not divisable by the original number,
                    // then that number is not interesting
                    if (sum % i != 0)
                    {
                        interesting = false;
                        break;
                    }
                }

                // If all of the tested numbers show interesting behaviour,
                // then the number is interesting
                if (interesting == true) { interestingNumbers.Add(i); }
            }
            return interestingNumbers.ToArray();
        }
";

        public GenericTester<int, int[]> InterestingDigitsTester = new GenericTester<int, int[]>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await InterestingDigitsTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await InterestingDigitsTester.TestExamplesForAverageTask(this, token, progress);
        }
        
        public IExample<int, int[]>[] Examples => new InterestingDigitsExample[]
        {
            new InterestingDigitsExample(10,new int[]{ 3, 9 }),
            new InterestingDigitsExample(3,new int[]{ 2 }),
            new InterestingDigitsExample(9,new int[]{ 2, 4, 8 }),
            new InterestingDigitsExample(26,new int[]{ 5, 25 }),
            new InterestingDigitsExample(30,new int[]{ 29 })
        };
        public bool TestExample(IExample<int, int[]> example)
        {
            return DeepEquals<int>(example.Output, Digits(example.Inputs));
        }
        public int[] Digits(int numBase)
        {
            List<int> interestingNumbers = new List<int>();

            // 0 and 1 are trivially interesting, so start at 2
            for (int i = 2; i <= numBase; i++)
            {
                // Reset the "interesting" state to true
                bool interesting = true;

                // Test a large number of multiples for "interesting" behaviour
                for (int j = 1; j <= 999; j++)
                {
                    // Calculate the multiple
                    int multiple = i * j;

                    // Sum the digits that make up that multiple in the chosen base
                    List<int> digits = new List<int>();
                    while (multiple > 0)
                    {
                        digits.Add(multiple % numBase);
                        multiple /= numBase;
                    }
                    int sum = digits.Sum();

                    // If the sum is not divisable by the original number,
                    // then that number is not interesting
                    if (sum % i != 0)
                    {
                        interesting = false;
                        break;
                    }
                }

                // If all of the tested numbers show interesting behaviour,
                // then the number is interesting
                if (interesting == true) { interestingNumbers.Add(i); }
            }
            return interestingNumbers.ToArray();
        }
        public bool DeepEquals<T>(T[] arr1, T[] arr2)
        {
            // Following function is from https://help.semmle.com/wiki/display/CSHARP/Equals+on+collections

            // If arr1 and arr2 refer to the same array, they are trivially equal.
            if (ReferenceEquals(arr1, arr2)) return true;

            // If either arr1 or arr2 is null and they are not both null (see the previous
            // check), they are not equal.
            if (arr1 == null || arr2 == null) return false;

            // If both arrays are non-null but have different lengths, they are not equal.
            if (arr1.Length != arr2.Length) return false;

            // Failing which, do an element-by-element compare.
            for (int i = 0; i < arr1.Length; ++i)
            {
                // Early out if we find corresponding array elements that are not equal.
                if (!arr1[i].Equals(arr2[i])) return false;
            }

            // If we get here, all of the corresponding array elements were equal, so the
            // arrays are equal.
            return true;
        }

        private class InterestingDigitsExample : IExample<int, int[]>
        {
            private int _input;
            private int[] _output;

            public int Inputs
            {
                get => _input;
                set => _input = value;
            }
            public int[] Output
            {
                get => _output;
                set => _output = value;
            }

            public InterestingDigitsExample(int inputs, int[] output)
            {
                Inputs = inputs;
                Output = output;
            }
        }
    }
}