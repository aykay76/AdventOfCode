using System;
using System.Collections.Generic;
using System.IO;

public class First
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("01.txt");
        int prev = -1;
        int largerCount = 0;

        foreach (string line in lines)
        {
            int value = int.Parse(line);
            if (prev != -1)
            {
                if (value > prev)
                {
                    largerCount++;
                }
            }
            prev = value;
        }

        Console.WriteLine($"Larger count: {largerCount}.");
    }

    public void Run2()
    {
        List<int> windows = new List<int>();
        string[] lines = File.ReadAllLines("01.txt");

        for (int i = 2; i < lines.Length; i++)
        {
            int value1 = int.Parse(lines[i - 2]);
            int value2 = int.Parse(lines[i - 1]);
            int value3 = int.Parse(lines[i]);

            windows.Add(value1 + value2 + value3);
        }

        int prev = -1;
        int largerCount = 0;
        foreach (int value in windows)
        {
            if (prev != -1)
            {
                if (value > prev)
                {
                    largerCount++;
                }
            }

            prev = value;
        }

        Console.WriteLine($"Larger count: {largerCount}.");
    }
}