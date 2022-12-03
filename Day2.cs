using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2022
{
    class Day2
    {
        public static void Main(string[] args)
        {
            string line;
            int finalScore = 0;
            var fileStream = new FileStream(@"C:\Users\semih\OneDrive\Documents\Coding\AdventOfCode2022\AdventOfCode2022\Day2Input.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine())!= null)
                {
                    // Part One.
                    /*
                    line = line.Replace(" ", "");
                    int one = WinCheck(line[0], line[1]);
                    int two = WhatPlayerChoosed(line[1]); 
                    finalScore += one + two;
                    Console.WriteLine("Opponent is: " + line[0] + ", You're: " + line[1] + ", and finalScore: " + finalScore);
                    */
                    //Part Two. 
                    line = line.Replace(" ", "");
                    int one = theResult(line[1]);
                    int two = yourDesicion(line[0], line[1]);
                    finalScore += one + two;
                }

            }
            Console.WriteLine(finalScore);
        }

        // Part One's Functions.
        public static int WhatPlayerChoosed(char decision)
        {
            if (decision == 'X')
            {
                return 1;
            }
            else if (decision == 'Y')
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        
         //First column is what opponents play. A= Rock, B= Paper, C=Scissors.
         //Second is us. X for Rock, Y for Paper, and Z for Scissors.
         //The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors).
         //Plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).

        public static int WinCheck(char opponent,char you)
        {
            if ((opponent == 'A' && you == 'X') || (opponent == 'B' && you == 'Y') || (opponent == 'C' && you == 'Z'))
            {
                return 3;
            }
            else if ((opponent=='A' && you=='Z')|| (opponent == 'B' && you == 'X') || (opponent == 'C' && you == 'Y'))
            {
                return 0;
            }
            else
            {
                return 6;
            }
        }

        // Part Two's Functions.

        public static int theResult(char you)
        {
            if (you == 'X')
            {
                return 0;
            }
            else if (you == 'Y')
            {
                return 3;
            }
            else
            {
                return 6;
            }
        }
        public static int yourDesicion(char opponent, char you)
        {
            if (you == 'Y')
            {
                switch (opponent)
                {
                    case 'A':
                        return 1;
                    case 'B':
                        return 2;
                    default:
                        return 3;
                }
            }
            else if (you == 'X')
            {
                switch (opponent)
                {
                    case 'A':
                        return 3;
                    case 'B':
                        return 1;
                    default:
                        return 2;
                }
            }
            else
            {
                switch (opponent)
                {
                    case 'A':
                        return 2;
                    case 'B':
                        return 3;
                    default:
                        return 1;
                }
            }
        }
    }
}
