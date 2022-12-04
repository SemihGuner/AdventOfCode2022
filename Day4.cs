using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day4
    {
        public static void Main(string[] args)
        {
            // Part one.
            var filestream = new FileStream(@"..\..\..\Day4Input.txt", FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(filestream, Encoding.UTF8);
            string line;
            var splittedInt = new List<int>();
            while ((line = streamReader.ReadLine()) != null)
            {
                InputToIntState(line, splittedInt);
            }
            int containingCount = CheckContainingPartTwo(splittedInt);
            Console.WriteLine(containingCount);
            // Part two.
        }

        private static int CheckContaining(List<int> splittedInt)
        {
            int containingCount = 0;
            for (int i = 0; i < splittedInt.Count; i += 4)
            {
                //Console.WriteLine(splittedInt[i] + " , " + splittedInt[i + 1] + " , " + splittedInt[i + 2] + " , " + splittedInt[i + 3]);
                if (splittedInt[i] == splittedInt[i + 2])
                {
                    if (splittedInt[i + 1] >= splittedInt[i + 3])
                    {
                        containingCount++;
                        Console.WriteLine("aha!");
                    }
                    else if (splittedInt[i + 1] <= splittedInt[i + 3])
                    {
                        containingCount++;
                        Console.WriteLine("aha!");
                    }
                }
                else if (splittedInt[i] <= splittedInt[i + 2])
                {
                    if (splittedInt[i + 1] >= splittedInt[i + 3])
                    {
                        containingCount++;
                        Console.WriteLine("aha!");
                    }
                }
                else if (splittedInt[i] >= splittedInt[i + 2])
                {
                    if (splittedInt[i + 1] <= splittedInt[i + 3])
                    {
                        containingCount++;
                        Console.WriteLine("aha!");
                    }
                }
            }
            return containingCount;
        }
        
        private static int CheckContainingPartTwo(List<int> splittedInt)
        {
            int containingCount = 0;
            for (int i = 0; i < splittedInt.Count; i += 4)
            {
                //Console.WriteLine(splittedInt[i] + " , " + splittedInt[i + 1] + " , " + splittedInt[i + 2] + " , " + splittedInt[i + 3]);
                if ((splittedInt[i] >= splittedInt[i + 2] && splittedInt[i] <= splittedInt[i + 3]) || (splittedInt[i+1] >= splittedInt[i + 2] && splittedInt[i+1] <= splittedInt[i + 3]))
                {
                    //If the first two numbers are between the second pair...
                    containingCount++;
                }
                else if ((splittedInt[i+2] >= splittedInt[i] && splittedInt[i+2] <= splittedInt[i + 1]) || (splittedInt[i + 3] >= splittedInt[i] && splittedInt[i + 3] <= splittedInt[i + 1]))
                {
                    //If the second two numbers are between the first pair...
                    containingCount++;
                } 
            }
            return containingCount;
        }

        private static void InputToIntState(string line, List<int> splittedInt)
        {
            var stringSplit = new List<string[]>();
            var arrayStrSplit = line.Split(',');
            foreach (var item in arrayStrSplit)
            {
                stringSplit.Add(item.Split('-'));
            }
            foreach (var item in stringSplit)
            {
                foreach (var ikiitem in item)
                {
                    splittedInt.Add(Convert.ToInt32(ikiitem));
                    //Console.WriteLine(Convert.ToInt32(ikiitem));
                }
            }
        }
    }
}
