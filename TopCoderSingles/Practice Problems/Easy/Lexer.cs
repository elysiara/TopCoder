using System.Collections.Generic;
using System.Linq;

namespace TopCoderSingles.Practice_Problems
{
    public class Lexer : IProblem
    {
        public string Name => "Lexer";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1170/1047/1047/1/1170";
        public string CodeAsString => @"        public string[] tokenize(string[] tokens, string input)
        {
            // Initialise
            List<string> consumed = new List<string>();
            bool matched = false;

            // Sort the tokens by length
            string[] sortedTokens = tokens.OrderBy(x => x.Length).Reverse().ToArray();

            while (input.Length > 0)
            {
                foreach (string token in sortedTokens)
                {
                    // Look for the token within the word - if found, add to the consumed list and remove from the word
                    if (input.Length >= token.Length)
                    {
                        if (token == input.Substring(0, token.Length))
                        {
                            consumed.Add(token);
                            input = input.Remove(0, token.Length);
                            matched = true;
                            break;
                        }
                    }
                }

                if (matched)
                {
                    // Reset the matched state and look for the longest token again
                    matched = false;
                    continue;
                }
                else
                {
                    // Remove one letter from the word, if possible, and look for the longest token again
                    if (input.Length > 1)
                    {
                        input = input.Remove(0, 1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return consumed.ToArray();
        }
";
        public IExample[] Examples => new LexerExample[]
{
            new LexerExample((new string[]{"ab","aba","A"},"ababbbaAab"),new string[]{ "aba", "A", "ab" }),
            new LexerExample((new string[]{"a","a","aa","aaa","aaaa","aaaaa","aa"},"aaaaaaaaaaaaaaaaaaaaaaaaa"),new string[]{ "aaaaa", "aaaaa", "aaaaa", "aaaaa", "aaaaa" }),
            new LexerExample((new string[]{"wow","wo","w"},"awofwwofowwowowowwwooo"),new string[]{ "wo", "w", "wo", "w", "wow", "wow", "w", "wo" }),
            new LexerExample((new string[]{"int","double","long","char","boolean","byte","float"},"intlongdoublecharintintboolean"),new string[]{ "int", "long", "double", "char", "int", "int", "boolean" }),
            new LexerExample((new string[]{ },"Great"),new string[]{ }),
            new LexerExample((new string[]{"AbCd","dEfG","GhIj"},"abCdEfGhIjAbCdEfGhIj"),new string[]{ "dEfG", "AbCd", "GhIj" })
};
        protected class LexerExample : ExampleBase<(string[] tokens, string input), string[]>
        {
            public LexerExample((string[], string) inputs, string[] correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                string[] output = tokenize(Inputs.tokens, Inputs.input);
                return (DeepEquals<string>(output, CorrectOutput));
            }

            public string[] tokenize(string[] tokens, string input)
            {
                // Initialise
                List<string> consumed = new List<string>();
                bool matched = false;

                // Sort the tokens by length
                string[] sortedTokens = tokens.OrderBy(x => x.Length).Reverse().ToArray();

                while (input.Length > 0)
                {
                    foreach (string token in sortedTokens)
                    {
                        // Look for the token within the word - if found, add to the consumed list and remove from the word
                        if (input.Length >= token.Length)
                        {
                            if (token == input.Substring(0, token.Length))
                            {
                                consumed.Add(token);
                                input = input.Remove(0, token.Length);
                                matched = true;
                                break;
                            }
                        }
                    }

                    if (matched)
                    {
                        // Reset the matched state and look for the longest token again
                        matched = false;
                        continue;
                    }
                    else
                    {
                        // Remove one letter from the word, if possible, and look for the longest token again
                        if (input.Length > 1)
                        {
                            input = input.Remove(0, 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return consumed.ToArray();
            }

            // Following function is from
            // https://help.semmle.com/wiki/display/CSHARP/Equals+on+collections
            public bool DeepEquals<T>(T[] arr1, T[] arr2)
            {
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

        }
    }
}