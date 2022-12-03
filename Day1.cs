using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day1
    {
        public static void Main(string[] args)
        {
            var list = new List<string>();
            int sum = 0;
            var CaloriesList = new List<int>();
            var fileStream = new FileStream(@"C:\Users\semih\OneDrive\Documents\Coding\AdventOfCode2022\AdventOfCode2022\Day1Input.txt", FileMode.Open, FileAccess.Read);
            // Taking all the input into the code.
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            //Processing the input.
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != "")
                {
                    sum += Convert.ToInt32(list[i]);
                }
                else
                {
                    CaloriesList.Add(sum);
                    sum = 0;
                }
            }
            CaloriesList.Sort();
            Console.WriteLine(CaloriesList[CaloriesList.Count - 1] + CaloriesList[CaloriesList.Count - 2] + CaloriesList[CaloriesList.Count - 3]);
        }
    }
}
