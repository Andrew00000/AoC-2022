using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines($@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\in.txt");

            var scoresDictionary = new Dictionary<string, int>
            {
                { "A X", 4 },
                { "A Y", 8 },
                { "A Z", 3 },

                { "B X", 1 },
                { "B Y", 5 },
                { "B Z", 9 },

                { "C X", 7 },
                { "C Y", 2 },
                { "C Z", 6 } 
            };

            var sum = 0;

            foreach(var line in input)
            {
                sum += scoresDictionary[line];
            }

            Console.WriteLine(sum);

            var modifiedScoresDictionary = new Dictionary<string, int>
            {
                { "A X", 3 },
                { "A Y", 4 },
                { "A Z", 8 },

                { "B X", 1 },
                { "B Y", 5 },
                { "B Z", 9 },

                { "C X", 2 },
                { "C Y", 6 },
                { "C Z", 7 } 
            };

            var sum2 = 0;

            foreach (var line in input)
            {
                sum2 += modifiedScoresDictionary[line];
            }

            Console.WriteLine(sum2);
        }
    }
}
