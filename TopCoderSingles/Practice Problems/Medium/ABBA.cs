using System;
using System.Threading;
using System.Threading.Tasks;

namespace TopCoderSingles.Practice_Problems
{
    // Example 4 fails, but I'm not sure why yet

    class ABBA : IDisplayableProblem, ITestableExamples<(string initial, string target), string>
    {
        public string Name => "ABBA";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/16527/48825/13918/2/326683";
        public string CodeAsString => @"            string canObtain(string initial, string target)
            { 
                TreeBuilder tb = new TreeBuilder(initial, target);
                return tb.answer;
            }

            class Node
            {
                public Node(string data)
                {
                    Data = data;
                }
                public string Data { get; }
                public Node Left { get; set; }
                public Node Right { get; set; }
            }

            class TreeBuilder
            {
                public string answer = ""Impossible"";

                public Node Root { get; }

        public TreeBuilder(string initial, string target)
        {
            // Starting at initial, create a binary tree
            Root = buildTree(initial, target);
        }

        private Node buildTree(string currentValue, string target)
        {
            // If the tree contains the target value - the solution is possible!
            if (String.Equals(currentValue, target))
            {
                answer = ""Possible"";
            }

            // The tree stops generating if the currentValue length equals the target length
            if (currentValue.Length == target.Length) return null;

            Node next = new Node(currentValue);

            // The two possible moves are:
            // Add the letter A to the end of the string.                
            string rule1Result = currentValue + ""A"";
            next.Left = target.Contains(rule1Result) ? buildTree(rule1Result, target) : null;

            // Reverse the string and then add the letter B to the end of the string.
            string rule2Result = Reverse(currentValue) + ""B"";
            next.Right = target.Contains(rule2Result) ? buildTree(rule2Result, target) : null;

            return next;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
";

        private GenericTester<(string initial, string target), string> ABBATester = new GenericTester<(string initial, string target), string>();
        public async Task<string> TestExamplesOnceTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await ABBATester.TestExamplesOnceTask(this, token, progress);
        }
        public async Task<string> TestExamplesForAverageTask(CancellationToken token, IProgress<int> progress = null)
        {
            return await ABBATester.TestExamplesForAverageTask(this, token, progress);
        }

        public IExample<(string initial, string target), string>[] Examples => new GenericExample<(string initial, string target), string>[]{
            new GenericExample<(string initial, string target), string>(("B" , "ABBA"), "Possible"),
            /*  Jamie can perform the following moves:
                Initially, the string is "B".
                Jamie adds an 'A' to the end of the string. Now the string is "BA".
                Jamie reverses the string and then adds a 'B' to the end of the string. Now the string is "ABB".
                Jamie adds an 'A' to the end of the string. Now the string is "ABBA".
                Since there is a sequence of moves which starts with "B" and creates the string "ABBA", the answer is "Possible".  */

            new GenericExample<(string initial, string target), string>(("AB" , "ABB"), "Impossible"),
            // The only strings of length 3 Jamie can create are "ABA" and "BAB".

            new GenericExample<(string initial, string target), string>(("BBAB" , "ABABABABB"), "Impossible"),
            new GenericExample<(string initial, string target), string>(("BBBBABABBBBBBA" , "BBBBABABBABBBBBBABABBBBBBBBABAABBBAA"), "Possible"),
            new GenericExample<(string initial, string target), string>(("A","BB"),"Impossible")
        };
        public bool TestExample(IExample<(string initial, string target), string> example)
        {
            string output = CanObtain(example.Inputs.initial, example.Inputs.target);
            return (output.Equals(example.Output));
        }
        private string CanObtain(string initial, string target)
        {
            TreeBuilder tb = new TreeBuilder(initial, target);
            return tb.answer;
        }
        private class Node
        {
            public Node(string data)
            {
                Data = data;
            }
            public string Data { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        private class TreeBuilder
        {
            public string answer = "Impossible";

            public Node Root { get; }

            public TreeBuilder(string initial, string target)
            {
                // Starting at initial, create a binary tree
                Root = BuildTree(initial, target);
            }

            private Node BuildTree(string currentValue, string target)
            {
                // If the tree contains the target value - the solution is possible!
                if (String.Equals(currentValue, target))
                {
                    answer = "Possible";
                }

                // The tree stops generating if the currentValue length equals the target length
                if (currentValue.Length == target.Length) return null;

                Node next = new Node(currentValue);

                // The two possible moves are:
                // Add the letter A to the end of the string.                
                string rule1Result = currentValue + "A";
                next.Left = target.Contains(rule1Result) ? BuildTree(rule1Result, target) : null;

                // Reverse the string and then add the letter B to the end of the string.
                string rule2Result = Reverse(currentValue) + "B";
                next.Right = target.Contains(rule2Result) ? BuildTree(rule2Result, target) : null;

                return next;
            }

            public string Reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
        }
    }
}
