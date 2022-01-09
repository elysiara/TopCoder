using System;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class Substitute : IDisplayableProblem, ITestableExamples<(string key, string code), int>
    {
        public string Name => "Substitute";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1282/1262/1333/2/1282";
        public string CodeAsString => @"        public int getValue(string key, string code)
        {
            // Initialise return value
            int returnValue = 0;

            foreach (char letter in code)
            {
                // Look for the letter of the code in the key
                int foundValue = key.IndexOf(letter);

                // If not found, move on to the next letter
                if (foundValue == -1)
                {
                    continue;
                }

                // If the letter is the last letter of the key, set the value to 0
                if (foundValue == (key.Length - 1))
                {
                    foundValue = 0;
                }
                // Otherwise add 1 to the value because the IndexOf is zero indexed
                else
                {
                    foundValue++;
                }

                // Move the returnValue along by an order of magnitude and add the new found value
                returnValue *= 10;
                returnValue += foundValue;
            }
            return returnValue;
        }
";

        public GenericTester<(string key, string code), int> SubstituteTester = new GenericTester<(string key, string code), int>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await SubstituteTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await SubstituteTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<(string key, string code), int>[] Examples => new GenericExample<(string key, string code), int>[]
        {
            new GenericExample<(string key, string code), int>(("TRADINGFEW","LGXWEV"),709),
            new GenericExample<(string key, string code), int>(("ABCDEFGHIJ","XJ"),0),
            new GenericExample<(string key, string code), int>(("CRYSTALBUM","MMA"),6)
        };
        public bool TestExample(IExample<(string key, string code), int> example)
        {
            return (example.Output.Equals(GetValue(example.Inputs.key, example.Inputs.code)));
        }
        public int GetValue(string key, string code)
        {
            // Initialise return value
            int returnValue = 0;

            foreach (char letter in code)
            {
                // Look for the letter of the code in the key
                int foundValue = key.IndexOf(letter);

                // If not found, move on to the next letter
                if (foundValue == -1)
                {
                    continue;
                }

                // If the letter is the last letter of the key, set the value to 0
                if (foundValue == (key.Length - 1))
                {
                    foundValue = 0;
                }
                // Otherwise add 1 to the value because the IndexOf is zero indexed
                else
                {
                    foundValue++;
                }

                // Move the returnValue along by an order of magnitude and add the new found value
                returnValue *= 10;
                returnValue += foundValue;
            }
            return returnValue;
        }
    }
}