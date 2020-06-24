using System.Linq;
using System.Threading;

namespace TopCoderSingles.Practice_Problems
{
    public class TestProblem1 : ProblemBase
    {
        public override string Name => "TestProblem1";
        public override string Link => "https://arena.topcoder.com/index.html#/u/practiceCode/1282/1262/1333/2/1282";

        public override string CodeAsString =>
            "int calculateSum(int[] inputs)\r\n" +
            "{\r\n" +
            "\t// Simulate something time consuming\r\n" +
            "\tThread.Sleep(200);\r\n" +
            "\treturn inputs.Sum();\r\n" +
            "}";

        protected override IExample[] Examples =>
            new TestProblem1Example[]{
            new TestProblem1Example((1, 2, 3, "doesn't matter"),6),
            new TestProblem1Example((4, 5, 6, "still doesn't matter"),15),
            new TestProblem1Example((7, 8, 9, "again, doesn't matter"),24)};

        protected class TestProblem1Example : ExampleBase<(int, int, int, string), int>
        {
            public TestProblem1Example((int, int, int, string) inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = calculateSum(Inputs.Item1, Inputs.Item2, Inputs.Item3);
                return (output.Equals(CorrectOutput));
            }

            int calculateSum(int input1, int input2, int input3)
            {
                // Simulate something time consuming
                Thread.Sleep(200);
                return new int[] { input1, input2, input3 }.Sum();
            }

        }
    }
}