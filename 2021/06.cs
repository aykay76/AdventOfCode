using System;
using System.Collections.Generic;
using System.IO;

public class Sixth
{
    public void Run1()
    {
        string[] lines = File.ReadAllLines("06.txt");

        string[] parts = lines[0].Split(",");
        int[] lanternfish = new int[parts.Length];
        for (int s = 0; s < parts.Length; s++)
        {
            lanternfish[s] = Convert.ToInt32(parts[s]);
        }

        for (int day = 0; day < 80; day++)
        {
            int toadd = 0;
            for (int f = 0; f < lanternfish.Length; f++)
            {
                if (lanternfish[f] == 0)
                {
                    lanternfish[f] = 6;
                    toadd++;
                }
                else
                {
                    lanternfish[f] = lanternfish[f] - 1;
                }
            }

            var newArray = new int[lanternfish.Length + toadd];
            Array.Copy(lanternfish, newArray, lanternfish.Length);
            for (int i = 0; i < toadd; i++)
            {
                newArray[lanternfish.Length + i] = 8;
            }
            lanternfish = newArray;

            Console.WriteLine($"Day {day}, added {toadd} fish, new population is {lanternfish.Length}.");
        }

        Console.WriteLine($"Lanternfish after 80 days: {lanternfish.Length}");
    }

    public void Run2()
    {
        string[] lines = File.ReadAllLines("06.txt");

        string[] parts = lines[0].Split(",");
        Dictionary<int, Int64> lanternfish = new Dictionary<int, Int64>();
        for (int i = 0; i < 9; i++)
        {
            lanternfish[i] = 0;
        }
        for (int s = 0; s < parts.Length; s++)
        {
            int age = Convert.ToInt32(parts[s]);
            if (lanternfish.ContainsKey(age))
            {
                lanternfish[age] = lanternfish[age] + 1;
            }
        }

        for (int day = 0; day < 256; day++)
        {
            Int64 toadd = lanternfish[0];
            lanternfish[0] = lanternfish[1];
            lanternfish[1] = lanternfish[2];
            lanternfish[2] = lanternfish[3];
            lanternfish[3] = lanternfish[4];
            lanternfish[4] = lanternfish[5];
            lanternfish[5] = lanternfish[6];
            lanternfish[6] = lanternfish[7] + toadd;
            lanternfish[7] = lanternfish[8];
            lanternfish[8] = toadd;

            Console.WriteLine($"Day {day}, added {toadd} fish.");
        }

        Int64 total = 0;
        foreach (Int64 value in lanternfish.Values)
        {
            total += value;
        }

        Console.WriteLine($"Lanternfish after 256 days: {total}");
    }
}