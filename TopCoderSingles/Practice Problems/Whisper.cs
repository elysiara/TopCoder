using System.Linq;
using System.Text.RegularExpressions;

namespace TopCoderSingles.Practice_Problems
{
    public class Whisper:ProblemBase
    {
        public override string Name => "Whisper";

        public override string Link => "https://arena.topcoder.com/#/u/practiceCode/1171/1132/1147/1/1171";

        public override string CodeAsString => @"        public string toWhom(string[] usernames, string typed)
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

        protected override IExample[] Examples => new WhisperExample[]
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

        protected class WhisperExample : ExampleBase<(string[] usernames, string typed), string>
        {
            public WhisperExample((string[] usernames, string typed) inputs, string correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                string output = toWhom(Inputs.usernames, Inputs.typed);
                return (output.Equals(CorrectOutput));
            }

            public string toWhom(string[] usernames, string typed)
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

        }
    }
}