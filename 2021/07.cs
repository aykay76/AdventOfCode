using System;
using System.Collections.Generic;
using System.IO;

public class Seventh
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("07.txt");
        string[] parts = lines[0].Split(",");
        int[] positions = new int[parts.Length];
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < parts.Length; i++)
        {
            positions[i] = Convert.ToInt32(parts[i]);
            if (positions[i] > max) max = positions[i];
            if (positions[i] < min) min = positions[i];
        }

        // brute force approach, could probably calculate mean, median or mode and see what's what
        int minCost = int.MaxValue;
        int minPos = int.MaxValue;
        Dictionary<int, int> costs = new Dictionary<int, int>();
        for (int i = min; i <= max; i++)
        {
            int fuel = 0;
            foreach (int p in positions)
            {
                fuel += Math.Abs(p - i);
            }
            costs[i] = fuel;
            if (fuel < minCost)
            {
                minPos = i;
                minCost = fuel;
            }
        }

        Console.WriteLine($"Minimium cost: {minCost}, at pos {minPos}");
    }

    public void Run2()
    {
        string[] lines = File.ReadAllLines("07.txt");
        string[] parts = lines[0].Split(",");
        int[] positions = new int[parts.Length];
        int min = int.MaxValue;
        int max = int.MinValue;
        for (int i = 0; i < parts.Length; i++)
        {
            positions[i] = Convert.ToInt32(parts[i]);
            if (positions[i] > max) max = positions[i];
            if (positions[i] < min) min = positions[i];
        }

        // brute force approach, could probably calculate mean, median or mode and see what's what
        int minCost = int.MaxValue;
        int minPos = int.MaxValue;
        Dictionary<int, int> costs = new Dictionary<int, int>();
        for (int i = min; i <= max; i++)
        {
            int fuel = 0;
            foreach (int p in positions)
            {
                int f = 1;
                for (int j = 0; j < Math.Abs(p - i); j++)
                {
                    fuel += f;
                    f++;
                }
            }
            costs[i] = fuel;
            if (fuel < minCost)
            {
                minPos = i;
                minCost = fuel;
            }
        }

        Console.WriteLine($"Minimium cost: {minCost}, at pos {minPos}");
    }
}