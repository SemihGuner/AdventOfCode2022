using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2022
{
    // I couldn't manage to do the 2nd part of the puzzle.
    class Day3
    {
        public static void Main(string[] args)
        {
            string line;
            var firsthalf = new List<string>();
            var lasthalf = new List<string>();
            var commonLetters = new List<string>();
            int sum = 0;
            var fileStream = new FileStream(@"..\..\..\Day3Input.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    SplitLine(line, firsthalf, lasthalf);
                    firsthalf.Sort();
                    lasthalf.Sort();
                    commonLetters.Add(FindTheMatch(firsthalf, lasthalf));
                    firsthalf.Clear();
                    lasthalf.Clear();
                }
            }

            // For the 2nd part of the question.
            for (int i = 0; i < commonLetters.Count; i++)
            {
                if (commonLetters[i] != null)
                {
                    for (int k = i + 1; k < commonLetters.Count; k++)
                    {
                        commonLetters.RemoveAt(k);
                    }
                }
                else
                {
                    break;
                }
            }
            //foreach (var item in commonLetters)
            //{
            //    var val = alphabetToNumber(item);
            //    Console.WriteLine("The string is: " + item + " , the value is: " + val);
            //    sum += val;
            //}
            //Console.WriteLine(sum);
            foreach (var item in commonLetters)
            {
                Console.WriteLine(item);
            }
        }

        public static string FindTheMatch(List<string> firsthalf, List<string> lasthalf)
        {
            //    for (int i = 0; i < firsthalf.Count; i++)
            //    {
            //        for (int k = 0; k < lasthalf.Count; k++)
            //        {
            //            if (firsthalf[i] == lasthalf[k])
            //            {
            //                return firsthalf[i];
            //            }
            //            else
            //            {
            //                continue;
            //            }
            //        }
            //    }
            //NGL, I took the intersect code from StackOverflow.
            var matchItem = firsthalf.Intersect(lasthalf).First();
            //Console.WriteLine(matchItem);
            return matchItem;
        }
        public static int alphabetToNumber(string letter)
        {
            //Thanks, Uruk.
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            alphabet += alphabet.ToUpper();
            return alphabet.IndexOf(letter) + 1;
        }

        public static void SplitLine(string line, List<string> firsthalf, List<string> lasthalf)
        {
            int length = line.Length;
            for (int i = 0; i < (length / 2); i++)
            {
                firsthalf.Add(Convert.ToString(line[i]));
            }
            for (int k = (length / 2); k < (length); k++)
            {
                lasthalf.Add(Convert.ToString(line[k]));
            }

        }
    }
}
