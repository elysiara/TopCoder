﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TopCoderSingles.Practice_Problems
{
    class Abacus : ProblemBase
    {
        public override string Name => "Abacus";

        public override string Link => "https://arena.topcoder.com/#/u/practiceCode/1626/4170/4512/2/1626";

        public override string CodeAsString => @"            string[] add(string[] original, int val)
            {
                int factor = 100000;
                int value = 0;

                for (int i = 0; i < original.Length; i++)
                {
                    value += Convert.ToInt32(Regex.Split(original[i], ""(-) + "").Last().Length) * factor;
                    factor /= 10;
                }

    value += val;

                string[] newAbacusStrings = new string[original.Length];

    factor = 100000;

                for (int i = 0; i<original.Length; i++)
                {
                    int newAbacusValue = Convert.ToInt32(Math.Floor((double)value / factor));
    value -= newAbacusValue* factor;
    factor /= 10;

                    List<char> beadsList = Enumerable.Repeat('o', 9 - newAbacusValue).ToList();
    beadsList.AddRange(Enumerable.Repeat('-', 3).ToList());
                    beadsList.AddRange(Enumerable.Repeat('o', newAbacusValue).ToList());

                    newAbacusStrings[i] = new string (beadsList.ToArray());
                }
                return newAbacusStrings;
            }
";

        protected override IExample[] Examples => new IExample[]
            {
                // When we add 5 to the original, it is necessary to "carry" 1 to the next thread up. This shows the arithmetic 699979 + 5 = 699984
                new AbacusExample((
                    new string[] {"ooo---oooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo", "oo---ooooooo", "---ooooooooo"}, 5),
                    new string[] {"ooo---oooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo", "o---oooooooo", "ooooo---oooo" }),
                // This shows 699979 + 21 = 700000
                new AbacusExample((
                    new string[] {"ooo---oooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo", "oo---ooooooo", "---ooooooooo"}, 21),
                    new string[] {"oo---ooooooo", "ooooooooo---", "ooooooooo---", "ooooooooo---", "ooooooooo---", "ooooooooo---" }),
                new AbacusExample((
                    new string[] {"ooooooooo---", "---ooooooooo", "ooooooooo---", "---ooooooooo", "oo---ooooooo", "---ooooooooo"}, 100000),
                    new string[] {"oooooooo---o", "---ooooooooo", "ooooooooo---", "---ooooooooo", "oo---ooooooo", "---ooooooooo" }),
                new AbacusExample((
                    new string[] {"o---oooooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo", "---ooooooooo" }, 1),
                    new string[] {"---ooooooooo", "ooooooooo---", "ooooooooo---", "ooooooooo---", "ooooooooo---", "ooooooooo---" })
            };

        public class AbacusExample : ExampleBase<(string[], int), string[]>
        {
            public AbacusExample((string[], int) inputs, string[] correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                string[] output = add(Inputs.Item1, Inputs.Item2);

                bool[] stringsMatch = new bool[output.Length];
                for (int i = 0; i < output.Length; i++)
                {
                    stringsMatch[i] = String.Equals(output[i], CorrectOutput[i]);
                }

                return stringsMatch.All(x => x);
            }

            string[] add(string[] original, int val)
            {
                int factor = 100000;
                int value = 0;

                for (int i = 0; i < original.Length; i++)
                {
                    value += Convert.ToInt32(Regex.Split(original[i], "(-)+").Last().Length) * factor;
                    factor /= 10;
                }

                value += val;

                string[] newAbacusStrings = new string[original.Length];

                factor = 100000;

                for (int i = 0; i < original.Length; i++)
                {
                    int newAbacusValue = Convert.ToInt32(Math.Floor((double)value / factor));
                    value -= newAbacusValue * factor;
                    factor /= 10;

                    List<char> beadsList = Enumerable.Repeat('o', 9 - newAbacusValue).ToList();
                    beadsList.AddRange(Enumerable.Repeat('-', 3).ToList());
                    beadsList.AddRange(Enumerable.Repeat('o', newAbacusValue).ToList());

                    newAbacusStrings[i] = new string(beadsList.ToArray());
                }
                return newAbacusStrings;
            }
        }
    }
}