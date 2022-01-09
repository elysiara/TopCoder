using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    public class Whisper : IDisplayableProblem, ITestableExamples<(string[] usernames, string typed), string>
    {
        public string Name => "Whisper";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1171/1132/1147/1/1171";
        public string CodeAsString => @"        public string toWhom(string[] usernames, string typed)
        {
            // Check that the typed text is long enough to proceed
            if (typed.Length < 5)
            {
                return ""not a whisper"";
            }
            // Remove the ""/msg "" from the typed text
            if (!Regex.IsMatch(typed.Substring(0, 5), ""/msg "", RegexOptions.IgnoreCase))
            {
                return ""not a whisper"";
            }
typed = typed.Remove(0, 5);

            // Sort the usernames by length
            string[] sortedUsernames = usernames.OrderBy(x => x.Length).Reverse().ToArray();

            // Look for the longest username match which has a space after it
            foreach (string user in sortedUsernames)
            {
                if (typed.Length<user.Length + 1)
                {
                    continue;
                }

                if (Regex.IsMatch(typed, user, RegexOptions.IgnoreCase) && (typed.Substring(user.Length, 1) == "" ""))
                {
                    // Username is matched
                    return user;
                }
            }
            return ""user is not logged in"";
        }
";

        public GenericTester<(string[] usernames, string typed), string> WhisperTester = new GenericTester<(string[] usernames, string typed), string>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await WhisperTester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await WhisperTester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<(string[] usernames, string typed), string>[] Examples => new WhisperExample[]
        {
            new WhisperExample((new string[]{"John","John Doe","John Doe h"},"/msg John Doe hi there"),"John Doe"),
            new WhisperExample((new string[]{ "John","John Doe","John Doe h"},"/MSG jOHN dOE HI THERE"),"John Doe"),
            new WhisperExample((new string[]{"writer"},"writer hi"),"not a whisper"),
            new WhisperExample((new string[]{"tester"},"/msg testerTwo you there"),"user is not logged in"),
            new WhisperExample((new string[]{"lbackstrom"},"/msg lbackstrom"),"user is not logged in"),
            new WhisperExample((new string[]{"me"},"/msg me hi"),"user is not logged in"),
            new WhisperExample((new string[]{ "abc"}," /msg abc note the leading space"),"not a whisper"),
            new WhisperExample((new string[]{ "Wow"},"/msg Wow "),"Wow"),
            new WhisperExample((new string[]{ "msg"},"/msg"),"not a whisper")
        };
        public bool TestExample(IExample<(string[] usernames, string typed), string> example)
        {
            return example.Output.Equals(ToWhom(example.Inputs.usernames, example.Inputs.typed));
        }
        public string ToWhom(string[] usernames, string typed)
        {
            // Check that the typed text is long enough to proceed
            if (typed.Length < 5)
            {
                return "not a whisper";
            }
            // Remove the "/msg " from the typed text
            if (!Regex.IsMatch(typed.Substring(0, 5), "/msg ", RegexOptions.IgnoreCase))
            {
                return "not a whisper";
            }
            typed = typed.Remove(0, 5);

            // Sort the usernames by length
            string[] sortedUsernames = usernames.OrderBy(x => x.Length).Reverse().ToArray();

            // Look for the longest username match which has a space after it
            foreach (string user in sortedUsernames)
            {
                if (typed.Length < user.Length + 1)
                {
                    continue;
                }

                if (Regex.IsMatch(typed, user, RegexOptions.IgnoreCase) && (typed.Substring(user.Length, 1) == " "))
                {
                    // Username is matched
                    return user;
                }
            }
            return "user is not logged in";
        }

        private class WhisperExample : IExample<(string[] usernames, string typed), string>
        {
            private (string[] usernames, string typed) _inputs;
            private string _output;

            public (string[] usernames, string typed) Inputs
            {
                get => _inputs;
                set => _inputs = value;
            }
            public string Output
            {
                get => _output;
                set => _output = value;
            }

            public WhisperExample((string[] usernames, string typed) inputs, string output)
            {
                Inputs = inputs;
                Output = output;
            }
        }
    }
}