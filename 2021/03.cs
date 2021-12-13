using System;
using System.Collections.Generic;
using System.IO;

public class Third
{
    public void Run1()
    {
        var count1s = new int[12];
        var count0s = new int[12];
        string[] lines = File.ReadAllLines("03.txt");

        foreach (string line in lines)
        {
            for (int i = 0; i < 12; i++)
            {
                if (line[i] == '0')
                {
                    count0s[i]++;
                }
                else if (line[i] == '1')
                {
                    count1s[i]++;
                }
            }
        }

        string gamma = string.Empty;
        string epsilon = string.Empty;
        for (int i = 0; i < 12; i++)
        {
            if (count0s[i] < count1s[i])
            {
                gamma += "1";
                epsilon += "0";
            }
            else
            {
                gamma += "0";
                epsilon += "1";
            }
        }

        Console.WriteLine($"Gamma rate: {gamma}");
        Console.WriteLine($"Epsilon rate: {epsilon}");
        Console.WriteLine($"Power consumption: {Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)}");
    }

    // https://adventofcode.com/2021/day/3#part2
    public void Run2()
    {
        int generator = 0;
        int scrubber = 0;

        string[] lines = File.ReadAllLines("03.txt");
        List<string> input = new List<string>();
        List<string> output = new List<string>();

        input = new List<string>(lines);

        for (int c = 0; c < 12; c++)
        {
            int count0 = 0;
            int count1 = 0;

            foreach (string line in input)
            {
                if (line[c] == '0')
                {
                    count0++;
                }
                else if (line[c] == '1')
                {
                    count1++;
                }
            }

            Console.WriteLine($"Input count: {input.Count}");
            if (input.Count == 1) break;

            if (count1 >= count0)
            {
                output = new List<string>();
                // only keep those with a 1
                foreach (string s in input)
                {
                    if (s[c] == '1')
                    {
                        output.Add(s);
                    }
                }
            }
            else
            {
                output = new List<string>();
                // only keep those with a 0
                foreach (string s in input)
                {
                    if (s[c] == '0')
                    {
                        output.Add(s);
                    }
                }
            }

            input = output;
        }

        generator = Convert.ToInt32(input[0], 2);
        Console.WriteLine($"Oxygen generator rating: {generator}");

        input = new List<string>(lines);
        for (int c = 0; c < 12; c++)
        {
            int count0 = 0;
            int count1 = 0;

            foreach (string line in input)
            {
                if (line[c] == '0')
                {
                    count0++;
                }
                else if (line[c] == '1')
                {
                    count1++;
                }
            }

            Console.WriteLine($"Input count: {input.Count}");
            if (input.Count == 1) break;

            if (count0 <= count1)
            {
                output = new List<string>();
                // only keep those with a 1
                foreach (string s in input)
                {
                    if (s[c] == '0')
                    {
                        output.Add(s);
                    }
                }
            }
            else
            {
                output = new List<string>();
                // only keep those with a 0
                foreach (string s in input)
                {
                    if (s[c] == '1')
                    {
                        output.Add(s);
                    }
                }
            }

            input = output;
        }

        scrubber = Convert.ToInt32(input[0], 2);
        Console.WriteLine($"CO2 Scrubber rating: {scrubber}");

        Console.WriteLine($"Life support rating: {generator * scrubber}");
    }
}