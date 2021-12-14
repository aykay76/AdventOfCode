using System;
using System.Collections.Generic;
using System.IO;

public class Eighth
{
    public void Run1()
    {
        int number2 = 0;
        int number3 = 0;
        int number4 = 0;
        int number7 = 0;

        string[] lines = File.ReadAllLines("08.txt");
        foreach (string s in lines)
        {
            string[] parts = s.Split(" | ");
            string[] digits = parts[1].Split(" ");

            foreach (string digit in digits)
            {
                if (digit.Length == 2) number2++;
                if (digit.Length == 3) number3++;
                if (digit.Length == 4) number4++;
                if (digit.Length == 7) number7++;
            }
        }

        Console.WriteLine($"{number2 + number3 + number4 + number7}");
    }

    //  aaaa 
    // b    c
    // b    c
    //  dddd 
    // e    f
    // e    f
    //  gggg

    // Frequency:
    // a = 8
    // b = 6
    // c = 8
    // d = 7
    // e = 4
    // f = 9
    // g = 7

    // Segment counts:
    // 0 = 6
    // 1 = 2
    // 2 = 5
    // 3 = 5
    // 4 = 4
    // 5 = 5
    // 6 = 6
    // 7 = 3
    // 8 = 7
    // 9 = 6
    public void Run2()
    {
        int total = 0;
        string all = "abcdefg";
        string[] lines = File.ReadAllLines("08.txt");
        foreach (string s in lines)
        {
            string[] parts = s.Split(" | ");
            string[] signals = parts[0].Split(" ");
            Array.Sort(signals, (x,y) => x.Length.CompareTo(y.Length));

            // * get the frequency of each letter
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (char c in parts[0])
            {
                if (frequencies.ContainsKey(c))
                {
                    frequencies[c] = frequencies[c] + 1;
                }
                else
                {
                    frequencies[c] = 1;
                }
            }

            // * allocate a letter to each segment
            List<char> segments = new List<char>(7);
            for (int i = 0; i < 7; i++) segments.Add('x');

            foreach (string signal in signals)
            {
                // of the 2 letter sequence, find the letter that appears 9 times - that's bottom right
                // the other letter is top right
                if (signal.Length == 2)
                {
                    foreach (char c in signal)
                    {
                        if (frequencies[c] == 9) segments[5] = c;
                        else segments[2] = c;
                    }
                }

                // of the 3 letter sequence, the third distinct letter is top
                if (signal.Length == 3)
                {
                    foreach (char c in signal)
                    {
                        if (segments.Contains(c) == false)
                        {
                            segments[0] = c;
                        }
                    }
                }

                // of the 4 letter sequence, the letter that appears 6 times is top left
                // the remaining distinct letter is middle
                if (signal.Length == 4)
                {
                    foreach (char c in signal)
                    {
                        if (frequencies[c] == 6) 
                        {
                            segments[1] = c;
                        }
                        else 
                        {
                            if (segments.Contains(c) == false) segments[3] = c;
                        }
                    }
                }
            }

            // bottom left only appears 4 times
            foreach (char c in frequencies.Keys)
            {
                if (frequencies[c] == 4) segments[4] = c;
            }

            // remaining segment is obvious
            foreach (char c in all)
            {
                if (segments.Contains(c) == false) segments[6] = c;
            }

            // * build a string to represent each digit
            char[][] digitSegments = {
                new char[] { segments[0], segments[1], segments[2], segments[4], segments[5], segments[6] },
                new char[] { segments[2], segments[5] },
                new char[] { segments[0], segments[2], segments[3], segments[4], segments[6] },
                new char[] { segments[0], segments[2], segments[3], segments[5], segments[6] },
                new char[] { segments[1], segments[2], segments[3], segments[5] },
                new char[] { segments[0], segments[1], segments[3], segments[5], segments[6] },
                new char[] { segments[0], segments[1], segments[3], segments[4], segments[5], segments[6] },
                new char[] { segments[0], segments[2], segments[5] },
                new char[] { segments[0], segments[1], segments[2], segments[3], segments[4], segments[5], segments[6] },
                new char[] { segments[0], segments[1], segments[2], segments[3], segments[5], segments[6] }
            };
            for (int i = 0; i < 10; i++)
            {
                Array.Sort(digitSegments[i]);
            }

            // * compare digit with second part after | 
            string[] digits = parts[1].Split(" ");
            int value = 0;
            int mul = 1000;
            foreach (string digit in digits)
            {
                char[] input = digit.ToCharArray();
                Array.Sort(input);

                for (int i = 0; i < 10; i++)
                {
                    if (digitSegments[i].Length == input.Length)
                    {
                        bool match = true;

                        for (int j = 0; j < digitSegments[i].Length; j++)
                        {
                            if (digitSegments[i][j] != input[j])
                            {
                                match = false;
                            }
                        }

                        if (match)
                        {
                            value += i * mul;
                        }
                    }
                }

                mul /= 10;
            }

            // * add to running total
            total += value;
        }

        Console.WriteLine(total);
    }
}