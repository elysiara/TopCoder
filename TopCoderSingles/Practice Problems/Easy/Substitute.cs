namespace TopCoderSingles.Practice_Problems
{
    public class Substitute : IProblem
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
        public IExample[] Examples => new SubstituteExample[]
        {
            new SubstituteExample(("TRADINGFEW","LGXWEV"),709),
            new SubstituteExample(("ABCDEFGHIJ","XJ"),0),
            new SubstituteExample(("CRYSTALBUM","MMA"),6)
        };
        protected class SubstituteExample : ExampleBase<(string key, string code), int>
        {
            public SubstituteExample((string, string) inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = getValue(Inputs.key, Inputs.code);
                return (output.Equals(CorrectOutput));
            }

            public int getValue(string key, string code)
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
}