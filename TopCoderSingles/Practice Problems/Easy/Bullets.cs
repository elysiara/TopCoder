using System.Linq;

namespace TopCoderSingles.Practice_Problems
{
    public class Bullets : IProblem
    {
        public string Name => "Bullets";
        public string Link => "https://arena.topcoder.com/#/u/practiceCode/1174/665/665/1/1174";
        public string CodeAsString => @"public int match(string[] guns, string bullet)
        {
            // Initialise counter for the guns
            int i = 0;

            // Check to see whether the bullet matches each gun
            // If it doesn't match, 'rotate' the bullet and try again until all orientations have been tried
            foreach (string gun in guns)
            {
                for (int j = 0; j <= gun.Length; j++)
                {
                    if (gun.Equals(bullet))
                    {
                        return i;
                    }
                    else
                    {
                        string shiftedBullet = bullet.Last().ToString() + bullet.Substring(0, bullet.Length - 1);
    bullet = shiftedBullet;
                    }
                }
                i++;
            }
            // If no guns match, return -1
            return -1;
        }";
        public IExample[] Examples => new BulletExample[]
        {
            new BulletExample((new string[]{"| | | |","|| || |"," |||| "},"|| || |"),1),
            new BulletExample((new string[]{"||| |","| | || "},"|||| "),0),
            new BulletExample((new string[]{"|| || ||","| | | | ","||||||||"},"||| ||| "),-1),
            new BulletExample((new string[]{},"| | | |"),-1),
            new BulletExample((new string[]{"|| || ||","| | | | ","||| ||| ","||||||||"},"|| ||| |"),2)
        };
        public class BulletExample : ExampleBase<(string[], string), int>
        {
            public BulletExample((string[], string) inputs, int correctOutput) : base(inputs, correctOutput)
            {
            }

            public override bool TestExample()
            {
                int output = match(Inputs.Item1, Inputs.Item2);
                return (output.Equals(CorrectOutput));
            }

            public int match(string[] guns, string bullet)
            {
                // Initialise counter for the guns
                int i = 0;

                // Check to see whether the bullet matches each gun
                // If it doesn't match, 'rotate' the bullet and try again until all orientations have been tried
                foreach (string gun in guns)
                {
                    for (int j = 0; j <= gun.Length; j++)
                    {
                        if (gun.Equals(bullet))
                        {
                            return i;
                        }
                        else
                        {
                            string shiftedBullet = bullet.Last().ToString() + bullet.Substring(0, bullet.Length - 1);
                            bullet = shiftedBullet;
                        }
                    }
                    i++;
                }
                // If no guns match, return -1
                return -1;
            }
        }
    }
}