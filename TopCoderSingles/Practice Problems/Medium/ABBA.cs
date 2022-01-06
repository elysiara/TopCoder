using System;

namespace TopCoderSingles.Practice_Problems
{
    // Example 4 fails, but I'm not sure why yet

    class ABBA : IProblem
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
        public IExample[] Examples => new IExample[]{
            new ABBAExample(("B" , "ABBA"), "Possible"),
            /*  Jamie can perform the following moves:
                Initially, the string is "B".
                Jamie adds an 'A' to the end of the string. Now the string is "BA".
                Jamie reverses the string and then adds a 'B' to the end of the string. Now the string is "ABB".
                Jamie adds an 'A' to the end of the string. Now the string is "ABBA".
                Since there is a sequence of moves which starts with "B" and creates the string "ABBA", the answer is "Possible".  */

            new ABBAExample(("AB" , "ABB"), "Impossible"),
            // The only strings of length 3 Jamie can create are "ABA" and "BAB".

            new ABBAExample(("BBAB" , "ABABABABB"), "Impossible"),
            new ABBAExample(("BBBBABABBBBBBA" , "BBBBABABBABBBBBBABABBBBBBBBABAABBBAA"), "Possible"),
            new ABBAExample(("A","BB"),"Impossible")
        };
        public class ABBAExample : ExampleBase<(string, string), string>
        {
            public ABBAExample((string, string) inputs, string correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                string output = canObtain(Inputs.Item1, Inputs.Item2);
                return (output.Equals(CorrectOutput));
            }

            string canObtain(string initial, string target)
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
                public string answer = "Impossible";

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
                        answer = "Possible";
                    }

                    // The tree stops generating if the currentValue length equals the target length
                    if (currentValue.Length == target.Length) return null;

                    Node next = new Node(currentValue);

                    // The two possible moves are:
                    // Add the letter A to the end of the string.                
                    string rule1Result = currentValue + "A";
                    next.Left = target.Contains(rule1Result) ? buildTree(rule1Result, target) : null;

                    // Reverse the string and then add the letter B to the end of the string.
                    string rule2Result = Reverse(currentValue) + "B";
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

        }
    }
}
